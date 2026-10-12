using System.ComponentModel.DataAnnotations;

namespace MonoPraksa.Model;

public class LoginRequest
{
    [Required]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string Password { get; set; } = string.Empty;
}