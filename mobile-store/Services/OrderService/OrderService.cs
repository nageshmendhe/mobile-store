using mobile_store.Models;
using mobile_store.Repository.IRepository;

namespace mobile_store.Services.OrderService
{
    public class OrderService : Services.OrderService.IOrderService.IOrderService
    {
        private readonly IRepository <Order> ordersrepo;

        public OrderService (IRepository <Order> _ordersrepo)
        {
            ordersrepo = _ordersrepo;
        }

        public async Task CreateOrders(Order order)
        {
            await ordersrepo.Add(order);
        }

        public bool DeleteOrders(string orderName)
        {
            try
            {
                var DataList = ordersrepo.GetAll().Where(x => x.OrderName == orderName).ToList();
                foreach (var item in DataList)
                {
                    ordersrepo.Delete(item);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public bool UpdateOrders(Order order)
        {
            ordersrepo.Update(order);
            return true;
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return ordersrepo.GetAll();
        }

        public Order GetOrderById(int id)
        {
            return ordersrepo.GetById(id);
        }


    }
}
