using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GoGoPowerRangers.ENET.Startup))]
namespace GoGoPowerRangers.ENET
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
