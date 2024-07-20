using System;
using System.Collections.Generic;

namespace mobile_store.Models;

public partial class Deals : BaseEntityModel
{

    public DateOnly? SaleDate { get; set; }

    public int? Discount { get; set; }

    public double? BasePrice { get; set; }

    public double? ShowPrice { get; set; }

    public double? DiscountedAmount { get; set; }
}
