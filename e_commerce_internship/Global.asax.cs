using e_commerce_internship.Entity;
using e_commerce_internship.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace e_commerce_internship
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start() //Uygulama ilk açıldığında gerçekleşecek olayları yönetmek için kullanılır
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Database.SetInitializer(new DataInitilazier()); //Identity klasöründe bir class
            Database.SetInitializer(new IdentityInitilazier()); //Identity klasöründe bir class
        }
    }
}
