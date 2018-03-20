using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IB2B.Localizacion.UI.Startup))]
namespace IB2B.Localizacion.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
