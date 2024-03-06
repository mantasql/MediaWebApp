using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Ratings
    {
        public int Id { get; set; }
        public float Rating { get; set; }
        public int Votes { get; set; }

        public int MediaId { get; set; }
        [JsonIgnore]
        public Media Media { get; set; } = null!;
    }
}
