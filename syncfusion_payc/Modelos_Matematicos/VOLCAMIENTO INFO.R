library(DBI)
con <- dbConnect(odbc::odbc(), "PAYC_FACTURACION", uid = "sa", pwd = "1234JAMS*")
fact <- paste0("SELECT * FROM FACTURAS")
FACTURAS <- dbGetQuery(con, fact)
dbDisconnect(con)

factura <- function(cod_factura) {
  library(DBI)
  
  #CONEXIÓN Y EXTRACCIÓN DE LA INFORMACIÓN DE LA BASE DE DATOS---------------
  #CONEXIÓN A LA BASE DE DATOS
  con <- dbConnect(odbc::odbc(), "PAYC_FACTURACION", uid = "sa", pwd = "1234JAMS*")
  #cod_factura = 11443
  
  #EXTRACCION DE LA INFORMACION IMPORTANTE DE LA BASE DE DATOS
  fact <- paste0("SELECT * FROM FACTURAS WHERE COD_FACTURA=", cod_factura)
  FACTURAS <- dbGetQuery(con, fact)
  
  fecha <- FACTURAS$COD_FORMAS_PAGO_FECHAS
  proyecto <- FACTURAS$COD_CONTRATO_PROYECTO
  estado <- FACTURAS$COD_ESTADO_FACTURA
  personas <- paste0("SELECT * FROM FLUJO_INGRESOS_ROLES
                     WHERE COD_CONTRATO_PROYECTO=", proyecto, "
                     AND COD_FORMAS_PAGO_FECHAS=", fecha, "
                     AND ESTADO='SI'")
  fijos <- paste0("SELECT FLUJO_INGRESOS_ITEM.*, 
                  ITEMS_CONTRATO.COD_TIPO_REEMBOLSO
                  FROM FLUJO_INGRESOS_ITEM, ITEMS_CONTRATO 
                  WHERE ITEMS_CONTRATO.COD_TIPO_REEMBOLSO=1 
                  AND FLUJO_INGRESOS_ITEM.ESTADO='SI'
                  AND FLUJO_INGRESOS_ITEM.COD_CONTRATO_PROYECTO=", proyecto, "
                  AND FLUJO_INGRESOS_ITEM.COD_FORMAS_PAGO_FECHAS=", fecha, "
                  AND ITEMS_CONTRATO.COD_ITEM_CONTRATO=FLUJO_INGRESOS_ITEM.COD_ITEM_CONTRATO")
  variables <- paste0("SELECT FLUJO_INGRESOS_ITEM.*, 
                      ITEMS_CONTRATO.COD_TIPO_REEMBOLSO
                      FROM FLUJO_INGRESOS_ITEM, ITEMS_CONTRATO 
                      WHERE ITEMS_CONTRATO.COD_TIPO_REEMBOLSO=2 
                      AND FLUJO_INGRESOS_ITEM.ESTADO='SI'
                      AND FLUJO_INGRESOS_ITEM.COD_CONTRATO_PROYECTO=", proyecto, "
                      AND FLUJO_INGRESOS_ITEM.COD_FORMAS_PAGO_FECHAS=", fecha, "
                      AND ITEMS_CONTRATO.COD_ITEM_CONTRATO=FLUJO_INGRESOS_ITEM.COD_ITEM_CONTRATO")
  items <- paste0("SELECT * FROM ITEMS_CONTRATO
                  WHERE COD_CONTRATO_PROYECTO=", proyecto)
  contrato <- paste0("SELECT COD_TIPO_CONDICION
                     FROM CONTRATOS_CONDICIONES
                     WHERE COD_CONTRATO_PROYECTO=", proyecto)
  adicion <- paste0("SELECT *
                    FROM VISTA_REGISTRO_NOVEDADES
                    WHERE COD_CONTRATO_PROYECTO=", proyecto, "
                    AND COD_FORMAS_PAGO_FECHAS=", fecha, " 
                    AND COD_TIPO_NOVEDAD BETWEEN 2 AND 5")
  descuento <- paste0("SELECT *
                      FROM VISTA_REGISTRO_NOVEDADES_TEMP
                      WHERE COD_CONTRATO_PROYECTO=", proyecto, "
                      AND COD_FORMAS_PAGO_FECHAS=", fecha, " 
                      AND COD_TIPO_NOVEDAD IN (7,8,11,12)")
  salario <- paste0("SELECT *
                    FROM [test_payc_contabilidad].[dbo].[VISTA_SALARIO_INCREMENTOS_TEMP]
                    WHERE COD_CONTRATO_PROYECTO=", proyecto,
                    "AND COD_FORMAS_PAGO_FECHAS=", fecha)
  adjunto <- paste0("SELECT [COD_ROL]
                    ,[COD_COLABORADOR]
                    ,[FECHA_INI]
                    ,[FECHA_FIN]
                    ,[VALOR_FACTOR_MULTIPLICADOR]
                    FROM [test_payc_contabilidad].[dbo].[VISTA_FACTURACION_ADJUNTO_PERS]
                    WHERE COD_CONTRATO_PROYECTO=", proyecto, "
                    AND COD_FORMAS_PAGO_FECHAS=", fecha, "
                    AND ESTADO='SI'")
  
  INGRESOS_PERSONAS <- dbGetQuery(con, personas)
  ITEMS_CONTRATO <- dbGetQuery(con, items)
  ITEMS_FIJOS <- dbGetQuery(con, fijos)
  ITEMS_VARIABLES <- dbGetQuery(con, variables)
  CONDICIONES_CONTRATO <- dbGetQuery(con, contrato)
  NOVEDADES_ADICION <- dbGetQuery(con, adicion)
  NOVEDADES_DESCUENTO <- dbGetQuery(con, descuento)
  SALARIO_COMERCIAL <- dbGetQuery(con, salario)
  PERSONAS_ADJUNTO <- dbGetQuery(con, adjunto)
  
  #CÁLCULO DEL NÚMERO DE HORAS EXTRA O DE VACACIONES QUE SE DEBEN COBRAR
    if (any(CONDICIONES_CONTRATO$COD_TIPO_CONDICION == 3)) {
      if (nrow(NOVEDADES_ADICION) != 0) {
          NOVEDADES_ADICION$HORAS_ED <- difftime(NOVEDADES_ADICION$FECHA_FIN_NOVEDAD, NOVEDADES_ADICION$FECHA_INICIO_NOVEDAD , units = "hours")
          NOVEDADES_ADICION$FACTOR_ED <- 1.25
          NOVEDADES_ADICION$HORAS_EN <- difftime(NOVEDADES_ADICION$FECHA_FIN_NOVEDAD, NOVEDADES_ADICION$FECHA_INICIO_NOVEDAD , units = "hours")
          NOVEDADES_ADICION$FACTOR_EN <- 1.75
          NOVEDADES_ADICION$HORAS_FD <- difftime(NOVEDADES_ADICION$FECHA_FIN_NOVEDAD, NOVEDADES_ADICION$FECHA_INICIO_NOVEDAD , units = "hours")
          NOVEDADES_ADICION$FACTOR_FD <- 2
          NOVEDADES_ADICION$HORAS_FN <- difftime(NOVEDADES_ADICION$FECHA_FIN_NOVEDAD, NOVEDADES_ADICION$FECHA_INICIO_NOVEDAD , units = "hours")
          NOVEDADES_ADICION$FACTOR_FN <- 2.5
          NOVEDADES_ADICION$HORAS_ED[(NOVEDADES_ADICION$COD_TIPO_NOVEDAD!=2)]<-0
          NOVEDADES_ADICION$HORAS_EN[(NOVEDADES_ADICION$COD_TIPO_NOVEDAD!=3)]<-0
          NOVEDADES_ADICION$HORAS_FD[(NOVEDADES_ADICION$COD_TIPO_NOVEDAD!=4)]<-0
          NOVEDADES_ADICION$HORAS_FN[(NOVEDADES_ADICION$COD_TIPO_NOVEDAD!=5)]<-0
      }} else {
      NOVEDADES_ADICION$HORAS_ED<-NULL
      NOVEDADES_ADICION$HORAS_EN<-NULL
      NOVEDADES_ADICION$HORAS_FD<-NULL
      NOVEDADES_ADICION$HORAS_FN<-NULL
      NOVEDADES_ADICION$FACTOR_ED<-NULL
      NOVEDADES_ADICION$FACTOR_EN<-NULL
      NOVEDADES_ADICION$FACTOR_FD<-NULL
      NOVEDADES_ADICION$FACTOR_FN<-NULL
      NOVEDADES_ADICION<-NOVEDADES_ADICION[-c(0),]
    } 
  
  if (any(CONDICIONES_CONTRATO$COD_TIPO_CONDICION == 4)) {
    if (nrow(NOVEDADES_DESCUENTO) != 0) {
      NOVEDADES_DESCUENTO$HORAS_DESCUENTO <- difftime(NOVEDADES_DESCUENTO$FECHA_FIN_NOVEDAD, NOVEDADES_DESCUENTO$FECHA_INICIO_NOVEDAD, units = "hours")
  }} else {
    NOVEDADES_DESCUENTO$HORAS_DESCUENTO<-NULL
    NOVEDADES_DESCUENTO<-NOVEDADES_DESCUENTO[-c(0),]}
  
  NOVEDADES_ADICION$ADICION_ED <- (NOVEDADES_ADICION$SALARIO_COMERCIAL / 240) * as.double(NOVEDADES_ADICION$HORAS_ED) * NOVEDADES_ADICION$FACTOR_ED
  NOVEDADES_ADICION$ADICION_EN <- (NOVEDADES_ADICION$SALARIO_COMERCIAL / 240) * as.double(NOVEDADES_ADICION$HORAS_EN) * NOVEDADES_ADICION$FACTOR_EN
  NOVEDADES_ADICION$ADICION_FD <- (NOVEDADES_ADICION$SALARIO_COMERCIAL / 240) * as.double(NOVEDADES_ADICION$HORAS_FD) * NOVEDADES_ADICION$FACTOR_FD
  NOVEDADES_ADICION$ADICION_FN <- (NOVEDADES_ADICION$SALARIO_COMERCIAL / 240) * as.double(NOVEDADES_ADICION$HORAS_FN) * NOVEDADES_ADICION$FACTOR_FN
  NOVEDADES_DESCUENTO$DESCUENTO <- (-NOVEDADES_DESCUENTO$SALARIO_COMERCIAL / 240) * as.double(NOVEDADES_DESCUENTO$HORAS_DESCUENTO)
  
  #CALCULO DE LOS VALORES TOTALES HISTORICOS A FACTURAR POR PERSONA E ITEM------------
  if (nrow(INGRESOS_PERSONAS) != 0) {
    TOTAL_PERSONAS <- aggregate(VALOR_FACTOR_MULTIPLICADOR ~ COD_FORMAS_PAGO_FECHAS +
                                  COD_CONTRATO_PROYECTO + COD_ROL + COD_CONCEPTO_PSL, data = INGRESOS_PERSONAS, sum)
  } else {
    TOTAL_PERSONAS <- cbind(INGRESOS_PERSONAS, replicate(0))
    PERSONAS_ADJUNTO <- cbind(INGRESOS_PERSONAS, replicate(0))
  }
  
  if (nrow(ITEMS_FIJOS) != 0) {
    TOTAL_ITEMS_FIJOS <- aggregate(VALOR_TOTAL ~ COD_FORMAS_PAGO_FECHAS + COD_CONTRATO_PROYECTO
                                   + COD_ITEM_CONTRATO + COD_CONCEPTO_PSL, data = ITEMS_FIJOS, sum)
  } else {
    TOTAL_ITEMS_FIJOS <- cbind(ITEMS_FIJOS, replicate(0))
  }
  
  if (nrow(ITEMS_VARIABLES) != 0) {
    TOTAL_ITEMS_VARIABLES <- aggregate(VALOR_TOTAL ~ COD_FORMAS_PAGO_FECHAS + COD_CONTRATO_PROYECTO
                                       + COD_ITEM_CONTRATO + COD_CONCEPTO_PSL, data = ITEMS_VARIABLES, sum)
  } else {
    TOTAL_ITEMS_VARIABLES <- cbind(ITEMS_VARIABLES, replicate(0))
  }
  
  if (nrow(TOTAL_PERSONAS) != 0) {
    
    if (nrow(NOVEDADES_ADICION) != 0) {
      TOTAL_NOVEDADES_ADICION <- aggregate(ADICION_ED+ADICION_EN+ADICION_FD+ADICION_FN ~ COD_ROL+COD_COLABORADOR+HORAS_ED+HORAS_EN+HORAS_FD+HORAS_FN,
                                           data = NOVEDADES_ADICION, sum)
      colnames(TOTAL_NOVEDADES_ADICION)[colnames(TOTAL_NOVEDADES_ADICION)=="ADICION_ED + ADICION_EN + ADICION_FD + ADICION_FN"] <- "ADICION"
      TOTAL_NOVEDADES_ADICION<- aggregate(TOTAL_NOVEDADES_ADICION[c("HORAS_ED","HORAS_EN","HORAS_FD","HORAS_FN","ADICION")], 
                         by = list(COD_COLABORADOR=TOTAL_NOVEDADES_ADICION$COD_COLABORADOR, COD_ROL=TOTAL_NOVEDADES_ADICION$COD_ROL), FUN="sum")
      TOTAL_PERSONAS <- merge(TOTAL_PERSONAS, TOTAL_NOVEDADES_ADICION, by.x = c("COD_ROL"), by.y = c("COD_ROL"), all.x = T, all.y = T, na.action)
      PERSONAS_ADJUNTO <- merge(PERSONAS_ADJUNTO, TOTAL_NOVEDADES_ADICION, by.x = c("COD_COLABORADOR"), by.y = c("COD_COLABORADOR"), all.x = T, all.y=F, na.action)
    } else {
      TOTAL_PERSONAS$ADICION <- NA
      PERSONAS_ADJUNTO$HORAS_ED<-0
      PERSONAS_ADJUNTO$HORAS_EN<-0
      PERSONAS_ADJUNTO$HORAS_FD<-0
      PERSONAS_ADJUNTO$HORAS_FN<-0
      PERSONAS_ADJUNTO$ADICION <- 0
    }
    
    if (nrow(NOVEDADES_DESCUENTO) != 0) {
      TOTAL_NOVEDADES_DESCUENTO <- aggregate(DESCUENTO ~ COD_ROL+COD_COLABORADOR+HORAS_DESCUENTO, data = NOVEDADES_DESCUENTO, sum)
      TOTAL_PERSONAS <- merge(TOTAL_PERSONAS, TOTAL_NOVEDADES_DESCUENTO, by.x = c("COD_ROL"), by.y = c("COD_ROL"), all.x = T, all.y = T, na.action)
      PERSONAS_ADJUNTO <- merge(PERSONAS_ADJUNTO, TOTAL_NOVEDADES_DESCUENTO, by.x = c("COD_COLABORADOR"), by.y = c("COD_COLABORADOR"), all.x = T, all.y = F, na.action)
    } else {
      TOTAL_PERSONAS$DESCUENTO <- NA
      PERSONAS_ADJUNTO$HORAS_DESCUENTO <- 0
      PERSONAS_ADJUNTO$DESCUENTO <- 0
    } 
    
    TOTAL_PERSONAS$FINAL <- as.double(rowSums(TOTAL_PERSONAS[, c("VALOR_FACTOR_MULTIPLICADOR", "ADICION", "DESCUENTO")], na.rm = T))
    PERSONAS_ADJUNTO$FINAL <- as.double(rowSums(PERSONAS_ADJUNTO[, c("VALOR_FACTOR_MULTIPLICADOR", "ADICION", "DESCUENTO")], na.rm = T))
  }
  
  PERSONAS_ADJUNTO[is.na(PERSONAS_ADJUNTO)]<-0
  TOTAL_PERSONAS[is.na(TOTAL_PERSONAS)]<-0
  
  #ELIMINAR LOS DATOS REPETIDOS DEL PROYECTO QUE SE ESTÁ CONSULTANDO
  eliminar <- paste0("DELETE FROM [dbo].[DETALLE_FACTURA_ADJUNTO_PERS] WHERE [COD_CONTRATO_PROYECTO] =", proyecto, "AND COD_FORMAS_PAGO_FECHAS=", fecha)
  dbExecute(con, eliminar)
  eliminar <- paste0("DELETE FROM [dbo].[DETALLE_FACTURA_ADJUNTO_ITEM] WHERE [COD_CONTRATO_PROYECTO] =", proyecto, "AND COD_FORMAS_PAGO_FECHAS=", fecha)
  dbExecute(con, eliminar)
  
  #CÁLCULO E INSERCIÓN DE LA INFORMACIÓN EN LAS TABLAS
  chunksize = 1000 # arbitrary chunk size
  
  if (nrow(PERSONAS_ADJUNTO) != 0) {
    for (i in 1:ceiling(nrow(PERSONAS_ADJUNTO) / chunksize)) {
      query = paste0("INSERT INTO [dbo].[DETALLE_FACTURA_ADJUNTO_PERS]
                     ([COD_CONTRATO_PROYECTO]
                     ,[COD_ROL]
                     ,[COD_COLABORADOR]
                     ,[COD_FORMAS_PAGO_FECHAS]
                     ,[FECHA_REGISTRO]
                     ,[USUARIO]
                     ,[COD_ESTADO_FACTURA]
                     ,[COD_CAUSA_ESTADO]
                     ,[OBSERVACIONES]
                     ,[COD_FACTURA]
                     ,[COD_ESTADO_DETALLE]
                     ,[COD_CONCEPTO_PSL]
                     ,[COD_GRUPO_FACTURA]
                     ,[HORAS_ED]
                     ,[HORAS_EN]
                     ,[HORAS_FD]
                     ,[HORAS_FN]
                     ,[ADICIONES]
                     ,[HORAS_AUSENCIA]
                     ,[DESCUENTO_AUSENCIA]
                     ,[FECHA_INI]
                     ,[FECHA_FIN]
                     ,[VALOR_DIAS_LAB]
                     ,[VALOR_SIN_IMPUESTOS])
                     VALUES")
      vals = NULL
      for (j in 1:chunksize) {
        k = (i - 1) * chunksize + j
        if (k <= nrow(PERSONAS_ADJUNTO)) {
          vals[j] = paste0('(', paste0(proyecto, ",",
                        if (is.null(PERSONAS_ADJUNTO$COD_ROL.x[k])) {if (is.null(PERSONAS_ADJUNTO$COD_ROL)) {1} else {PERSONAS_ADJUNTO$COD_ROL}} else {PERSONAS_ADJUNTO$COD_ROL.x[k]}, ",",
                          if (is.null(PERSONAS_ADJUNTO$COD_COLABORADOR[k])) {7} else {PERSONAS_ADJUNTO$COD_COLABORADOR[k]}, ",",
                            fecha, ",'",
                            Sys.time(), "','GENERADO',",
                            estado, ",1,'',", cod_factura, 
                            ",1,1026,1,",
                            PERSONAS_ADJUNTO$HORAS_ED[k],",",
                            PERSONAS_ADJUNTO$HORAS_EN[k],",",
                            PERSONAS_ADJUNTO$HORAS_FD[k],",",
                            PERSONAS_ADJUNTO$HORAS_FN[k],",",
                            PERSONAS_ADJUNTO$ADICION[k],",",
                            PERSONAS_ADJUNTO$HORAS_DESCUENTO[k],",",
                            PERSONAS_ADJUNTO$DESCUENTO[k],",'",
                            PERSONAS_ADJUNTO$FECHA_INI[k],"','",
                            PERSONAS_ADJUNTO$FECHA_FIN[k],"',",
                            PERSONAS_ADJUNTO$VALOR_FACTOR_MULTIPLICADOR[k],",",
                            PERSONAS_ADJUNTO$FINAL[k],
                            ")"), collapse = ',')
        }
      }
      query = paste0(query, paste0(vals, collapse = ','))
      dbExecute(con, query)
    }
  }
  
  dbDisconnect(con)
  
  VALOR_FACTURAR <- sum(TOTAL_ITEMS_FIJOS$VALOR_TOTAL, na.rm = T) + sum(TOTAL_PERSONAS$FINAL, na.rm = T) + sum(TOTAL_ITEMS_VARIABLES$VALOR_COMERCIAL, na.rm = T)
  
  #sum(TOTAL_ITEMS_FIJOS$VALOR_TOTAL, na.rm = T) 
  #sum(TOTAL_PERSONAS$VALOR_FACTOR_MULTIPLICADOR,na.rm = T)
  #sum(TOTAL_ITEMS_VARIABLES$VALOR_COMERCIAL,na.rm = T)
  #sum(NOVEDADES_ADICION$TOTAL,na.rm=T)
  #VALOR_FACTURAR
  return(VALOR_FACTURAR)
}

cod_facturas<-as.numeric(FACTURAS$COD_FACTURA)

for (f in cod_facturas) {
  factura(f)
}

factura(11079)
