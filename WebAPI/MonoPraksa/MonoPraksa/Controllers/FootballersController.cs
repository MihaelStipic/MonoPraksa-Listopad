using Microsoft.AspNetCore.Mvc;

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
            new Footballers { Id=1, Player = "Modric", Rating = 90 },
            new Footballers { Id=2, Player = "Ronaldo", Rating = 93 },
            new Footballers { Id=3, Player = "Messi", Rating = 94 },
            new Footballers { Id=4, Player = "Rakitic", Rating = 85 },
            new Footballers { Id=5, Player = "Yamal", Rating = 82 }
        };



        [HttpGet(Name = "GetFootballers")]
        public IEnumerable<Footballers> Get()
        {
            return Players2;
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
            Footballers player = Players2.FirstOrDefault(x => x.Id == id);

            if (player != null)
            {
                
                Players2.Remove(player);
                Players2.Add(editFootballer);
                return Ok("Success");
                
               
            }
            else
            {
                return NotFound("Cant find the player");
            }
    
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
