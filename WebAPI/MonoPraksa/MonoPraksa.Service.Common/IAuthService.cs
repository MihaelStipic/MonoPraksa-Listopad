using System;
using System.Collections.Generic;
using System.Text;

using MonoPraksa.Model;

namespace MonoPraksa.Service.Common
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(RegisterRequest request);
        Task<AuthResponse?> LoginAsync(LoginRequest request);
    }
}