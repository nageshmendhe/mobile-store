using System;
using System.Collections.Generic;

namespace mobile_store.Models;

public  class Sale
{
    public int? Id { get; set; }

    public int? SaleId { get; set; }

    public DateOnly? Date { get; set; }

    public int? Discount { get; set; }

    public double? BasePrice { get; set; }

    public double? ShowPrice { get; set; }

    public double? DiscountedAmount { get; set; }

    public virtual SalesRecord? SaleNavigation { get; set; }
}
