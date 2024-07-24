using System;
using System.Collections.Generic;

namespace mobile_store.Models;

public partial class Order : BaseEntityModel
{

    public int? DealsId { get; set; }

    public string? OrderName { get; set; }

    public int? UsersId { get; set; }

    public int? BuyerId { get; set; }

    public int? CreatedBy { get; set; }

    public int? UpdatedBy { get; set; }

    public DateOnly? CreatedOn { get; set; }

    public DateOnly? UpdatedOn { get; set; }

    public int? SalerManId { get; set; }

    public DateOnly? OrdersDate { get; set; }

    public int? Discount { get; set; }

    public double? DiscountedAmount { get; set; }

    public int? TotalSold { get; set; }

}
