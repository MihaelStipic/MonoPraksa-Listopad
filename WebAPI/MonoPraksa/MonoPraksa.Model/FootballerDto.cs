using System;
using System.Collections.Generic;
using System.Text;

namespace MonoPraksa.Model
{
    public class FootballerDto
    {
        public Guid Id { get; set; }
        public Guid ClubId { get; set; }
        public string PlayerName { get; set; } = null!;
        public DateOnly DateOfBirth { get; set; }
        public int Rating { get; set; }
        public string ClubName { get; set; } = null!;
    }
}
