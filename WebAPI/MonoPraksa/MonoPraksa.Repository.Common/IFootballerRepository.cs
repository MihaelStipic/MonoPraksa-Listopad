using MonoPraksa.Model;
using System.Collections.Generic;

namespace MonoPraksa.Repository.Common
{
    public interface IFootballerRepository
    {
        Task<IEnumerable<Footballer>> GetAllAsync();
        Task<Footballer> GetByIdAsync(Guid id);
        Task AddAsync(Footballer player);
        Task UpdateAsync(Footballer player);
        Task RemoveAsync(Footballer player);
    }
}