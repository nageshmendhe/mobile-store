
using System.ComponentModel.DataAnnotations;

namespace mobile_store.Models;

  public  class Brand : BaseEntityModel
{
 
    [Required]

    public string? BrandName { get; set; }

    public DateOnly? CreationDate { get; set; }

    public DateOnly? ModificationDate { get; set; }

}
