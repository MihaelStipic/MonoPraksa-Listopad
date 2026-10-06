using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace MonoPraksa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FootballersController : ControllerBase
    {

        private static readonly string[] Players =
        [
            "Modric", "Ronaldo", "Messi", "Rakitic", "Yamal", "Olise"
        ];

        private static List<Footballers> Players2 = new List<Footballers>
        {
            new Footballers { Id = 1, PlayerName = "Modric", Rating = 90, PlayerAge = 41 },
            new Footballers { Id = 2, PlayerName = "Ronaldo", Rating = 93, PlayerAge = 42 },
            new Footballers { Id = 3, PlayerName = "Messi", Rating = 94, PlayerAge = 36 },
            new Footballers { Id = 4, PlayerName = "Rakitic", Rating = 85, PlayerAge = 34 },
            new Footballers { Id = 5, PlayerName = "Yamal", Rating = 82, PlayerAge = 19 },
            new Footballers { Id = 6, PlayerName = "Mbappe", Rating = 92, PlayerAge = 26 },
            new Footballers { Id = 7, PlayerName = "Haaland", Rating = 91, PlayerAge = 24 },
            new Footballers { Id = 8, PlayerName = "Bellingham", Rating = 89, PlayerAge = 22 },
            new Footballers { Id = 9, PlayerName = "Pedri", Rating = 86, PlayerAge = 22 },
            new Footballers { Id = 10, PlayerName = "Gavi", Rating = 84, PlayerAge = 20 },
            new Footballers { Id = 11, PlayerName = "De Bruyne", Rating = 91, PlayerAge = 34 },
            new Footballers { Id = 12, PlayerName = "Lewandowski", Rating = 88, PlayerAge = 37 },
            new Footballers { Id = 13, PlayerName = "Vinicius Jr", Rating = 90, PlayerAge = 26 },
            new Footballers { Id = 14, PlayerName = "Saka", Rating = 87, PlayerAge = 23 },
            new Footballers { Id = 15, PlayerName = "Saliba", Rating = 86, PlayerAge = 24 },
            new Footballers { Id = 16, PlayerName = "Rodri", Rating = 92, PlayerAge = 29 },
            new Footballers { Id = 17, PlayerName = "Musiala", Rating = 88, PlayerAge = 22 },
            new Footballers { Id = 18, PlayerName = "Wirtz", Rating = 87, PlayerAge = 22 },
            new Footballers { Id = 19, PlayerName = "Kroos", Rating = 89, PlayerAge = 34 },
            new Footballers { Id = 20, PlayerName = "Neuer", Rating = 86, PlayerAge = 38 }
        };



        [HttpGet]
        public IEnumerable<Footballers> Get()
        {
           
            return Players2;
        }

        [HttpGet("{id}")]
        public Footballers Get(int id)
        {
            return Players2.FirstOrDefault(x => x.Id == id);
            

            
        }

        [HttpGet("filter")]
        public IEnumerable<Footballers> GetFiltered(int? minRating, string? name, int? playerAge)
        {
            //Zato da query bude tipa IEnumerable<Footballers>, a ne List<Footballers>
            var query = Players2.AsEnumerable();

            if (minRating != null)
                query = query.Where(x => x.Rating >= minRating);
            if (name!=null)
                query = query.Where(x => x.PlayerName==name);
            if (playerAge != null)
                query = query.Where(x => x.PlayerAge == playerAge);

            return query.ToList();
        }

        [HttpPost]
        public IActionResult AddPlayer([FromBody] Footballers newPlayer)
        {
            

            if(!Players2.Any(x=> x.Id== newPlayer.Id))
            {
                Players2.Add(newPlayer);
                return Ok("Success");
            }
            else
            {
                return BadRequest("Player already exists!");
            }


            

        }

        [HttpPut("{id}")]
        public IActionResult EditPlayer(int id, [FromBody] Footballers editFootballer)
        {
            var player = Players2.FirstOrDefault(x => x.Id == id);
            if (player == null) return NotFound($"Player {id} not found");

            player.PlayerName = editFootballer.PlayerName;
            player.Rating = editFootballer.Rating;
            player.PlayerAge = editFootballer.PlayerAge;
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeletePlayer(int id)
        {

            Footballers player = Players2.FirstOrDefault(x => x.Id == id);

            if (player != null)
            {

                Players2.Remove(player);
               
                return Ok("Success");


            }
            else
            {
                return NotFound("Cant find the player");
            }
        }

      
    }
}
