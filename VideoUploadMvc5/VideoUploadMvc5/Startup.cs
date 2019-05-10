using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VideoUploadMvc5.Startup))]
namespace VideoUploadMvc5
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
