using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DomainModel.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public DateTime DatePosted { get; set; }
        public ICollection<Post> Replies { get; set; }

        // Foreign Keys
        public string UserId { get; set; }
        [JsonIgnore]
        [ForeignKey(nameof(UserId))]
        public virtual User User { get; set; }
        public int MediaId { get; set; }
        [JsonIgnore]
        [ForeignKey(nameof(MediaId))]
        public virtual Media Media { get; set; }

        public int? ParentPostId { get; set; }
        [JsonIgnore]
        [ForeignKey(nameof(ParentPostId))]
        public virtual Post ParentPost { get; set; }

    }
}
