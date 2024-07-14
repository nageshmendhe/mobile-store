using System;
using System.Collections.Generic;

namespace mobile_store.Models;

public partial class Brand
{
    public int? Id { get; set; }

    public string? Name { get; set; }

    public int BrandId { get; set; }

    public virtual Product? Product { get; set; }
}
