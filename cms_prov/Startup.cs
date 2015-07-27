using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(cms_prov.Startup))]
namespace cms_prov
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
