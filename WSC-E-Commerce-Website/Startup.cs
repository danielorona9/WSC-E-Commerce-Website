using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WSC_E_Commerce_Website.Startup))]
namespace WSC_E_Commerce_Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
