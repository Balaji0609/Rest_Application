using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(wesiteApp.Startup))]
namespace wesiteApp
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
