using MonoPraksa.Repository;
using MonoPraksa.Service.Common;
using MonoPraksa.Repository.Common;
using MonoPraksa.Model;

namespace MonoPraksa.Service;

public class FootballerService : IFootballerService
{
    private readonly IFootballerRepository _repository;

    public FootballerService(IFootballerRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Footballer>> GetAll()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Footballer?> GetById(Guid id)
    {
        return await _repository.GetByIdAsync(id); 
    }

    public async Task<IEnumerable<Footballer>> GetFiltered(int? minRating, string? name, int? playerAge)
    {
        var footballers = await _repository.GetAllAsync();
        var query = footballers.AsQueryable();

        if (minRating != null)
            query = query.Where(x => x.Rating >= minRating);

        if (!string.IsNullOrEmpty(name))
            query = query.Where(x => x.PlayerName.Contains(name, StringComparison.OrdinalIgnoreCase));

        if (playerAge != null)
            query = query.Where(x => (DateTime.Now.Year - x.DateOfBirth.Year) == playerAge); 

        return query.ToList();
    }

    public async Task<Footballer?> AddPlayer(FootballerAdd newPlayer)
    {
        var footballer = new Footballer
        {
            ClubId = newPlayer.ClubId,
            PlayerName = newPlayer.PlayerName,
            DateOfBirth = newPlayer.DateOfBirth,
            Rating = newPlayer.Rating
        };
        var existing = await _repository.GetByIdAsync(footballer.Id);
        if (existing != null)
        {
            return null;
        }

        await _repository.AddAsync(footballer);
        return footballer;
    }

    //FootballerEdit koristimo a ne Footballer, jer nece raditi PUT zahtjev, trazit ce Club _club iako ga ne mozemo staviti
    public async Task<bool> EditPlayer(Guid id, FootballerEdit editFootballer)
    {
        var player = await _repository.GetByIdAsync(id);
        if (player == null) return false;

        player.PlayerName = editFootballer.PlayerName;
        player.Rating = editFootballer.Rating;
        player.DateOfBirth = editFootballer.DateOfBirth;

        await _repository.UpdateAsync(player); 
        return true;
    }

    public async Task<bool> DeletePlayer(Guid id)
    {
        var player = await _repository.GetByIdAsync(id);
        if (player == null) return false;

        await _repository.RemoveAsync(player); 
        return true;
    }
}