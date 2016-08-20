using Microsoft.Owin;
using Owin;
using WeQuestion.Common.Auth;
using WeQuestion.Web;

[assembly: OwinStartup(typeof(Startup))]

namespace WeQuestion.Web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseBlockRequestWithInvalidBearerToken(
                new BlockRequestWithInvalidBearerTokenOwinMiddleware.Options
                {
                    ErrorCode = "101",
                    ErrorMessage = "Token is invalid."
                });
        }
    }
}
