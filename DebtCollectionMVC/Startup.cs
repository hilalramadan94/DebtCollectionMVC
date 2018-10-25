using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DebtCollectionMVC.Startup))]
namespace DebtCollectionMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
