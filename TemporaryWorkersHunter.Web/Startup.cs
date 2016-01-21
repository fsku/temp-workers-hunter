using Microsoft.Owin;
using Owin;
using TemporaryWorkersHunter.Web;

[assembly: OwinStartup(typeof(Startup))]
namespace TemporaryWorkersHunter.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
