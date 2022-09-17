using Microsoft.AspNet.Identity.EntityFramework; // for :IdentityDbContext
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace e_commerce_internship.Identity
{
    public class IdentityDataContext:IdentityDbContext<ApplicationUser>
    {
        public IdentityDataContext():base("IdentityConnection") //web.configde belirlediğim isim
        {
            Database.SetInitializer(new IdentityInitilazier()); //Identity klasöründe bir class
        }
    }
}