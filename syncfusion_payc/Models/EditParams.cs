using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using System;
using System.Collections.Generic;


namespace syncfusion_payc.Models
{
    public class ADICIONALES{
        public string CORREO_RESPONSABLE { get; set; }
        public string TELEFONO_RESPONSABLE { get; set; }
    }

    public class EditParams_AspNetUsers
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public AspNetUser value { get; set; }

        //Batch Edit Params
        public IEnumerable<AspNetUser> added { get; set; }
        public IEnumerable<AspNetUser> changed { get; set; }
        public IEnumerable<AspNetUser> deleted { get; set; }
    }


    /*public class EditParams_ROLES
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public ROLES value { get; set; }

        //Batch Edit Params
        public IEnumerable<ROLES> added { get; set; }
        public IEnumerable<ROLES> changed { get; set; }
        public IEnumerable<ROLES> deleted { get; set; }
    }

    public class EditParams_VISTA_DETALLE_ADJUNTOS_PERS
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public VISTA_DETALLE_ADJUNTOS_PERS value { get; set; }

        //Batch Edit Params
        public IEnumerable<VISTA_DETALLE_ADJUNTOS_PERS> added { get; set; }
        public IEnumerable<VISTA_DETALLE_ADJUNTOS_PERS> changed { get; set; }
        public IEnumerable<VISTA_DETALLE_ADJUNTOS_PERS> deleted { get; set; }
    }
    
    public class EditParams_ASIGNACION_CARTERA
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public ASIGNACION_CARTERA value { get; set; }

        //Batch Edit Params
        public IEnumerable<ASIGNACION_CARTERA> added { get; set; }
        public IEnumerable<ASIGNACION_CARTERA> changed { get; set; }
        public IEnumerable<ASIGNACION_CARTERA> deleted { get; set; }
    }

  
    public class EditParams_GESTION_CARTERA
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public GESTION_CARTERA value { get; set; }

        //Batch Edit Params
        public IEnumerable<GESTION_CARTERA> added { get; set; }
        public IEnumerable<GESTION_CARTERA> changed { get; set; }
        public IEnumerable<GESTION_CARTERA> deleted { get; set; }
    }
    public class EditParams_VISTA_GESTION_CARTERA
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public VISTA_GESTION_CARTERA value { get; set; }

        //Batch Edit Params
        public IEnumerable<VISTA_GESTION_CARTERA> added { get; set; }
        public IEnumerable<VISTA_GESTION_CARTERA> changed { get; set; }
        public IEnumerable<VISTA_GESTION_CARTERA> deleted { get; set; }
    }

    public class EditParams_VISTA_CARTERA_INDEX
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public VISTA_CARTERA_INDEX value { get; set; }

        //Batch Edit Params
        public IEnumerable<VISTA_CARTERA_INDEX> added { get; set; }
        public IEnumerable<VISTA_CARTERA_INDEX> changed { get; set; }
        public IEnumerable<VISTA_CARTERA_INDEX> deleted { get; set; }
    }

    public class EditParams_ITEMS_ROLES
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public ITEMS_ROLES value { get; set; }
        //Batch Edit Params
        public IEnumerable<ITEMS_ROLES> added { get; set; }
        public IEnumerable<ITEMS_ROLES> changed { get; set; }
        public IEnumerable<ITEMS_ROLES> deleted { get; set; }
    }


    public class EditParams_VISTA_ORDENES_CENTRO_COSTOS
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public VISTA_ORDENES_CENTRO_COSTOS value { get; set; }

        //Batch Edit Params
        public IEnumerable<VISTA_ORDENES_CENTRO_COSTOS> added { get; set; }
        public IEnumerable<VISTA_ORDENES_CENTRO_COSTOS> changed { get; set; }
        public IEnumerable<VISTA_ORDENES_CENTRO_COSTOS> deleted { get; set; }
    }

    public class EditParams_FACTURAS
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public FACTURAS value { get; set; }

        //Batch Edit Params
        public IEnumerable<FACTURAS> added { get; set; }
        public IEnumerable<FACTURAS> changed { get; set; }
        public IEnumerable<FACTURAS> deleted { get; set; }
    }

    public class EditParams_ITEMS
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public ITEMS value { get; set; }

        //Batch Edit Params
        public IEnumerable<ITEMS> added { get; set; }
        public IEnumerable<ITEMS> changed { get; set; }
        public IEnumerable<ITEMS> deleted { get; set; }
    }

    public class EditParams_VISTA_PENDIENTES_RETIRO
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public VISTA_PENDIENTES_RETIRO value { get; set; }

        //Batch Edit Params
        public IEnumerable<VISTA_PENDIENTES_RETIRO> added { get; set; }
        public IEnumerable<VISTA_PENDIENTES_RETIRO> changed { get; set; }
        public IEnumerable<VISTA_PENDIENTES_RETIRO> deleted { get; set; }
    }

    public class EditParams_CONTRATO_ROL_CARGO
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public CONTRATO_ROL_CARGO value { get; set; }

        //Batch Edit Params
        public IEnumerable<CONTRATO_ROL_CARGO> added { get; set; }
        public IEnumerable<CONTRATO_ROL_CARGO> changed { get; set; }
        public IEnumerable<CONTRATO_ROL_CARGO> deleted { get; set; }
    }

    public class EditParams_INCREMENTO_ORDEN
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public INCREMENTO_ORDEN value { get; set; }

        //Batch Edit Params
        public IEnumerable<INCREMENTO_ORDEN> added { get; set; }
        public IEnumerable<INCREMENTO_ORDEN> changed { get; set; }
        public IEnumerable<INCREMENTO_ORDEN> deleted { get; set; }
    }

    public class EditParams_INCREMENTO_SALARIAL
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public INCREMENTO_SALARIAL value { get; set; }

        //Batch Edit Params
        public IEnumerable<INCREMENTO_SALARIAL> added { get; set; }
        public IEnumerable<INCREMENTO_SALARIAL> changed { get; set; }
        public IEnumerable<INCREMENTO_SALARIAL> deleted { get; set; }
    }

    public class EditParams_CONTRATOS_CONDICIONES_VISTA
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public CONTRATOS_CONDICIONES_VISTA value { get; set; }

        //Batch Edit Params
        public IEnumerable<CONTRATOS_CONDICIONES_VISTA> added { get; set; }
        public IEnumerable<CONTRATOS_CONDICIONES_VISTA> changed { get; set; }
        public IEnumerable<CONTRATOS_CONDICIONES_VISTA> deleted { get; set; }
    }
    
    public class EditParams_COLABORADORES_CONCAT_ESTUDIOS
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public COLARADORES_CONCAT_ESTUDIOS value { get; set; }

        //Batch Edit Params
        public IEnumerable<COLARADORES_CONCAT_ESTUDIOS> added { get; set; }
        public IEnumerable<COLARADORES_CONCAT_ESTUDIOS> changed { get; set; }
        public IEnumerable<COLARADORES_CONCAT_ESTUDIOS> deleted { get; set; }
    }

    public class EditParams_CONTRATO_COLABORADOR_COMERCIAL
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public CONTRATO_COLABORADOR_COMERCIAL value { get; set; }

        //Batch Edit Params
        public IEnumerable<CONTRATO_COLABORADOR_COMERCIAL> added { get; set; }
        public IEnumerable<CONTRATO_COLABORADOR_COMERCIAL> changed { get; set; }
        public IEnumerable<CONTRATO_COLABORADOR_COMERCIAL> deleted { get; set; }
    }

    public class EditParams_TIPOS_NOVEDAD_CONDICION
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public TIPOS_NOVEDAD_CONDICION value { get; set; }

        //Batch Edit Params
        public IEnumerable<TIPOS_NOVEDAD_CONDICION> added { get; set; }
        public IEnumerable<TIPOS_NOVEDAD_CONDICION> changed { get; set; }
        public IEnumerable<TIPOS_NOVEDAD_CONDICION> deleted { get; set; }
    }

    public class EditParams_FLUJO_INGRESOS_ITEMS
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public FLUJO_INGRESOS_ITEMS value { get; set; }

        //Batch Edit Params
        public IEnumerable<FLUJO_INGRESOS_ITEMS> added { get; set; }
        public IEnumerable<FLUJO_INGRESOS_ITEMS> changed { get; set; }
        public IEnumerable<FLUJO_INGRESOS_ITEMS> deleted { get; set; }
    }

    public class EditParams_FLUJO_INGRESOS_ROL
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public FLUJO_INGRESOS_ROL value { get; set; }

        //Batch Edit Params
        public IEnumerable<FLUJO_INGRESOS_ROL> added { get; set; }
        public IEnumerable<FLUJO_INGRESOS_ROL> changed { get; set; }
        public IEnumerable<FLUJO_INGRESOS_ROL> deleted { get; set; }
    }

    public class EditParams_ACUERDOS_PAGO_ENTREGAB
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public ACUERDOS_PAGO_ENTREGAB value { get; set; }

        //Batch Edit Params
        public IEnumerable<ACUERDOS_PAGO_ENTREGAB> added { get; set; }
        public IEnumerable<ACUERDOS_PAGO_ENTREGAB> changed { get; set; }
        public IEnumerable<ACUERDOS_PAGO_ENTREGAB> deleted { get; set; }
    }

    public class EditParams_PROYECTOS
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public PROYECTOS value { get; set; }

        //Batch Edit Params
        public IEnumerable<PROYECTOS> added { get; set; }
        public IEnumerable<PROYECTOS> changed { get; set; }
        public IEnumerable<PROYECTOS> deleted { get; set; }
    }

    public class EditParams_CONTRATOS_ROL
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public CONTRATOS_ROL value { get; set; }

        //Batch Edit Params
        public IEnumerable<CONTRATOS_ROL> added { get; set; }
        public IEnumerable<CONTRATOS_ROL> changed { get; set; }
        public IEnumerable<CONTRATOS_ROL> deleted { get; set; }
    }
   
    public class EditParams_CONTRATO_COLABORADOR
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public CONTRATO_COLABORADOR value { get; set; }

        //Batch Edit Params
        public IEnumerable<CONTRATO_COLABORADOR> added { get; set; }
        public IEnumerable<CONTRATO_COLABORADOR> changed { get; set; }
        public IEnumerable<CONTRATO_COLABORADOR> deleted { get; set; }
    }

    public class EditParams_CLIENTES
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public CLIENTES value { get; set; }

        //Batch Edit Params
        public IEnumerable<CLIENTES> added { get; set; }
        public IEnumerable<CLIENTES> changed { get; set; }
        public IEnumerable<CLIENTES> deleted { get; set; }
    }

    public class EditParams_COLABORADORES
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public COLABORADORES value { get; set; }

        //Batch Edit Params
        public IEnumerable<COLABORADORES> added { get; set; }
        public IEnumerable<COLABORADORES> changed { get; set; }
        public IEnumerable<COLABORADORES> deleted { get; set; }
    }

    public class EditParams_TIPOS_NOVEDAD
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public TIPOS_NOVEDAD value { get; set; }

        //Batch Edit Params
        public IEnumerable<TIPOS_NOVEDAD> added { get; set; }
        public IEnumerable<TIPOS_NOVEDAD> changed { get; set; }
        public IEnumerable<TIPOS_NOVEDAD> deleted { get; set; }
    }

    public class EditParams_CONTRATOS
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public CONTRATOS value { get; set; }

        //Batch Edit Params
        public IEnumerable<CONTRATOS> added { get; set; }
        public IEnumerable<CONTRATOS> changed { get; set; }
        public IEnumerable<CONTRATOS> deleted { get; set; }
    }

    public class EditParams_FORMAS_PAGO
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public FORMAS_PAGO value { get; set; }

        //Batch Edit Params
        public IEnumerable<FORMAS_PAGO> added { get; set; }
        public IEnumerable<FORMAS_PAGO> changed { get; set; }
        public IEnumerable<FORMAS_PAGO> deleted { get; set; }
    }

    public class EditParams_TIPO_CONDICION_CONTRACTUAL
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public TIPO_CONDICION_CONTRACTUAL value { get; set; }

        //Batch Edit Params
        public IEnumerable<TIPO_CONDICION_CONTRACTUAL> added { get; set; }
        public IEnumerable<TIPO_CONDICION_CONTRACTUAL> changed { get; set; }
        public IEnumerable<TIPO_CONDICION_CONTRACTUAL> deleted { get; set; }
    }
    
    public class EditParams_CONTRATOS_CONDICIONES
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public CONTRATOS_CONDICIONES value { get; set; }

        //Batch Edit Params
        public IEnumerable<CONTRATOS_CONDICIONES> added { get; set; }
        public IEnumerable<CONTRATOS_CONDICIONES> changed { get; set; }
        public IEnumerable<CONTRATOS_CONDICIONES> deleted { get; set; }
    }

    public class EditParams_DETALLE_FACTURA_ITEM
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public DETALLE_FACTURA_ITEM value { get; set; }

        //Batch Edit Params
        public IEnumerable<DETALLE_FACTURA_ITEM> added { get; set; }
        public IEnumerable<DETALLE_FACTURA_ITEM> changed { get; set; }
        public IEnumerable<DETALLE_FACTURA_ITEM> deleted { get; set; }
    }

    public class EditParams_DETALLE_FACTURA_PERS
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public DETALLE_FACTURA_PERS value { get; set; }

        //Batch Edit Params
        public IEnumerable<DETALLE_FACTURA_PERS> added { get; set; }
        public IEnumerable<DETALLE_FACTURA_PERS> changed { get; set; }
        public IEnumerable<DETALLE_FACTURA_PERS> deleted { get; set; }
    }

    public class EditParams_FORMAS_PAGO_FECHAS
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public FORMAS_PAGO_FECHAS value { get; set; }

        //Batch Edit Params
        public IEnumerable<FORMAS_PAGO_FECHAS> added { get; set; }
        public IEnumerable<FORMAS_PAGO_FECHAS> changed { get; set; }
        public IEnumerable<FORMAS_PAGO_FECHAS> deleted { get; set; }
    }
    
    public class EditParams_ITEMS_CONTRATO
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public ITEMS_CONTRATO value { get; set; }

        //Batch Edit Params
        public IEnumerable<ITEMS_CONTRATO> added { get; set; }
        public IEnumerable<ITEMS_CONTRATO> changed { get; set; }
        public IEnumerable<ITEMS_CONTRATO> deleted { get; set; }
    }

    public class EditParams_REGISTRO_ITEMS_OTROS_COSTOS
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public REGISTRO_ITEMS_OTROS_COSTOS value { get; set; }

        //Batch Edit Params
        public IEnumerable<REGISTRO_ITEMS_OTROS_COSTOS> added { get; set; }
        public IEnumerable<REGISTRO_ITEMS_OTROS_COSTOS> changed { get; set; }
        public IEnumerable<REGISTRO_ITEMS_OTROS_COSTOS> deleted { get; set; }
    }

    public class EditParams_REGISTRO_NOVEDADES
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public REGISTRO_NOVEDADES value { get; set; }

        //Batch Edit Params
        public IEnumerable<REGISTRO_NOVEDADES> added { get; set; }
        public IEnumerable<REGISTRO_NOVEDADES> changed { get; set; }
        public IEnumerable<REGISTRO_NOVEDADES> deleted { get; set; }
    }

    public class EditParams_CONTRATO_PROYECTO
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public CONTRATO_PROYECTO value { get; set; }

        //Batch Edit Params
        public IEnumerable<CONTRATO_PROYECTO> added { get; set; }
        public IEnumerable<CONTRATO_PROYECTO> changed { get; set; }
        public IEnumerable<CONTRATO_PROYECTO> deleted { get; set; }
    }

    public class EditParams_ESTUDIOS_COLABORADOR
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public ESTUDIOS_COLABORADOR value { get; set; }

        //Batch Edit Params
        public IEnumerable<ESTUDIOS_COLABORADOR> added { get; set; }
        public IEnumerable<ESTUDIOS_COLABORADOR> changed { get; set; }
        public IEnumerable<ESTUDIOS_COLABORADOR> deleted { get; set; }
    }

    public class EditParams_CARGOS
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public CARGOS value { get; set; }

        //Batch Edit Params
        public IEnumerable<CARGOS> added { get; set; }
        public IEnumerable<CARGOS> changed { get; set; }
        public IEnumerable<CARGOS> deleted { get; set; }
    }

    public class EditParams_CARTERA
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public CARTERA value { get; set; }

        //Batch Edit Params
        public IEnumerable<CARTERA> added { get; set; }
        public IEnumerable<CARTERA> changed { get; set; }
        public IEnumerable<CARTERA> deleted { get; set; }
    }

    /*public class EditParams_FACTURAS
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public FACTURAS value { get; set; }

        //Batch Edit Params
        public IEnumerable<FACTURAS> added { get; set; }
        public IEnumerable<FACTURAS> changed { get; set; }
        public IEnumerable<FACTURAS> deleted { get; set; }
    }*/

    /*public class EditParams_COMPROMISOS_PAGO
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public COMPROMISOS_PAGO value { get; set; }

        //Batch Edit Params
        public IEnumerable<COMPROMISOS_PAGO> added { get; set; }
        public IEnumerable<COMPROMISOS_PAGO> changed { get; set; }
        public IEnumerable<COMPROMISOS_PAGO> deleted { get; set; }
    }

    public class EditParams_GESTION_CARTERA
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public GESTION_CARTERA value { get; set; }

        //Batch Edit Params
        public IEnumerable<GESTION_CARTERA> added { get; set; }
        public IEnumerable<GESTION_CARTERA> changed { get; set; }
        public IEnumerable<GESTION_CARTERA> deleted { get; set; }
    }

    public class EditParams_COMPROMISOS_ENTREGABLES
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public COMPROMISOS_ENTREGABLES value { get; set; }

        //Batch Edit Params
        public IEnumerable<COMPROMISOS_ENTREGABLES> added { get; set; }
        public IEnumerable<COMPROMISOS_ENTREGABLES> changed { get; set; }
        public IEnumerable<COMPROMISOS_ENTREGABLES> deleted { get; set; }
    }

    public class EditParams_ENTREGABLES
    {
        public int skip { get; set; }
        public int take { get; set; }
        public string action { get; set; }
        public int key { get; set; }
        public string keyColumn { get; set; }
        public ENTREGABLES value { get; set; }

        //Batch Edit Params
        public IEnumerable<ENTREGABLES> added { get; set; }
        public IEnumerable<ENTREGABLES> changed { get; set; }
        public IEnumerable<ENTREGABLES> deleted { get; set; }
    }*/


}