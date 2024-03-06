using DomainModel.Models;
using DomainModel.Repo;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MediaReactUI.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo userRepo;

        public UserController(IUserRepo userRepo)
        {
            this.userRepo = userRepo;
        }

        [HttpPost("[action]/{id}")]
        public async Task<IActionResult> Add([FromRoute]string id, [FromQuery]string userName)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("ModelState not valid");
            }

            try
            {
                await userRepo.AddUserAsync(id, userName);

                return Ok("User successfully added");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
