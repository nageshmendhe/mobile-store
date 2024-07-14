using System;
using System.Collections.Generic;

namespace mobile_store.Models;

public partial class ProductSale
{
    public int? Id { get; set; }

    public int? SaleId { get; set; }

    public int? ProductId { get; set; }

    public DateOnly? Date { get; set; }

    public int? Quqntity { get; set; }

    public double? ActualAmount { get; set; }

    public double? DoscountedAmount { get; set; }

    public virtual Product? Product { get; set; }

    public virtual SalesRecord? Sale { get; set; }
}
