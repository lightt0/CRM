using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CRM.Presentation.Startup))]
namespace CRM.Presentation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
