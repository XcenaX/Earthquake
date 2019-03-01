using Newtonsoft.Json;

namespace Models
{
    public class Feature
    {

        [JsonProperty("properties")]
        public Properties Properties { get; set; }
    }
}
