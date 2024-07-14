using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace mobile_store.Controllers
{
    [ApiController]
    public class ProductController : BaseAPIController
    {
        [HttpGet]
        public IActionResult ReturnHello()
        {
            return Ok("Hello-2");
        }
    }
}
