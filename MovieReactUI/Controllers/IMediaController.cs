using DomainModel.Models;
using Microsoft.AspNetCore.Mvc;

namespace MediaReactUI.Controllers
{
    public interface IMediaController<T> where T : Media
    {
        public Task<IActionResult> Add(T entity);
        public Task<IActionResult> GetAll(DomainModel.Models.Type? type);
        public Task<IActionResult> GetById(int id);
        public Task<IActionResult> Update(T entity);
        public Task<IActionResult> Delete(int id);
        public Task<IActionResult> AddPost(Post post);
        public Task<IActionResult> AddReview(Review review);
    }
}
