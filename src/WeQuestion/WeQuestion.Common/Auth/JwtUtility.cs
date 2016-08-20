using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using Jose;
using Microsoft.Owin;

namespace WeQuestion.Common.Auth
{
    public static class JwtUtility
    {
        public static bool IsValid(string bearerToken)
        {
            try
            {
                JWT.Decode<Dictionary<string, string>>(bearerToken, ConfigReader.AuthSecretKeyByteArray);
                return true;
            }
            catch (Exception)
            {
                // Incoming token invalid.
                // Incoming token expected to be in compact serialization form, not empty, whitespace or null.
                return false;
            }
        }

        public static string ReadBearerTokenFromHeader(IHeaderDictionary headerDictionary)
        {
            return headerDictionary.Get("Authorization")?.Split(' ')[1];
        }
        public static string ReadBearerTokenFromHeader(HttpRequestHeaders header)
        {
            IEnumerable<string> values;
            header.TryGetValues("Authorization", out values);
            return values?.First()?.Split(' ')[1];
        }
    }
}
