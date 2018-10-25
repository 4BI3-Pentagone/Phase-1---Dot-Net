using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WEBB.Startup))]
namespace WEBB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
