﻿using System;
using System.Collections.Generic;

namespace mobile_store.Models;

public partial class Product
{
    public int Id { get; set; }

    public string? ProductType { get; set; }

    public int? BrandId { get; set; }

    public string? ProductName { get; set; }

    public string? ProductDetails { get; set; }

    public double? ProductPricing { get; set; }

    public DateOnly? ProductCreation { get; set; }

    public DateOnly? ProductModification { get; set; }

    public virtual Brand? Brand { get; set; }

    public virtual ICollection<ProductSale> ProductSales { get; set; } = new List<ProductSale>();
}
