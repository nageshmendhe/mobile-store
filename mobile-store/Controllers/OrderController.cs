using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using mobile_store.Models;
using mobile_store.Services.OrderService;
using mobile_store.Services.OrderService.IOrderService;

namespace mobile_store.Controllers
{
    public class OrderController : BaseAPIController
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        //add order
        [HttpPost]
        public IActionResult AddOrders(Order order)
        {
            if (order == null)
                return BadRequest();
            if(ModelState.IsValid)
                return Ok(_orderService.CreateOrders(order));
            return BadRequest();
        }
        //delete 
        [HttpDelete]
        public IActionResult DeleteOrders(string orderName)
        {
            if (orderName == null)
                return BadRequest();
            if (ModelState.IsValid)
                return Ok(_orderService.DeleteOrders(orderName));
            return BadRequest();
        }
        //update
        [HttpPatch]
        public IActionResult UpdateOrders(Order order) 
        {
        if(_orderService.UpdateOrders(order))
                return Ok();
        return BadRequest();
               
        }
        //get all
        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetAllOrders()
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                return Ok(_orderService.GetAllOrders());
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} {ex.StackTrace}");
            }
        }
        //get by id
        [HttpGet]
        public ActionResult<Order> GetOrdersById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var data = _orderService.GetOrderById(id);
            return Ok(data);
        }

    }
    
}
