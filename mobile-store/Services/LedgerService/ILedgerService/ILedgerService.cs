using Microsoft.AspNetCore.Mvc;
using mobile_store.DTOs.RequestDto;
using mobile_store.DTOs.ResponseDto;

namespace mobile_store.Services.LedgerService.ILedgerService
{
    public interface ILedgerService
    {
        Task<string> AddOrderData(OrderRequestDto orderRequestDto);

        public  Task<List<OrderResponseDto>> GetAllOrders();    }
}
