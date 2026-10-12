using System;
using System.Collections.Generic;
using System.Text;

namespace MonoPraksa.Model;

public class UserDto
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Role { get; set; } = "User";
}