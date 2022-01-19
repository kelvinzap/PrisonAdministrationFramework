using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PrisonAdministrationSystem.Startup))]
namespace PrisonAdministrationSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
