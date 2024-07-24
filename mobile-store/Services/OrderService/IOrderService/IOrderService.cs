using mobile_store.Models;

namespace mobile_store.Services.OrderService.IOrderService
{
    public interface IOrderService
    {
        public  Task CreateOrders(Order order);

        public bool DeleteOrders(string orderName);

        public bool UpdateOrders(Order order);

        public IEnumerable<Order> GetAllOrders();

        public Order GetOrderById(int id);
    }
}
