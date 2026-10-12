using MonoPraksa.Model;
using MonoPraksa.Repository.Common;
using MonoPraksa.Service.Common;

namespace MonoPraksa.Service
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _users;
        private readonly ITokenService _tokenService;

        public AuthService(IUserRepository users, ITokenService tokenService)
        {
            _users = users;
            _tokenService = tokenService;
        }

        public async Task<IEnumerable<UserDto>> GetUsersAsync()
        {
            return await _users.GetUsersAsync();
        }

        public async Task<bool> RegisterAsync(RegisterRequest request)
        {
            var email = request.Email.Trim().ToLowerInvariant();

            if (await _users.EmailExistsAsync(email))
                return false;

            var user = new User
            {
                Email = email,
                // registracija: BCrypt sam smisli salt, napravi kašu, vrati sve u jednom tekstu
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Role = Roles.User
            };

            await _users.AddAsync(user);
            return true;
        }

        public async Task<AuthResponse?> LoginAsync(LoginRequest request)
        {
            var email = request.Email.Trim().ToLowerInvariant();
            var user = await _users.GetByEmailAsync(email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
                return null;

            return new AuthResponse { Token = _tokenService.CreateToken(user) };
        }
    }
}