using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_Pilkarzyki_DBFirst.Startup))]
namespace MVC_Pilkarzyki_DBFirst
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
