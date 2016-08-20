using System.Text;
using Jose;
using Microsoft.Extensions.Configuration;

namespace WeQuestion.Common
{
    public static class ConfigReader
    {
        static ConfigReader()
        {
            _configuration =
                new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }

        private static readonly IConfigurationRoot _configuration;

        public static string AuthSecretKeyPlaintext => _configuration["AuthSecretKey"];
        public static byte[] AuthSecretKeyByteArray => Encoding.UTF8.GetBytes(AuthSecretKeyPlaintext);
        public static JwsAlgorithm JwsAlgorithm => (JwsAlgorithm)int.Parse(_configuration["JwsAlgorithm"]);
    }
}
