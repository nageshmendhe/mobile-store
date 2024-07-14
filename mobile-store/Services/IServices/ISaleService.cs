using mobile_store.DTOs.ResponseDto;

namespace mobile_store.Services.IServices
{
    public interface ISaleService
    {
        Task<SaleRecordWithSaleDetails> GetSaleRecordById(int id);
    }
}
