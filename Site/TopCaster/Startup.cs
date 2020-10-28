using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TopCaster.Startup))]
namespace TopCaster

{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
