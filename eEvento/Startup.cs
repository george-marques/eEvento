using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(eEvento.Startup))]
namespace eEvento
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
