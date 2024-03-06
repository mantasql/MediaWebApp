using DomainModel.DataAccess;
using DomainModel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Repo
{
    public class MediaRepo<T> : IMediaRepo<T> where T : Media
    {
        private readonly ApplicationContext context;

        public MediaRepo(ApplicationContext context)
        {
            this.context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddMediaAsync(T media)
        {
            if (media is null)
            {
                throw new ArgumentNullException(nameof(media));
            }

            media.Genres = await GetSameGenresFromDb(media);

            await context.Medias.AddAsync(media);
            await context.SaveChangesAsync();
        }

        public async Task DeleteMediaAsync(int id)
        {
            Media media = await context.Medias.FirstOrDefaultAsync(x => x.Id == id) ?? throw new ArgumentException($"No media with id: {id}");

            context.Medias.Remove(media);
            await context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllMediaAsync() => await context.Medias.OfType<T>().Include(x => x.Genres).ToListAsync();

        public async Task<T> GetMediaByIdAsync(int id)
        {
            return (T)(await context.Medias
                .Include(x => x.Studios)
                .Include(x => x.Relations)
                .Include(x => x.Genres)
                .Include(x => x.Posts)
                .FirstOrDefaultAsync(x => x.Id == id) ?? throw new ArgumentException($"No media with id: {id}"));
        }

        public async Task UpdateMediaAsync(T media)
        {
            if (media is null)
            {
                throw new ArgumentNullException(nameof(media));
            }

            var m = await context.Medias.FirstOrDefaultAsync(x => x.Id == media.Id) ?? throw new ArgumentException($"No media with id: {media.Id}");

            context.ChangeTracker.Clear();
            context.Update(media);
            await context.SaveChangesAsync();
        }

        public async Task<T?> GetByImdbAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            return (T?)await context.Medias.Where(x => x.Ids.Imdb == id).FirstOrDefaultAsync();
        }

        public async Task<ICollection<Genre>> GetSameGenresFromDb(T media)
        {
            ICollection<Genre> g = media.Genres;
            media.Genres = new List<Genre>();
            foreach (var genre in g)
            {
                Genre? gen = await context.Genres.Where(x => x.Name == genre.Name).FirstOrDefaultAsync();
                if (gen != null)
                {
                    media.Genres.Add(gen);
                }
                else
                {
                    media.Genres.Add(genre);
                }
            }

            return media.Genres;
        }
    }
}
