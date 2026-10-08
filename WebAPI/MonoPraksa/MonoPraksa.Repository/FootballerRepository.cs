using MonoPraksa.Repository.Common;
namespace MonoPraksa.Repository
{
    

    public class FootballerRepository : IFootballerRepository
    {
        private List<Footballer> Players2 = new List<Footballer>
        {
            new Footballer { Id = 1, PlayerName = "Modric", Rating = 90, DateOfBirth = new DateOnly(1985, 9, 9) },
            new Footballer { Id = 2, PlayerName = "Ronaldo", Rating = 93, DateOfBirth = new DateOnly(1985, 2, 5) },
            new Footballer { Id = 3, PlayerName = "Messi", Rating = 94, DateOfBirth = new DateOnly(1987, 6, 24) },
            new Footballer { Id = 4, PlayerName = "Rakitic", Rating = 85, DateOfBirth = new DateOnly(1988, 3, 10) },
            new Footballer { Id = 5, PlayerName = "Yamal", Rating = 82, DateOfBirth = new DateOnly(2007, 7, 13) },
            new Footballer { Id = 6, PlayerName = "Mbappe", Rating = 92, DateOfBirth = new DateOnly(1998, 12, 20) },
            new Footballer { Id = 7, PlayerName = "Haaland", Rating = 91, DateOfBirth = new DateOnly(2000, 7, 21) },
            new Footballer { Id = 8, PlayerName = "Bellingham", Rating = 89, DateOfBirth = new DateOnly(2003, 6, 29) },
            new Footballer { Id = 9, PlayerName = "Pedri", Rating = 86, DateOfBirth = new DateOnly(2002, 11, 25) },
            new Footballer { Id = 10, PlayerName = "Gavi", Rating = 84, DateOfBirth = new DateOnly(2004, 8, 5) },
            new Footballer { Id = 11, PlayerName = "De Bruyne", Rating = 91, DateOfBirth = new DateOnly(1991, 6, 28) },
            new Footballer { Id = 12, PlayerName = "Lewandowski", Rating = 88, DateOfBirth = new DateOnly(1988, 8, 21) },
            new Footballer { Id = 13, PlayerName = "Vinicius Jr", Rating = 90, DateOfBirth = new DateOnly(2000, 7, 12) },
            new Footballer { Id = 14, PlayerName = "Saka", Rating = 87, DateOfBirth = new DateOnly(2001, 9, 5) },
            new Footballer { Id = 15, PlayerName = "Saliba", Rating = 86, DateOfBirth = new DateOnly(2001, 3, 24) },
            new Footballer { Id = 16, PlayerName = "Rodri", Rating = 92, DateOfBirth = new DateOnly(1996, 6, 22) },
            new Footballer { Id = 17, PlayerName = "Musiala", Rating = 88, DateOfBirth = new DateOnly(2003, 2, 26) },
            new Footballer { Id = 18, PlayerName = "Wirtz", Rating = 87, DateOfBirth = new DateOnly(2003, 5, 3) },
            new Footballer { Id = 19, PlayerName = "Kroos", Rating = 89, DateOfBirth = new DateOnly(1990, 1, 4) },
            new Footballer { Id = 20, PlayerName = "Neuer", Rating = 86, DateOfBirth = new DateOnly(1986, 3, 27) }
        };

        public IEnumerable<Footballer> GetAll() { return Players2; }

        public Footballer GetById(int id) {return Players2.FirstOrDefault(x => x.Id == id);}

        public void Add(Footballer player) {  Players2.Add(player); }

        public void Remove(Footballer player) { Players2.Remove(player); } 
    }
}
