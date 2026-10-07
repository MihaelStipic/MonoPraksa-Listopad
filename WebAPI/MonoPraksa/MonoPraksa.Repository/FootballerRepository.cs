using MonoPraksa.Repository.Common;
namespace MonoPraksa.Repository
{
    

    public class FootballerRepository : IFootballerRepository
    {
        private List<Footballers> Players2 = new List<Footballers>
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

        public IEnumerable<Footballers> GetAll() { return Players2; }

        public Footballers GetById(int id) {return Players2.FirstOrDefault(x => x.Id == id);}

        public void Add(Footballers player) {  Players2.Add(player); }

        public void Remove(Footballers player) { Players2.Remove(player); } 
    }
}
