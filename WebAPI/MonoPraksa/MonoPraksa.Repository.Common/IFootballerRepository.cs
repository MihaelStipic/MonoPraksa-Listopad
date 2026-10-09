using MonoPraksa.Model;
using System.Collections.Generic;

namespace MonoPraksa.Repository.Common
{
    public interface IFootballerRepository
    {
        Task<IEnumerable<FootballerDto>> GetAllAsync();
        Task<FootballerDto?> GetByIdAsync(Guid id);
        Task<IEnumerable<FootballerDto>> GetFilteredAsync(int? minRating, string? name, int? playerAge);

        Task<bool> ClubExistsAsync(Guid clubId);

        Task AddAsync(Footballer player);
        Task UpdateAsync(FootballerDto player);
        Task RemoveAsync(FootballerDto player);
    }
}