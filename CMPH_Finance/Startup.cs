using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CMPH_Finance.Startup))]
namespace CMPH_Finance
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
