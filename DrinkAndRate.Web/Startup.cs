using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DrinkAndRate.Web.Startup))]
namespace DrinkAndRate.Web
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
