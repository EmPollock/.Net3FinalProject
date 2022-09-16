using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCPresntationLayer.Startup))]
namespace MVCPresntationLayer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
