using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Formule1.Startup))]
namespace Formule1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
