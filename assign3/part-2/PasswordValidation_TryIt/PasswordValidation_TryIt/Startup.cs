using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PasswordValidation_TryIt.Startup))]
namespace PasswordValidation_TryIt
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
