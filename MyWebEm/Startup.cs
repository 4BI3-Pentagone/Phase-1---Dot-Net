using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyWebEm.Startup))]
namespace MyWebEm
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
