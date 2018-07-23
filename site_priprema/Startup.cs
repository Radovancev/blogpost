using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(site_priprema.Startup))]
namespace site_priprema
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
