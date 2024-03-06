using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using JsonIgnoreAttribute = System.Text.Json.Serialization.JsonIgnoreAttribute;

namespace DomainModel.Models
{
/*    public enum Genre
    {
        Action,
        Comedy,
        Drama,
        Fantasy,
        Horror,
        Mystery,
        Romance,
        Thriller,
        Western,
        Crime,
        [EnumMember(Value = "Super Power")]
        SuperPower,
        Shounen,
        [EnumMember(Value = "Sci-Fi")]
        SciFi,
        Military,
        Adventure,
        [EnumMember(Value = "Science-Fiction")]
        ScienceFiction,
        Suspense,
        Psychological,
        Supernatural,
        School,
        Mecha,
        Magic,
        Demons
    }*/

    public enum Status
    {
        Airing,
        Ended
    }
    public enum Type
    {
        Movie,
        Show,
        Anime
    }

    public class Media
    {
        public int Id { get; set; }
        public Ids Ids { get; set; }
        public string Title { get; set; }
        [JsonProperty("en_title")]
        public string? EnTitle { get; set; }
        public string? Overview { get; set; }
        public string? Year { get; set; }
        [JsonProperty("year_start_end")]
        public string? YearStartEnd { get; set; }
        public string? Released { get; set; }
        public string? Director { get; set; }
        public string? Certification { get; set; }
        [JsonProperty("first_aired")]
        public DateTime? FirstAired { get; set; }
        [JsonProperty("last_aired")]
        public DateTime? LastAired { get; set; }
        public string? Poster { get; set; }
        public int Runtime { get; set; }
        [JsonProperty("total_episodes")]
        public int? TotalEpisodes { get; set; }
        public string? Network { get; set; }
        public int? Season { get; set; }
        public virtual ICollection<Trailer>? Trailers { get; set; }
        public virtual ICollection<Studio>? Studios { get; set; }
        public virtual ICollection<Relations>? Relations { get; set; }
        //public virtual ICollection<Rating> Ratings { get; set; }
        public Dictionary<string, Ratings> Ratings { get; set; }
        [JsonIgnore]
        public virtual ICollection<Genre> Genres { get; set; } = new List<Genre>();
        public Status Status { get; set; }
        public Type Type { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
    }
}
