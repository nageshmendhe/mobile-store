using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mobile_store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        public IActionResult ReturnHello()
        {
            return Ok("Hello");
        }
    }
}
