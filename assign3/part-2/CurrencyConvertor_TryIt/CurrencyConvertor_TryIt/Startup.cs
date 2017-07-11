using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CurrencyConvertor_TryIt.Startup))]
namespace CurrencyConvertor_TryIt
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
