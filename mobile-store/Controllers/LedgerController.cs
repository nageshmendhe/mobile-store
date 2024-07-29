using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mobile_store.DTOs.RequestDto;
using mobile_store.DTOs.ResponseDto;
using mobile_store.Services.LedgerService.ILedgerService;

namespace mobile_store.Controllers
{
    public class LedgerController : BaseAPIController
    {
        private readonly ILedgerService _ledgerService;
        public LedgerController(ILedgerService ledgerService)
        {
            _ledgerService = ledgerService;
        }

        [HttpPost]
        public async Task <IActionResult> AddOrderData([FromBody] OrderRequestDto orderRequestDto)
        {
            var temp = await _ledgerService.AddOrderData(orderRequestDto);
            return Ok(temp);
        }

        [HttpGet]
        public async Task <IActionResult> GetAllOrders()
        {
            try
            {
                List<OrderResponseDto> orders = await _ledgerService.GetAllOrders();
                return Ok(orders);
            }
            catch (Exception ex) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An error occurred while processing your request.", details = ex.Message });
            }
        }
    }
}
