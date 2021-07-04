using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace Koesell.Identity
{
    public class IdentityInitializer : CreateDatabaseIfNotExists<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            if(!context.Roles.Any(i=>i.Name=="admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "admin", Description = "Yönetici" };
                manager.Create(role);
            }
            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "user", Description = "Kullanıcı" };
                manager.Create(role);
            }
            if (!context.Users.Any(i => i.Name == "maliask"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "Muhammet Ali", Surname = "Aşık", UserName = "maliask", Email = "maliask06@gmail.com", PhoneNumber="05000000000" };
                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "admin");
                manager.AddToRole(user.Id, "user");
            }
            if (!context.Users.Any(i => i.Email == "betulask06@gmail.com"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() 
                { Name = "Betül", Surname = "Aşık", UserName = "betulask", Email = "betulask06@gmail.com", PhoneNumber = "05000000000" };
                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "user");
            }
            base.Seed(context);
        }
    }
}