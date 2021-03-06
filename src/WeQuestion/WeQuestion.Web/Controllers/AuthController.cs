﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using Jose;
using Newtonsoft.Json.Linq;
using WeQuestion.Common;
using WeQuestion.Common.Auth;
using WeQuestion.Data;

namespace WeQuestion.Web.Controllers
{
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

            var bearerToken = _generateJwt(UserRoleType.Admin, user.Id);

            return Ok(bearerToken);
        }

        [HttpPost]
        [Route("login-anonymously")]
        public IHttpActionResult LoginAnonymously()
        {
            var bearerToken = _generateJwt(UserRoleType.Anonymous, Guid.NewGuid());

            return Ok(bearerToken);
        }

        private static string _generateJwt(UserRoleType role, Guid id)
        {
            var timestamp = DateTimeOffset.UtcNow.Ticks;
            var payload = new Dictionary<string, string>()
            {
                { "role", ((int)role).ToString() },
                { "iat", timestamp.ToString() },
                { "id", id.ToString("D") }
            };

            return JWT.Encode(payload, ConfigReader.AuthSecretKeyByteArray, JwsAlgorithm.HS256);
        }
    }
}
