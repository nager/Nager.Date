using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Nager.Date.Website.Startup))]
namespace Nager.Date.Website
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
