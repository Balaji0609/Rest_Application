using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EncryptionDecryption_TryIt.Startup))]
namespace EncryptionDecryption_TryIt
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
