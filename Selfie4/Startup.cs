using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Selfie4.Startup))]
namespace Selfie4
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
