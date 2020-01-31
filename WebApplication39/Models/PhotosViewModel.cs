using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsProject.Models
{
    public class PhotosViewModel
    {
        [JsonProperty("id")]
        public int? Id { get; set; }

        [JsonProperty("sol")]
        public int? Sol { get; set; }

        [JsonProperty("img_src")]
        public string ImgSrc { get; set; }

        [JsonProperty("earth_date")]
        public string EarthDate { get; set; }

        [JsonProperty("photos")]
        public List<PhotoObj> PhotoObjs { get; set; }

     
    }
}
