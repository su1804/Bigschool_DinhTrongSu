using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Bigschool_DinhTrongSu.Startup))]
namespace Bigschool_DinhTrongSu
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
