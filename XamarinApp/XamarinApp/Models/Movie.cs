using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XamarinApp.Models
{
    public class Movie
    {
        [JsonProperty("unit")]
        public int Unit { get; set; }
        [JsonProperty("show_id")]
        public int ShowId { get; set; }
        [JsonProperty("show_title")]
        public string ShowTitle { get; set; }
        [JsonProperty("release_year")]
        public string ReleaseYear { get; set; }
        [JsonProperty("rating")]
        public string Rating { get; set; }
        [JsonProperty("category")]
        public string Category { get; set; }
        [JsonProperty("show_cast")]
        public string ShowCast { get; set; }
        [JsonProperty("director")]
        public string Director { get; set; }
        [JsonProperty("summary")]
        public string Summary { get; set; }
        [JsonProperty("poster")]
        public string Poster { get; set; }
        [JsonProperty("mediatype")]
        public int Mediatype { get; set; }
        [JsonProperty("runtime")]
        public string Runtime { get; set; }
    }
}
