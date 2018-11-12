using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Get_SetterService.Startup))]

namespace Get_SetterService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}