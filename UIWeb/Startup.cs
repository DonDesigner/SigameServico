using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UIWeb.Startup))]
namespace UIWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
