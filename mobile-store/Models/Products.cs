using System;
using System.Collections.Generic;

namespace mobile_store.Models;

public partial class Products : BaseEntityModel
{

    public string? Product_Type { get; set; }

    public int? BrandId { get; set; }

    public string? ProductName { get; set; }

    public string? ProductDetails { get; set; }

    public double? ProductPricing { get; set; }

    public DateOnly? ProductCreation { get; set; }

    public DateOnly? ProductModification { get; set; }
   
}
