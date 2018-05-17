using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using BeanifyWebApp.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(BeanifyWebApp.Startup))]

namespace BeanifyWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesandUsers();
        }


        private void CreateRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            if (!roleManager.RoleExists("Admin"))
            {

                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);


                
                

            }
            var user = new ApplicationUser { Name = "Arthur Tronche" };
            
            user.UserName = "arthur.tronche@gmail.com";
            user.Email = "arthur.tronche@gmail.com";

            string userPWD = "Test123==";

            var chkUser = UserManager.Create(user, userPWD);

            if (chkUser.Succeeded)
            {
                var result1 = UserManager.AddToRole(user.Id, "Admin");

            }

            if (!roleManager.RoleExists("Manager"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);

            }

            if (!roleManager.RoleExists("CommonUser"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "CommonUser";
                roleManager.Create(role);

            }
        }
    }
}
