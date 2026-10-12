using System.ComponentModel.DataAnnotations;

namespace MonoPraksa.Model;

public class RegisterRequest
{
    [Required]
    [EmailAddress]
    [StringLength(55)]
    public string Email { get; set; } = string.Empty;
    [Required]
    [StringLength(72, MinimumLength = 8)]
    public string Password { get; set; } = string.Empty;
}