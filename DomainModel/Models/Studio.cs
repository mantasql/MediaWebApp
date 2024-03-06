﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Studio
    {
        public int Id { get; set; }
        [JsonProperty("id")]
        public int StudioID { get; set; }
        [System.Text.Json.Serialization.JsonIgnore]
        public virtual ICollection<Media> Medias { get; set; }
        public string Name { get; set; }
    }
}
