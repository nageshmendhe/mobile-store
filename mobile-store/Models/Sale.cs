using System;
using System.Collections.Generic;

namespace mobile_store.Models;

public partial class Sale : BaseEntityModel
{
    public int? Id { get; set; }

    public DateOnly? SaleDate { get; set; }

    public int? Discount { get; set; }

    public double? BasePrice { get; set; }

    public double? ShowPrice { get; set; }

    public double? DiscountedAmount { get; set; }
}
