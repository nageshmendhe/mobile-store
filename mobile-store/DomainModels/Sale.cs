namespace mobile_store.DomainModels
{
    public class Sale
    {
        public int? Id { get; set; }

        public int? SaleId { get; set; }

        public DateOnly? Date { get; set; }

        public int? Discount { get; set; }

        public double? BasePrice { get; set; }

        public double? ShowPrice { get; set; }

        public double? DiscountedAmount { get; set; }
    }
}
