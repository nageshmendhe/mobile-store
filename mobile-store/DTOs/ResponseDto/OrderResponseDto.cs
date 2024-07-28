using mobile_store.Models;

namespace mobile_store.DTOs.ResponseDto
{
    public class OrderResponseDto
    {
        public List<OrderDto> Orders { get; set; }
    }

    public class OrderDto
    {
        public int? DealsId { get; set; }

        public string? OrderName { get; set; }

        public int? UsersId { get; set; }

        public int? BuyerId { get; set; }

        public int? CreatedBy { get; set; }

        public int? UpdatedBy { get; set; }

        public DateOnly? CreatedOn { get; set; }

        public DateOnly? UpdatedOn { get; set; }

        public string SalerManName { get; set; }

        public DateOnly? OrdersDate { get; set; }

        public int? Discount { get; set; }

        public double? DiscountedAmount { get; set; }

        public int? TotalSold { get; set; }

        public List<Products> Product { get; set; }
    }
}
