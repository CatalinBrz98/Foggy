using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Foggy.Startup))]
namespace Foggy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
