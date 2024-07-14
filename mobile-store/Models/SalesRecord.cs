using System;
using System.Collections.Generic;

namespace mobile_store.Models;

public  class SalesRecord
{
    public int? Id { get; set; }

    public int? UserId { get; set; }

    public int SaleId { get; set; }

    public int? BuyerId { get; set; }

    public int? SalerManId { get; set; }

    public DateOnly? Date { get; set; }

    public int? Discount { get; set; }

    public double? DiscountedAmount { get; set; }

    public int? TotalSold { get; set; }

    public virtual User? User { get; set; }
}
