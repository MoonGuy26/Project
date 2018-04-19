using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BeanifyManagementWebApp.Startup))]
namespace BeanifyManagementWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
