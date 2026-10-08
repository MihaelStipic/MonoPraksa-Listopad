using MonoPraksa.Model;

namespace MonoPraksa.Service.Common
{
    public interface IFootballerService
    {
        Task<IEnumerable<Footballer>> GetAll();
        Task<Footballer> GetById(Guid id);
        Task<IEnumerable<Footballer>> GetFiltered(int? minRating, string? name, int? playerAge);
        Task<Footballer?> AddPlayer(FootballerAdd newPlayer);
        Task<bool> EditPlayer(Guid id, FootballerEdit editFootballer);
        Task<bool> DeletePlayer(Guid id);
    }
}
