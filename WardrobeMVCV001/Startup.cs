using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WardrobeMVCV001.Startup))]
namespace WardrobeMVCV001
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
