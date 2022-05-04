using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AnkhMorporkMVC.Startup))]
namespace AnkhMorporkMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
