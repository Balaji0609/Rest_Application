using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CreditCardValidation_TryIt.Startup))]
namespace CreditCardValidation_TryIt
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
