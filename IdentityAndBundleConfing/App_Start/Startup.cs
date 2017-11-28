using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartup(typeof(IdentityAndBundleConfing.App_Start.Startup))]

namespace IdentityAndBundleConfing.App_Start
{
    public class Startup
    {
        public string AuthenticationType { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/Account/Login")
            });
        }
    }
}
