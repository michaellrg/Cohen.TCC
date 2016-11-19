using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Cohen.TCC.Web.Startup))]
namespace Cohen.TCC.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
