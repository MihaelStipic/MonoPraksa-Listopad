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


        public async Task<IEnumerable<FootballerDto>> GetAllAsync()
        {
            return await _db.Footballers.Select(f => new FootballerDto
            {
                Id = f.Id,
                ClubId = f.ClubId,
                PlayerName = f.PlayerName,
                DateOfBirth = f.DateOfBirth,
                Rating = f.Rating,
                ClubName = f.Club!.Name

            }).ToListAsync();
        }

        public async Task<FootballerDto?> GetByIdAsync(Guid id)
        {
            return await _db.Footballers
                .Where(f => f.Id == id)
                .Select(f => new FootballerDto
                {
                    Id = f.Id,
                    ClubId = f.ClubId,
                    PlayerName = f.PlayerName,
                    DateOfBirth = f.DateOfBirth,
                    Rating = f.Rating,
                    ClubName = f.Club!.Name
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<FootballerDto>> GetFilteredAsync(int? minRating, string? name, int? playerAge)
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
            //vraca IEnumearble
            return await query
                .Select(f => new FootballerDto
                {
                    Id = f.Id,
                    ClubId = f.ClubId,
                    PlayerName = f.PlayerName,
                    DateOfBirth = f.DateOfBirth,
                    Rating = f.Rating,
                    ClubName = f.Club!.Name
                })
                .ToListAsync();

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
        public async Task UpdateAsync(FootballerDto player)
        {
            var entity = await _db.Footballers.FindAsync(player.Id);
            if (entity == null) return;

            entity.PlayerName = player.PlayerName;
            entity.ClubId = player.ClubId;
            entity.DateOfBirth = player.DateOfBirth;
            entity.Rating = player.Rating;

            await _db.SaveChangesAsync();
        }
        public async Task RemoveAsync(FootballerDto player)
        {
            var playerw = new Footballer
            {
                Id = player.Id,
                PlayerName = player.PlayerName,
                ClubId = player.ClubId,
                DateOfBirth = player.DateOfBirth,
                Rating = player.Rating
            };
            _db.Footballers.Remove(playerw);
            await _db.SaveChangesAsync();
        }

    }
}
