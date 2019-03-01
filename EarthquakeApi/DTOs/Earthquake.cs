using Newtonsoft.Json;
using System.Collections.Generic;

namespace Models
{
    public class Earthquake
    {
        [JsonProperty("metadata")]
        public Metadata Metadata { get; set; }

        [JsonProperty("features")]
        public IList<Feature> Features { get; set; }
    }
}
