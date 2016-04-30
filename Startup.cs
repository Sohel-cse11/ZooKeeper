using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AnimalManager.Startup))]
namespace AnimalManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
