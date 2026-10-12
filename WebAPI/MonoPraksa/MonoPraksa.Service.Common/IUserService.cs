using MonoPraksa.Model;

namespace MonoPraksa.Service.Common;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetUsersAsync();
}