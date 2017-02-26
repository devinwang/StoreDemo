using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RefactorMe.Startup))]
namespace RefactorMe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
