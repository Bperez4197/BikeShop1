using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BikeShop1.Startup))]
namespace BikeShop1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
