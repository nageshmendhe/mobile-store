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
        public DateOnly? CreatedBy { get; internal set; }
        public int? ProductSaleId { get; internal set; }
        public DateOnly? UpdatedBy { get; internal set; }
        public DateOnly? CreatedOn { get; internal set; }
        public DateOnly? UpdateOn { get; internal set; }
        public DateOnly? RecordsDate { get; internal set; }
    }
}
