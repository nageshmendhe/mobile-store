using System;
using System.Collections.Generic;

namespace mobile_store.Models;

public partial class Transaction
{
    public int Id { get; set; }

    public string? TransactionType { get; set; }

    public double? TransactionAmount { get; set; }

    public DateOnly? TransactionDate { get; set; }
}
