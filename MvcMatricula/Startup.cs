using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcMatricula.Startup))]
namespace MvcMatricula
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
