using MonoPraksa.Model;

namespace MonoPraksa.Service.Common
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}