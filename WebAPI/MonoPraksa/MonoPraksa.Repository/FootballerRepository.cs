using MonoPraksa.Model;
using MonoPraksa.Repository.Common;
using Microsoft.EntityFrameworkCore;
namespace MonoPraksa.Repository
{
    

    public class FootballerRepository : IFootballerRepository
    {
        private readonly AppDbContext _db;
        public FootballerRepository(AppDbContext db)
        {
            _db = db;
        }


        public async Task<IEnumerable<FootballerWithClub>> GetAllAsync()
        {
            return await _db.Footballers.Select(f => new FootballerWithClub
            {
                Id = f.Id,
                ClubId = f.ClubId,
                PlayerName = f.PlayerName,
                DateOfBirth = f.DateOfBirth,
                Rating = f.Rating,
                ClubName = f.Club!.Name

            }).ToListAsync();
        }

        public async Task<Footballer> GetByIdAsync(Guid id)
        {
            return await _db.Footballers.FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<IEnumerable<Footballer>> GetFilteredAsync(int? minRating, string? name, int? playerAge)
        {
            //vraca IQueryable<Footballer>
            var query = _db.Footballers.AsQueryable(); // samo upit, nema baze.. ne izvršava SQL.
            if (minRating != null)
            {
                query=query.Where(x => x.Rating >= minRating); // samo dopuna upita, nema baze
            }

            if(name != null)
            {
                query = query.Where(x => x.PlayerName == name);
            }

            if (playerAge != null) {

                query = query.Where(x => (DateTime.Now.Year - x.DateOfBirth.Year) == playerAge);
            }
            //vraca IEnumerable
            return await query.ToListAsync(); // OVDJE ide u bazu, zato await

        }

        public async Task<bool> ClubExistsAsync(Guid clubId)
        {
            return await _db.Clubs.AnyAsync(c => c.Id == clubId);
        }

        public async Task AddAsync(Footballer player)
        {
            await _db.Footballers.AddAsync(player);
            await _db.SaveChangesAsync();
        }
        public async Task UpdateAsync(Footballer player)
        {
            _db.Footballers.Update(player);
            await _db.SaveChangesAsync();
        }
        public async Task RemoveAsync(Footballer player)
        {
            _db.Footballers.Remove(player);
            await _db.SaveChangesAsync();
        }

    }
}
