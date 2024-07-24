namespace mobile_store.Models
{
    public class OrderProductId : BaseEntityModel
    { 
        public DateOnly? OrderId { get; set; }

        public int? ProductId { get; set; }
    }
}
