using Microsoft.AspNetCore.Http.HttpResults;
using mobile_store.DomainModels;
using mobile_store.DTOs.ResponseDto;
using mobile_store.Models;
using mobile_store.Repository.IRepository;
using mobile_store.Services.IServices;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace mobile_store.Services
{
    public class SaleService : ISaleService
    {
        private readonly IRepository<Models.Sale> _saleRepository;
        private readonly IRepository<Models.SalesRecord> _salesRecordRepository;
        public SaleService(IRepository<Models.Sale> saleRepository, IRepository<Models.SalesRecord> salesRecordRepository)
        {
            _saleRepository = saleRepository;
            _salesRecordRepository = salesRecordRepository;
        }
        public async Task<SaleRecordWithSaleDetails> GetSaleRecordById(int id)
        {
            var salesRecord = _salesRecordRepository.GetById(id);

            var sale = _saleRepository.GetById((int)salesRecord.SaleId);

            return new SaleRecordWithSaleDetails()
            {
                SalesRecord = new DomainModels.SalesRecord()
                {
                    Id = salesRecord.Id,
                    UserId = salesRecord.UserId,
                    ProductSaleId = salesRecord.ProductSaleId,
                    CreatedBy = salesRecord.CreatedBy,
                    UpdatedBy = salesRecord.UpdatedBy,
                    CreatedOn = salesRecord.CreatedOn,
                    UpdateOn = salesRecord.UpdateOn,
                    BuyerId = salesRecord.BuyerId,
                    SalerManId = salesRecord.SalerManId,
                    RecordsDate = salesRecord.RecordsDate,
                    Discount = salesRecord.Discount,
                    DiscountedAmount = salesRecord.DiscountedAmount,
                    TotalSold = salesRecord.TotalSold
                },
                Sale = new DomainModels.Sale()
                {
                    Id = sale.Id,
                    SaleDate = sale.SaleDate,
                    Discount = sale.Discount,
                    BasePrice = sale.BasePrice,
                    ShowPrice = sale.ShowPrice,
                    DiscountedAmount = sale.DiscountedAmount
                }
            };

        }
    }
}