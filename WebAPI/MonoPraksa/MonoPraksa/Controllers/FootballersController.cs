using Microsoft.AspNetCore.Mvc;
using MonoPraksa.Service;
using MonoPraksa.Service.Common;
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
        public IEnumerable<Footballer> Get()
        {
            return _service.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Footballer> Get(int id)
        {
            var player = _service.GetById(id);
            if (player == null) return NotFound($"Player {id} not found");
            return player;
        }

        [HttpGet("filter")]
        public IEnumerable<Footballer> GetFiltered([FromQuery] int? minRating, [FromQuery] string? name, [FromQuery] int? playerAge)
        {
            return _service.GetFiltered(minRating, name, playerAge);
        }

        [HttpPost]
        public IActionResult AddPlayer([FromBody] Footballer newPlayer)
        {
            bool success = _service.AddPlayer(newPlayer);

            if (!success) return BadRequest("Player already exists!");

            return CreatedAtAction(nameof(Get), new { id = newPlayer.Id }, newPlayer);
        }

        [HttpPut("{id}")]
        public IActionResult EditPlayer(int id, [FromBody] Footballer editFootballer)
        {
            bool success = _service.EditPlayer(id, editFootballer);

            if (!success) return NotFound($"Player {id} not found");

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePlayer(int id)
        {
            bool success = _service.DeletePlayer(id);

            if (!success) return NotFound($"Player {id} not found");

            return NoContent();
        }
    }
}