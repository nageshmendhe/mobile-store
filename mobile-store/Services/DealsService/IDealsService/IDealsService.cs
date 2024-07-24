using Microsoft.AspNetCore.Mvc;
using mobile_store.Models;

namespace mobile_store.Services.DealsService.IDealsService
{
    public interface IDealsService
    {
        public  Task CreateDeals(Deals deals);

        public bool DeleteDeals(string dealsName);

        public bool UpdateDeals(Deals deals);

        public IEnumerable<Deals> GetAllDeals();

        public Deals GetDealsById(int id);


    }
}
