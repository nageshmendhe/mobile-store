using System;
using System.Collections.Generic;

namespace mobile_store.Models;

public partial class User
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public string? Email { get; set; }

    public string? Number { get; set; }

    public string? Password { get; set; }

    public DateOnly? CreationDate { get; set; }

    public DateOnly? ModificationDate { get; set; }

    public string? Address { get; set; }

    public int? UserRoleId { get; set; }

}
