using System;
using System.Collections.Generic;

namespace mobile_store.Models;

public  class Transaction : BaseEntityModel
{
    public string? TransactionType { get; set; }

    public double? TransactionAmount { get; set; }

    public DateOnly? TransactionDate { get; set; }
}
