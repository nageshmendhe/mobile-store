using mobile_store.DTOs.RequestDto;

namespace mobile_store.Services.LedgerService.ILedgerService
{
    public interface ILedgerService
    {
        Task<string> AddOrderData(OrderRequestDto orderRequestDto);
    }
}
