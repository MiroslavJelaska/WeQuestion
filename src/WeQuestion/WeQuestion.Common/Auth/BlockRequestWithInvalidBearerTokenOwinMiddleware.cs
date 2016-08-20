using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

namespace WeQuestion.Common.Auth
{
    public class BlockRequestWithInvalidBearerTokenOwinMiddleware : OwinMiddleware
    {
        public class Options
        {
            public string ErrorCode { get; set; }
            public string ErrorMessage { get; set; }

            public string GetErrorResponseJson()
            {
                var json = new Dictionary<string, object>();

                if (ErrorCode != null)
                    json.Add("code", ErrorCode);

                if (ErrorMessage != null)
                    json.Add("message", ErrorMessage);

                return Newtonsoft.Json.JsonConvert.SerializeObject(json);
            }
        }

        public BlockRequestWithInvalidBearerTokenOwinMiddleware(
            OwinMiddleware next,
            Options options
            ) : base(next)
        {
            _options = options;
        }

        private readonly Options _options;

        public override Task Invoke(IOwinContext context)
        {
            var bearerToken = JwtUtility.ReadBearerTokenFromHeader(context.Request.Headers);

            if (bearerToken == null)
                return Next.Invoke(context);

            if (JwtUtility.IsValid(bearerToken))
                return Next.Invoke(context);

            context.Response.StatusCode = 401;
            context.Response.ContentType = "text/json";
            return context.Response.WriteAsync(_options.GetErrorResponseJson());
        }
    }
    public static class BlockRequestWithInvalidBearerTokenOwinMiddlewareHelpers
    {
        public static void UseBlockRequestWithInvalidBearerToken(
          this IAppBuilder app,
          BlockRequestWithInvalidBearerTokenOwinMiddleware.Options options)
        {
            app.Use<BlockRequestWithInvalidBearerTokenOwinMiddleware>(options);
        }
    }
}
