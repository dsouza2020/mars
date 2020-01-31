using Newtonsoft.Json;
using System;

namespace MarsProject.Models
{
    public class PhotoObj
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("sol")]
        public int sol { get; set; }
        [JsonProperty("img_src")]
        public string img_src { get; set; }

        [JsonProperty("earth_date")]
        public DateTime earth_date { get; set; }

    }
}