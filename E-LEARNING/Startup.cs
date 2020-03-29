using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(E_LEARNING.Startup))]
namespace E_LEARNING
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
