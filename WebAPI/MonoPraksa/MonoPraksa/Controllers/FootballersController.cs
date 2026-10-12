using Microsoft.AspNetCore.Mvc;
using MonoPraksa.Service;
using MonoPraksa.Service.Common;
using Microsoft.EntityFrameworkCore;
using MonoPraksa.Model;
using Microsoft.AspNetCore.Authorization;
namespace MonoPraksa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class FootballersController : ControllerBase
    {
        private readonly IFootballerService _service;

        public FootballersController(IFootballerService service)
        {
            _service = service;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IEnumerable<FootballerDto>> Get()
        {
            return await _service.GetAllAsync();
        }

        

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<ActionResult<FootballerDto>> Get(Guid id)
        {
            var player = await _service.GetByIdAsync(id);
            if (player == null) return NotFound($"Player {id} not found");
            return player;
        }

        [AllowAnonymous]
        [HttpGet("filter")]
        public async Task<IEnumerable<FootballerDto>> GetFiltered([FromQuery] int? minRating, [FromQuery] string? name, [FromQuery] int? playerAge)
        {
            return await _service.GetFilteredAsync(minRating, name, playerAge);
        }


        [Authorize(Roles = Roles.Admin)]
        [HttpPost]
        public async Task<IActionResult> AddPlayer([FromBody] FootballerAdd newPlayer)
        {
            var created = await _service.AddPlayerAsync(newPlayer);

            if (created == null) return BadRequest("Club does not exist.");

            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [Authorize(Roles = Roles.Admin)]
        [HttpPut("{id}")]
        public async Task<IActionResult> EditPlayer(Guid id, [FromBody] FootballerEdit editFootballer)
        {


            bool success = await _service.EditPlayerAsync(id, editFootballer);

            if (!success) return NotFound($"Player {id} not found");

            return NoContent();
        }
        [Authorize(Roles = Roles.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(Guid id)
        {
            bool success = await _service.DeletePlayerAsync(id);

            if (!success) return NotFound($"Player {id} not found");

            return NoContent();
        }
    }
}