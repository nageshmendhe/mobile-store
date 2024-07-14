using mobile_store.Models;

namespace mobile_store.DomainModels
{
    public class SalesRecord
    {
        public int? Id { get; set; }

        public int? UserId { get; set; }

        public int? BuyerId { get; set; }

        public int? SalerManId { get; set; }

        public DateOnly? Date { get; set; }

        public int? Discount { get; set; }

        public double? DiscountedAmount { get; set; }

        public int? TotalSold { get; set; }
    }
}
