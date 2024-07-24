using mobile_store.Models;
using mobile_store.Repository.IRepository;

namespace mobile_store.Services.DealsService
{
    public class DealsService : Services.DealsService.IDealsService.IDealsService
    {
        private readonly IRepository <Deals> dealsrepo;

        public DealsService(IRepository<Deals> _dealsrepo)
        {
            dealsrepo = _dealsrepo;
        }

        public async Task CreateDeals(Deals deals)
        {
            await dealsrepo.Add(deals);
        }

        public bool DeleteDeals(string dealsName)
        {
            try
            {
                var DataList = dealsrepo.GetAll().Where(x => x.DealsName == dealsName).ToList();
                foreach(var item in DataList)
                {
                    dealsrepo.Delete(item);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public bool UpdateDeals(Deals deals)
        {
            dealsrepo.Update(deals);
            return true;
        }

        public IEnumerable<Deals> GetAllDeals()
        {
            return dealsrepo.GetAll();
        }

        public Deals GetDealsById(int id)
        {
            return dealsrepo.GetById(id);
        }
    }
}
