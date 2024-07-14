using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mobile_store.Services.IServices;

namespace mobile_store.Controllers
{
    [ApiController]
    public class SalesRecordsController : BaseAPIController
    {
        private readonly ISaleService _saleService;

        public SalesRecordsController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        [HttpGet]
        public IActionResult GetSaleRecordById([FromQuery] int id) 
        {
            try
            {
                return Ok(_saleService.GetSaleRecordById(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message + ex.StackTrace);
            }
        }
    }
}
