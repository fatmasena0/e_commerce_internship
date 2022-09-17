using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(e_commerce_internship.App_Start.Startup1))]

namespace e_commerce_internship.App_Start
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            // Uygulamanızı nasıl yapılandıracağınız hakkında daha fazla bilgi için https://go.microsoft.com/fwlink/?LinkId=316888 adresini ziyaret edin
            app.UseCookieAuthentication(new Microsoft.Owin.Security.Cookies.CookieAuthenticationOptions
            {
                AuthenticationType= "ApplicationCookie", LoginPath= new PathString("/Account/Login")//controller: Account, action: Login
            });
        }
    }
}
