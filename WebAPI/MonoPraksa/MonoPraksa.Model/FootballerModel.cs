using System.ComponentModel.DataAnnotations;

namespace MonoPraksa
{
    public class Footballer
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        [Required]
        public string PlayerName { get; set; }
        public DateOnly DateOfBirth { get; set; }
    }
}
