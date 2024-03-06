using DomainModel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Repo
{
    public interface IMediaRepo<T> where T : Media
    {
        Task<List<T>> GetAllMediaAsync();
        Task<T> GetMediaByIdAsync(int id);
        Task UpdateMediaAsync(T media);
        Task DeleteMediaAsync(int id);
        Task AddMediaAsync(T media);
        Task<T?> GetByImdbAsync(string id);
    }
}
