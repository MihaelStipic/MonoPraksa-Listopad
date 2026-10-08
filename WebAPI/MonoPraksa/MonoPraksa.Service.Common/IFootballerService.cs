using MonoPraksa.Model;

namespace MonoPraksa.Service.Common
{
    public interface IFootballerService
    {
        Task<IEnumerable<Footballer>> GetAll();
        Task<Footballer> GetById(Guid id);
        Task<IEnumerable<Footballer>> GetFiltered(int? minRating, string? name, int? playerAge);
        Task<bool> AddPlayer(FootballerPost newPlayer);
        Task<bool> EditPlayer(Guid id, FootballerPost editFootballer);
        Task<bool> DeletePlayer(Guid id);
    }
}
