using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using e_commerce_internship.Entity;
using Microsoft.AspNet.Identity.EntityFramework; //RoleStore
using Microsoft.AspNet.Identity; //Rolemanager

namespace e_commerce_internship.Identity
{
    public class IdentityInitilazier:CreateDatabaseIfNotExists<IdentityDataContext> //veritabanı yoksa yeni bir vt oluşturur
    {
        protected override void Seed(IdentityDataContext context)
        {
            if (!context.Roles.Any(i => i.Name == "admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "admin", Description = "Admin Rolü" };
                manager.Create(role);
            }
            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "user", Description = "User Rolü" };
                manager.Create(role);
            }
            if (!context.Users.Any(i => i.Name == "fatmasena"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "Fatma", Surname="Sena", UserName="fatmasena", Email="fsa652@gmail.com"};
                manager.Create(user, "FatmaSifre");
                manager.AddToRole(user.Id, "admin");
                manager.AddToRole(user.Id, "user");
            }
            if (!context.Users.Any(i => i.Name == "silaakca"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "Sıla", Surname = "Akça", UserName = "silaakca", Email = "fsa27fsa@gmail.com" };
                manager.Create(user, "SilaSifre");
                manager.AddToRole(user.Id, "user");
            }
            base.Seed(context);
        }

    }
}