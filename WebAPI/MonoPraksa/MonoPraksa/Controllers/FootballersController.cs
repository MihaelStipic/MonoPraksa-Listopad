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
        public async Task<IEnumerable<FootballerWithClub>> Get()
        {
            return await _service.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Footballer>> Get(Guid id)
        {
            var player = await _service.GetById(id);
            if (player == null) return NotFound($"Player {id} not found");
            return player;
        }

        [HttpGet("filter")]
        public Task<IEnumerable<Footballer>> GetFiltered([FromQuery] int? minRating, [FromQuery] string? name, [FromQuery] int? playerAge)
        {
            return _service.GetFiltered(minRating, name, playerAge);
        }

        

        [HttpPost]
        public async Task<IActionResult> AddPlayer([FromBody] FootballerAdd newPlayer)
        {
            var created = await _service.AddPlayer(newPlayer);

            if (created == null) return BadRequest("Club does not exist.");

            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditPlayer(Guid id, [FromBody] FootballerEdit editFootballer)
        {
            bool success = await _service.EditPlayer(id, editFootballer);

            if (!success) return NotFound($"Player {id} not found");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(Guid id)
        {
            bool success = await _service.DeletePlayer(id);

            if (!success) return NotFound($"Player {id} not found");

            return NoContent();
        }
    }
}