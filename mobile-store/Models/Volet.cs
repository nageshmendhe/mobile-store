using System;
using System.Collections.Generic;

namespace mobile_store.Models;

public partial class Volet
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public DateOnly? Date { get; set; }

    public string? Card { get; set; }

    public string? Online { get; set; }

    public double? TotalAmount { get; set; }

    public virtual User? User { get; set; }
}
