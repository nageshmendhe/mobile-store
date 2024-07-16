using System;
using System.Collections.Generic;

namespace mobile_store.Models;

public partial class SalesRecord : BaseEntityModel
{
    public int Id { get; set; }

    public int? UserId { get; set; }

    public int? ProductSaleId { get; set; }

    public int? SaleId { get; set; }

    public int? BuyerId { get; set; }

    public DateOnly? CreatedBy { get; set; }

    public DateOnly? UpdatedBy { get; set; }

    public DateOnly? CreatedOn { get; set; }

    public DateOnly? UpdateOn { get; set; }

    public int? SalerManId { get; set; }

    public DateOnly? RecordsDate { get; set; }

    public int? Discount { get; set; }

    public double? DiscountedAmount { get; set; }

    public int? TotalSold { get; set; }

    public virtual Sale? Sale { get; set; }

    public virtual User? User { get; set; }
}
