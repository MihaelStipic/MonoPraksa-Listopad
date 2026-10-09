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

    public async Task<IEnumerable<FootballerDto>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }

    public async Task<FootballerDto?> GetByIdAsync(Guid id)
    {
        return await _repository.GetByIdAsync(id); 
    }

    public async Task<IEnumerable<FootballerDto>> GetFilteredAsync(int? minRating, string? name, int? playerAge)
    {
        return await _repository.GetFilteredAsync(minRating, name, playerAge);
    }


    public async Task<FootballerDto?> AddPlayerAsync(FootballerAdd newPlayer)
    {
        if (!await _repository.ClubExistsAsync(newPlayer.ClubId))
            return null;

        var footballer = new Footballer
        {
            ClubId = newPlayer.ClubId,
            PlayerName = newPlayer.PlayerName,
            DateOfBirth = newPlayer.DateOfBirth,
            Rating = newPlayer.Rating
        };

        await _repository.AddAsync(footballer);
        return await _repository.GetByIdAsync(footballer.Id);
    }

    //FootballerEdit koristimo a ne Footballer, jer nece raditi PUT zahtjev, trazit ce Club _club iako ga ne mozemo staviti
    public async Task<bool> EditPlayerAsync(Guid id, FootballerEdit editFootballer)
    {
        var player = await _repository.GetByIdAsync(id);
        if (player == null) return false;

        if (!await _repository.ClubExistsAsync(editFootballer.ClubId))
            return false;

        player.PlayerName = editFootballer.PlayerName;
        player.Rating = editFootballer.Rating;
        player.DateOfBirth = editFootballer.DateOfBirth;
        player.ClubId = editFootballer.ClubId;

        await _repository.UpdateAsync(player);
        return true;
    }

    public async Task<bool> DeletePlayerAsync(Guid id)
    {
        var player = await _repository.GetByIdAsync(id);
        if (player == null) return false;

        await _repository.RemoveAsync(player); 
        return true;
    }
}