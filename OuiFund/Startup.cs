using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OuiFund.Startup))]
namespace OuiFund
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
