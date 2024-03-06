using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public bool IsRecommended { get; set; }
        public string Text { get; set; }

        // Foreign keys
        public string UserId { get; set; }
        [JsonIgnore]
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
        public int MediaId { get; set; }
        [JsonIgnore]
        [ForeignKey(nameof(MediaId))]
        public virtual Media Media { get; set; }
    }
}
