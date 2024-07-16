using System;
using System.Collections.Generic;

namespace mobile_store.Models;

public partial class ProductSale
{
    public int Id { get; set; }

    public int? ProductId { get; set; }

    public DateOnly? SaleDate { get; set; }

    public int? Quqntity { get; set; }

    public double? ActualAmount { get; set; }

    public double? DoscountedAmount { get; set; }

    public virtual Product? Product { get; set; }
}
