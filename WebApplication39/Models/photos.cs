using System;
using System.Collections.Generic;

namespace MarsProject.Models
{
    public partial class Photos
    {

        public int PhotoId { get; set; }
        public int? Id { get; set; }
        public int? Sol { get; set; }
        public string ImgSrc { get; set; }
        public string EarthDate { get; set; }
    }
}
