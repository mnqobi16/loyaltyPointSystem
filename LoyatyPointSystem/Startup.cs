using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LoyatyPointSystem.Startup))]
namespace LoyatyPointSystem
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
