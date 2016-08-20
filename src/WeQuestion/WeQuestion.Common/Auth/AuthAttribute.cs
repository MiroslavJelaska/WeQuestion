using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WeQuestion.Common.Auth
{
    public class AllowRole : ActionFilterAttribute
    {
        public UserRoleType Role { get; set; }
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var bearerTokenString = JwtUtility.ReadBearerTokenFromHeader(actionContext.Request.Headers);
            if (!JwtUtility.IsValid(bearerTokenString))
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                return;
            }

            var token = new JwtAdapter(bearerTokenString);
            if (token.Role != Role)
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
                return;
            }

            base.OnActionExecuting(actionContext);
        }
    }
}
