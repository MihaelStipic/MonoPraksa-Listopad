using MonoPraksa.Model;
using System.Collections.Generic;

namespace MonoPraksa.Repository.Common
{
    public interface IFootballerRepository
    {
        Task<IEnumerable<FootballerWithClub>> GetAllAsync();
        Task<Footballer> GetByIdAsync(Guid id);
        Task<IEnumerable<Footballer>> GetFilteredAsync(int? minRating, string? name, int? playerAge);

        Task<bool> ClubExistsAsync(Guid clubId);

        Task AddAsync(Footballer player);
        Task UpdateAsync(Footballer player);
        Task RemoveAsync(Footballer player);
    }
}