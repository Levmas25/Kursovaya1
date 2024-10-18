using System;
using System.Collections.Generic;

namespace Kursovaya1.Models;

public partial class Test
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string SecondName { get; set; } = null!;

    public string? LastName { get; set; }

    public string FullName { get { return SecondName + " " + FirstName + " " + LastName; } }

    public string Group { get; set; } = null!;

    public int? Mark { get; set; }

    public DateOnly Date { get; set; }

    public DateTime DateTime { get { return Date.ToDateTime(new TimeOnly(0, 0, 0)); } }

    public string StringDate { get { return Date.ToString("d"); } } 

    public string Discipline { get; set; } = null!;
}
