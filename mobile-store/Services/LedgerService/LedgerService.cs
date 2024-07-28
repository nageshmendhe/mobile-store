using mobile_store.DTOs.RequestDto;
using mobile_store.Models;
using mobile_store.Repository.IRepository;

namespace mobile_store.Services.LedgerService
{
    public class LedgerService : ILedgerService.ILedgerService
    {
        private readonly IRepository<Products> _productRepo;

        private readonly IRepository<Deals> _dealRepo;

        private readonly IRepository<Order> _orderRepo;

        private readonly IRepository<OrderProductId> _orderProductIdRepo;

        public LedgerService(IRepository<Products> productRepo, IRepository<Deals> dealRepo, IRepository<Order> orderRepo, IRepository<OrderProductId> orderProductIdRepo)
        {
            _productRepo = productRepo;
            _dealRepo = dealRepo;
            _orderRepo = orderRepo;
            _orderProductIdRepo = orderProductIdRepo;
        }


        public async Task<string> AddOrderData(OrderRequestDto orderRequestDto)
        {
            //get price of each product by respective ids
            var productList = _productRepo.Table.Where(s => orderRequestDto.ProductIds.Contains(s.Id)).ToList();

            //int? discountPercent = null;

            ////get deal by id
            //var deal = _dealRepo.Table.FirstOrDefault(d => d.Id == orderRequestDto.DealId);
            //if(deal != null)
            //{
            //    discountPercent = deal.Discount;
            //}

            int? discountPercent = _dealRepo.Table.FirstOrDefault(d => d.Id == orderRequestDto.DealId)?.Discount;

            //calculate discounted price and then add sum in transaction table
            int totalDiscountedOrderPrice = 0;
            int totalPrice = 0;
            foreach (var product in productList)
            {
                int discountedPrice = (int)product.ProductPricing * ((100 - (int) discountPercent) / 100);
                totalDiscountedOrderPrice = totalDiscountedOrderPrice + discountedPrice;
                totalPrice = totalPrice + (int)product.ProductPricing;
            }
            var order = new Order()
            {
                DealsId = orderRequestDto.DealId,
                SalerManId = orderRequestDto.SalesManId,
                OrdersDate = DateOnly.FromDateTime(DateTime.Today),
                TotalSold = productList.Count,
                DiscountedAmount = totalDiscountedOrderPrice,
                Discount = discountPercent,
                TotalAmount = totalPrice,

            };

            //create one order and salesman id as well
            _orderRepo.Add(order);

            //add product in order to product mapping under that order id
            List<OrderProductId> orderProductIds = new List<OrderProductId>();
            foreach (var product in productList)
            {
                orderProductIds.Add(new OrderProductId()
                {
                    OrderId = order.Id,
                    ProductId = product.Id
                });
            }
            await _orderProductIdRepo.AddAll(orderProductIds);

            return "Order Created";
        }
    }
}
