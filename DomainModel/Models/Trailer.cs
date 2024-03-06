using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Trailer
    {
        public int Id { get; set; }
        public int MediaId { get; set; }
        [JsonIgnore]
        [ForeignKey(nameof(MediaId))]
        public virtual Media Media { get; set; } = null!;
        public string? Name { get; set; }
        public string Youtube { get; set; }
        public int Size { get; set; }
    }
}
