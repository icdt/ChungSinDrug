using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChungSinDrug.Startup))]
namespace ChungSinDrug
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
