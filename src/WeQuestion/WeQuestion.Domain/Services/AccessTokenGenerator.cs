using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WeQuestion.Domain.Services
{
    public class AccessTokenGenerator
    {
        public AccessTokenGenerator()
        {
            var appDataPath = Path.Combine(HttpRuntime.AppDomainAppPath, "App_Data");
            var mostFrequentNounsFolderPath = Path.Combine(appDataPath, "mostFrequentNouns.json");
            using (var mostFrequentNounsJsonReader = new StreamReader(mostFrequentNounsFolderPath))
            {
                var json = mostFrequentNounsJsonReader.ReadToEnd();
                _mostFrequentNouns = 
                    JsonConvert.DeserializeObject<List<string>>(json)
                    .Select(noun => noun.First().ToString().ToUpper() + noun.Substring(1))
                    .ToList();
            }
            _random = new Random();
        }
        private List<string> _mostFrequentNouns { get; }
        private Random       _random { get; }

        public string Generate()
        {
            return GetRandomNoun() + GetRandomNoun();
        }

        private string GetRandomNoun()
        {
            return _mostFrequentNouns[_random.Next(_mostFrequentNouns.Count)];
        }
    }
}
