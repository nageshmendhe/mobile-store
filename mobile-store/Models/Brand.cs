using System;
using System.Collections.Generic;

namespace mobile_store.Models;

public partial class Brand : BaseEntityModel
{
   

    public string? BrandName { get; set; }

    public DateOnly? CreationDate { get; set; }

    public DateOnly? ModificationDate { get; set; }

}
