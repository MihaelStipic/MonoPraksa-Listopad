using System;
using System.Collections.Generic;

namespace MonoPraksa.Model;

public partial class Club
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Country { get; set; } = null!;

    public virtual ICollection<Footballer> Footballers { get; set; } = new List<Footballer>();
}
