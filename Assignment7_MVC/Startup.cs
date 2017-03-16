using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Assignment7_MVC.Startup))]
namespace Assignment7_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
