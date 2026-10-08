namespace MonoPraksa.Service.Common
{
    public interface IFootballerService
    {
        IEnumerable<Footballer> GetAll();
        Footballer GetById(int id);
        IEnumerable<Footballer> GetFiltered(int? minRating, string? name, int? playerAge);
        bool AddPlayer(Footballer newPlayer);
        bool EditPlayer(int id, Footballer editFootballer);
        bool DeletePlayer(int id);
    }
}
