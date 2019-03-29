#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using syncfusion_payc.Models;

using System.Security.Claims;

[assembly: OwinStartupAttribute(typeof(syncfusion_payc.Startup))]
namespace syncfusion_payc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            createRolesandUsers();
        }
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // Se crea el usuario y rol admin
            if (!roleManager.RoleExists("Admin"))
            {

                // Se crea el rol admin
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Se crea el usuario administrador                  

                var user = new ApplicationUser();
                user.UserName = "sa";
                user.Email = "sa@gmail.com";

                string userPWD = "1234Jams*";

                var chkUser = UserManager.Create(user, userPWD);

                //Crear Usuario Admin 
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");

                }
            }

            //  Crear rol calificador 
            if (!roleManager.RoleExists("Calificador"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Calificador";
                roleManager.Create(role);

            }

            // Crear rol revisor calificación
            if (!roleManager.RoleExists("Revisor_Calificaciones"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Revisor_Calificaciones";
                roleManager.Create(role);

            }
            // Crear rol usuario externo (para el registro externo)
            if (!roleManager.RoleExists("Usuario_Externo"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Usuario_Externo";
                roleManager.Create(role);

            }
            // Crear rol Directivo
            if (!roleManager.RoleExists("Directivo"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Directivo";
                roleManager.Create(role);

            }
            // Crear rol test
            if (!roleManager.RoleExists("test"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "TestRole";
                roleManager.Create(role);

            }


        }
    }
}
