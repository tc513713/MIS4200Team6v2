using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Test_Project.Startup))]
namespace Test_Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
