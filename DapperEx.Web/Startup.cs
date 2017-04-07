using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DapperEx.Web.Startup))]
namespace DapperEx.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
