using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MonoPraksa.Model;

public partial class FootballerEdit
{

    public Guid ClubId { get; set; }
    [Required]
    [StringLength(60, MinimumLength = 2)]
    public string PlayerName { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }
    [Range(1, 100)]
    public int Rating { get; set; }

    
}
