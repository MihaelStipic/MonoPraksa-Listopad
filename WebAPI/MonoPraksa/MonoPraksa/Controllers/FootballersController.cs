using Microsoft.AspNetCore.Mvc;
using MonoPraksa.Service;
using MonoPraksa.Service.Common;
using Microsoft.EntityFrameworkCore;
using MonoPraksa.Model;
namespace MonoPraksa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FootballersController : ControllerBase
    {
        private readonly IFootballerService _service;

        public FootballersController(IFootballerService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<FootballerWithClub>> GetAsync()
        {
            return await _service.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Footballer>> GetAsync(Guid id)
        {
            var player = await _service.GetByIdAsync(id);
            if (player == null) return NotFound($"Player {id} not found");
            return player;
        }

        [HttpGet("filter")]
        public Task<IEnumerable<FootballerWithClub>> GetFilteredAsync([FromQuery] int? minRating, [FromQuery] string? name, [FromQuery] int? playerAge)
        {
            return _service.GetFilteredAsync(minRating, name, playerAge);
        }

        

        [HttpPost]
        public async Task<IActionResult> AddPlayerAsync([FromBody] FootballerAdd newPlayer)
        {
            var created = await _service.AddPlayerAsync(newPlayer);

            if (created == null) return BadRequest("Club does not exist.");

            return CreatedAtAction(nameof(GetAsync), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditPlayerAsync(Guid id, [FromBody] FootballerEdit editFootballer)
        {
            bool success = await _service.EditPlayerAsync(id, editFootballer);

            if (!success) return NotFound($"Player {id} not found");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayerAsync(Guid id)
        {
            bool success = await _service.DeletePlayerAsync(id);

            if (!success) return NotFound($"Player {id} not found");

            return NoContent();
        }
    }
}