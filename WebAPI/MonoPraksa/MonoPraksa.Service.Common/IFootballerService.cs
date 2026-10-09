using MonoPraksa.Model;

namespace MonoPraksa.Service.Common
{
    public interface IFootballerService
    {
        Task<IEnumerable<FootballerWithClub>> GetAllAsync();
        Task<Footballer> GetByIdAsync(Guid id);
        Task<IEnumerable<FootballerWithClub>> GetFilteredAsync(int? minRating, string? name, int? playerAge);
        
        Task<Footballer?> AddPlayerAsync(FootballerAdd newPlayer);
        Task<bool> EditPlayerAsync(Guid id, FootballerEdit editFootballer);
        Task<bool> DeletePlayerAsync(Guid id);
    }
}
