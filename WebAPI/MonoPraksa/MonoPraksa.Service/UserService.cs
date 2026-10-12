using MonoPraksa.Model;
using MonoPraksa.Repository.Common;
using MonoPraksa.Service.Common;

namespace MonoPraksa.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _users;

    public UserService(IUserRepository users)
    {
        _users = users;
    }

    public async Task<IEnumerable<UserDto>> GetUsersAsync()
    {
        var users = await _users.GetUsersAsync();

        return users.Select(u => new UserDto
        {
            Id = u.Id,
            Email = u.Email,
            Role = u.Role
        });
    }
}