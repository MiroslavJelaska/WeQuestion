using System;
using System.Collections.Generic;
using FluentAssertions;
using Jose;

namespace WeQuestion.Common.Auth
{
    public class JwtAdapter
    {
        public JwtAdapter(string bearerToken)
        {
            JwtUtility.IsValid(bearerToken).Should().BeTrue();

            var payloadAsDictionary = JWT.Decode<Dictionary<string, string>>(bearerToken, ConfigReader.AuthSecretKeyByteArray);

            Role     = (UserRoleType) Enum.Parse(typeof (UserRoleType), payloadAsDictionary["role"]);
            Iat      = long.Parse(payloadAsDictionary["iat"]);
            Fullname = payloadAsDictionary["fullname"];
            Email    = payloadAsDictionary["email"];
            Id       = int.Parse(payloadAsDictionary["id"]);
        }

        public UserRoleType Role { get; }
        public long Iat { get; }
        public string Fullname { get; }
        public string Email { get; }
        public int Id { get; }
    }
}
