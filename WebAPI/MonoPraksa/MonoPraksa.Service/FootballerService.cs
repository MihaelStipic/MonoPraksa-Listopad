using MonoPraksa.Repository;
using MonoPraksa.Service.Common;
using MonoPraksa.Repository.Common;
namespace MonoPraksa.Service
{
    

    public class FootballerService : IFootballerService
    {
        private readonly IFootballerRepository _repository;

        public FootballerService(IFootballerRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Footballers> GetAll() { return _repository.GetAll(); }

        public Footballers GetById(int id) {return _repository.GetById(id);}

        public IEnumerable<Footballers> GetFiltered(int? minRating, string? name, int? playerAge)
        {
            var query = _repository.GetAll().AsEnumerable();

            if (minRating != null) query = query.Where(x => x.Rating >= minRating);
            if (name != null) query = query.Where(x => x.PlayerName == name);
            if (playerAge != null) query = query.Where(x => x.PlayerAge == playerAge);

            return query;
        }

        public bool AddPlayer(Footballers newPlayer)
        {
            if (_repository.GetById(newPlayer.Id) != null)
            {
                return false; 
            }

            _repository.Add(newPlayer);
            return true;
        }

        public bool EditPlayer(int id, Footballers editFootballer)
        {
            var player = _repository.GetById(id);
            if (player == null) return false;

            player.PlayerName = editFootballer.PlayerName;
            player.Rating = editFootballer.Rating;
            player.PlayerAge = editFootballer.PlayerAge;
            return true;
        }

        public bool DeletePlayer(int id)
        {
            var player = _repository.GetById(id);
            if (player == null) return false; 

            _repository.Remove(player);
            return true;
        }
    }
}
