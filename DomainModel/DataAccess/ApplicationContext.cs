using DomainModel.Models;
using DomainModel.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DomainModel.DataAccess
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Media> Medias { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Media>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.OwnsOne(e => e.Ids);
                entity.HasMany(e => e.Trailers).WithOne(e => e.Media).HasForeignKey(e => e.MediaId);
                //entity.HasMany(e => e.Trailers).WithOne(e => e.Media).HasForeignKey(e => e.MediaId);
                entity.HasMany(e => e.Relations).WithMany(e => e.Medias);
                entity.HasMany(e => e.Studios).WithMany(e => e.Medias);
                entity.HasMany(e => e.Genres).WithMany(e => e.Medias);
                //entity.Property(e => e.Genres).HasConversion(v => string.Join(',', v), v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
                //entity.Property(e => e.Genres).HasConversion(new EnumCollectionJsonValueConverter<Genre>()).Metadata.SetValueComparer(new CollectionValueComparer<Genre>());
                entity.Property(e => e.Ratings).HasConversion(new DictionaryJsonValueConverter<string, Ratings>()).Metadata.SetValueComparer(new DictionaryValueComparer<string, Ratings>());
                //entity.Property(e => e.Ratings).HasConversion(d => JsonConvert.SerializeObject(d, Newtonsoft.Json.Formatting.None), s => JsonConvert.DeserializeObject<Dictionary<string, Ratings>>(s));
                //entity.Property(e => e.Ratings).HasConversion(new JsonValueConverter<Dictionary<string, Ratings>>());
                entity.Property(e => e.Status).HasConversion(v => v.ToString(), v => (Status)Enum.Parse(typeof(Status), v));
                entity.Property(e => e.Type).HasConversion(v => v.ToString(), v => (Models.Type)Enum.Parse(typeof(Models.Type), v));
                entity.HasMany(e => e.Posts).WithOne(e => e.Media).HasForeignKey(e => e.MediaId);
                entity.HasMany(e => e.Reviews).WithOne(e => e.Media).HasForeignKey(e => e.MediaId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasMany(x => x.Medias).WithMany(x => x.Users);
                entity.HasMany(x => x.Posts).WithOne(x => x.User).HasForeignKey(x => x.UserId);
                entity.HasMany(x => x.Reviews).WithOne(x => x.User).HasForeignKey(x => x.UserId);
            });

            modelBuilder.Entity<Relations>(entity =>
            {
                entity.OwnsOne(e => e.Ids);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasMany(p => p.Replies).WithOne(p => p.ParentPost).HasForeignKey(p => p.ParentPostId).IsRequired(false);
            });
        }
    }
}
