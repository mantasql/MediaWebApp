using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Relations
    {
        public int Id { get; set; }
        public Ids Ids { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public ICollection<Media> Medias { get; set; } = null!;
        public string Title { get; set; }
        [JsonProperty("en_title")]
        public string? EnTitle { get; set; }
        public string Year {  get; set; }
        [JsonProperty("relation_type")]
        public string RelationType { get; set; }
        [JsonProperty("is_direct")]
        public bool IsDirect { get; set; }

    }
}
