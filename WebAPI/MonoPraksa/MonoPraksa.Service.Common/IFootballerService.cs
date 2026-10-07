namespace MonoPraksa.Service.Common
{
    public interface IFootballerService
    {
        IEnumerable<Footballers> GetAll();
        Footballers GetById(int id);
        IEnumerable<Footballers> GetFiltered(int? minRating, string? name, int? playerAge);
        bool AddPlayer(Footballers newPlayer);
        bool EditPlayer(int id, Footballers editFootballer);
        bool DeletePlayer(int id);
    }
}
