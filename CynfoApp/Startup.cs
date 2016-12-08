using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CynfoApp.Startup))]
namespace CynfoApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            System.Console.WriteLine("Hello");
        }
    }
}
