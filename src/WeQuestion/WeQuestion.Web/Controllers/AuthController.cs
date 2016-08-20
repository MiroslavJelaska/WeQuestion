using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Jose;
using Newtonsoft.Json.Linq;
using WeQuestion.Common;
using WeQuestion.Data;

namespace WeQuestion.Web.Controllers
{
    enum RoleType
    {
        Admin = 1,
        Anonymous = 2
    }
    [RoutePrefix("api/auth")]
    public class AuthController : ApiController
    {
        public AuthController(
            WeQuestionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly WeQuestionDbContext _dbContext;

        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login([FromBody] JObject jsonObject)
        {
            var email = jsonObject["email"].ToObject<string>();
            var password = jsonObject["password"].ToObject<string>();

            var user = _dbContext.Users.SingleOrDefault(_ => _.Email == email);
            if (user == null) return NotFound();

            var areCredentialsValid = PasswordHashing.Validate(password, user.Password);
            if(!areCredentialsValid) return new ResponseMessageResult(Request.CreateResponse((HttpStatusCode)601));

            var timestamp = DateTimeOffset.UtcNow.Ticks;
            var payload = new Dictionary<string, string>()
            {
                { "role", ((int)RoleType.Admin).ToString() },
                { "iat", timestamp.ToString() },
                { "email", user.Email },
                { "id", user.Id.ToString() }
            };

            var token = JWT.Encode(payload, ConfigReader.AuthSecretKeyByteArray, JwsAlgorithm.HS256);

            return Ok(token);
        }

        [HttpPost]
        [Route("login-anonymously")]
        public IHttpActionResult LoginAnonymously()
        {
            var timestamp = DateTimeOffset.UtcNow.Ticks;
            var payload = new Dictionary<string, string>()
            {
                { "role", ((int)RoleType.Anonymous).ToString() },
                { "iat", timestamp.ToString() },
                { "id", new Guid().ToString() }
            };

            var token = JWT.Encode(payload, ConfigReader.AuthSecretKeyByteArray, JwsAlgorithm.HS256);

            return Ok(token);
        }
    }
}
