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

    public async Task<IEnumerable<FootballerWithClub>> GetAll()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<Footballer?> GetById(Guid id)
    {
        return await _repository.GetByIdAsync(id); 
    }

    public async Task<IEnumerable<Footballer>> GetFiltered(int? minRating, string? name, int? playerAge)
    {
        return await _repository.GetFilteredAsync(minRating, name, playerAge);
    }

    
    public async Task<Footballer?> AddPlayer(FootballerAdd newPlayer)
    {
        if (!await _repository.ClubExistsAsync(newPlayer.ClubId))
            return null;

        var footballer = new Footballer
        {
            Id = Guid.NewGuid(),
            ClubId = newPlayer.ClubId,
            PlayerName = newPlayer.PlayerName,
            DateOfBirth = newPlayer.DateOfBirth,
            Rating = newPlayer.Rating
        };

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