using mobile_store.DomainModels;

namespace mobile_store.DTOs.ResponseDto
{
    public class SaleRecordWithSaleDetails
    {
        public Sale Sale { get; set; }

        public SalesRecord SalesRecord { get; set; }
    }
}
