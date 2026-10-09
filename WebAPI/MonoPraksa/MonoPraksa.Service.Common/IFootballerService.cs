using MonoPraksa.Model;

namespace MonoPraksa.Service.Common
{
    public interface IFootballerService
    {
        Task<IEnumerable<FootballerDto>> GetAllAsync();
        Task<FootballerDto> GetByIdAsync(Guid id);
        Task<IEnumerable<FootballerDto>> GetFilteredAsync(int? minRating, string? name, int? playerAge);

        Task<FootballerDto?> AddPlayerAsync(FootballerAdd newPlayer);
        Task<bool> EditPlayerAsync(Guid id, FootballerEdit editFootballer);
        Task<bool> DeletePlayerAsync(Guid id);
    }
}
