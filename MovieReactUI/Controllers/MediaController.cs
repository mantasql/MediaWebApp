using DomainModel.Models;
using DomainModel.Models.Viewmodels;
using DomainModel.Models.Wrapper;
using DomainModel.Repo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;
using System.Linq;

namespace MediaReactUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : Controller, IMediaController<Media>
    {
        private readonly IMediaRepo<Media> mediaRepo;

        public MediaController(IMediaRepo<Media> mediaRepo)
        {
            this.mediaRepo = mediaRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Add(Media entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("ModelState not valid");
            }

            try
            {
                await mediaRepo.AddMediaAsync(entity);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await mediaRepo.DeleteMediaAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("[action]")]
        public async Task<IActionResult> GetAll([FromQuery] DomainModel.Models.Type? type)
        {
            try
            {
                List<Media> medias = await mediaRepo.GetAllMediaAsync();

                medias = medias.OrderByDescending(x => x.Ratings["simkl"].Rating).ToList();

                return Ok(type is null ? medias : medias.Where(x => x.Type == type));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                Media media = await mediaRepo.GetMediaByIdAsync(id);

                return Ok(media);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Media entity)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("ModelState not valid");
            }

            try
            {
                await mediaRepo.UpdateMediaAsync(entity);
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("[action]")]
        public async Task<IActionResult> GetByTitle([FromQuery]string title, [FromQuery]DomainModel.Models.Type? type)
        {
            try
            {
                List<Media> medias = await mediaRepo.GetAllMediaAsync();

                return Ok(type != null
                    ? medias.Where(x => x.Title.ToLower().Contains(title.ToLower()) && x.Type == type)
                    : medias.Where(x => x.Title.ToLower().Contains(title.ToLower())));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Will need to hide clientID
        // type = movie, tv, anime
        // (e.g.: https://localhost:44462/api/media/post?id=tt0903747&type=tv)
        [Route("Post")]
        public async Task<IActionResult> PostMedia([FromQuery]string id, [FromQuery]string type)
        {
            try
            {
                string clientId = "d99bf2964e9049ceb60cfa6ed3bff23d479332b5db7c348f367f4c9315baf979";
                string url = $"https://api.simkl.com/{type}/{id}?extended=full&client_id={clientId}";

                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage response = await httpClient.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        GenreWrapper wrapper = JsonConvert.DeserializeObject<GenreWrapper>(content);
                        Media media = JsonConvert.DeserializeObject<Media>(content);
                        for (int i = 0; i < wrapper.Genres.Count; i++)
                        {
                            media.Genres.Add(new Genre() { Name = wrapper.Genres[i] });
                        }
                        //TODO: CHECK IF EXIST
                        try
                        {
                            if (await mediaRepo.GetByImdbAsync(media.Ids.Imdb) is null)
                            {
                                await mediaRepo.AddMediaAsync(media);
                            }
                            else
                            {
                                return BadRequest("Error: Media already exists");
                            }
                        }
                        catch(ArgumentNullException)
                        {
                            return BadRequest($"Error: Failed to add media");
                        }
                        
                        return Ok(media);
                    }
                    else
                    {
                        return BadRequest($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetSimilarShows(int id)
        {
            try
            {
                Media media = await mediaRepo.GetMediaByIdAsync(id);

                List<Media> similarShows = await mediaRepo.GetAllMediaAsync();

                similarShows = similarShows.OrderByDescending(show => show.Genres.Intersect(media.Genres).Count())
                    .Where(x => x.Id != media.Id && (!media.Relations!.Any() || media.Relations!.Select(r => r.Id != x.Id).Any()))
                    .Take(7).ToList();
                

                return Ok(similarShows);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public Task<IActionResult> AddPost(Post post)
        {
            throw new NotImplementedException();
        }

        public Task<IActionResult> AddReview(Review review)
        {
            throw new NotImplementedException();
        }
    }
}
