namespace mobile_store.Models
{
    public class OrderProductId : BaseEntityModel
    { 
        public int? OrderId { get; set; }

        public int? ProductId { get; set; }
    }
}
