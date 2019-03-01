using Newtonsoft.Json;
using System.Collections.Generic;

namespace Models
{
    public class Geometry
    {

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("coordinates")]
        public IList<double> Coordinates { get; set; }
    }
}
