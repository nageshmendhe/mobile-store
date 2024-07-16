using System;
using System.Collections.Generic;

namespace mobile_store.Models;

public partial class Brand
{
    public int Id { get; set; }

    public string? BrandName { get; set; }

    public DateOnly? CreationDate { get; set; }

    public DateOnly? ModificationDate { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
