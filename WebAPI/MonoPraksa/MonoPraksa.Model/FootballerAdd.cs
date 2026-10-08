using System;
using System.Collections.Generic;

namespace MonoPraksa.Model;

public partial class FootballerAdd
{
    public Guid ClubId { get; set; }

    public string PlayerName { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public int Rating { get; set; }


}
