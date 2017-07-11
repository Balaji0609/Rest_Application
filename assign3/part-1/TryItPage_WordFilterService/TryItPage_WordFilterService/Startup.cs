using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TryItPage_WordFilterService.Startup))]
namespace TryItPage_WordFilterService
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
