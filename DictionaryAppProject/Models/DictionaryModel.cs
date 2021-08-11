using Newtonsoft.Json;
using System.Collections.Generic;

namespace DictionaryAppProject
{
    public class Meta
    {
        [JsonProperty("syns")]
        public List<List<string>> syns { get; set; }
        
        [JsonProperty("ants")]
        public List<List<string>> ants { get; set; }
    }

    public class Root
    {
        [JsonProperty("meta")]
        public Meta meta { get; set; }

        [JsonProperty("fl")]
        public string fl { get; set; }

        [JsonProperty("shortdef")]
        public List<string> shortdef { get; set; }
    }
}
