using System;
using System.Web.Http;

namespace WeQuestion.Common.Auth
{
    public abstract class AuthorizedApiController : ApiController
    {
        protected AuthorizedApiController()
        {
            _bearerToken = new Lazy<JwtAdapter>(() =>
            {
                var jwtString = JwtUtility.ReadBearerTokenFromHeader(Request.Headers);
                return new JwtAdapter(jwtString);
            });
        }
        private readonly Lazy<JwtAdapter> _bearerToken;
        public JwtAdapter AuthDetails =>_bearerToken.Value;
    }
}
