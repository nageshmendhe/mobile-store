using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using mobile_store.Models;
using mobile_store.Repository.IRepository;

namespace mobile_store.Services.BrandService
{
    public class BrandService : Services.BrandService.IBrandService.IBrandService
    {
        private readonly IRepository <Brand> brandsrepo;

        public BrandService(IRepository<Brand> _brandsrepo)
        {
            brandsrepo = _brandsrepo;
        }
        public async Task CreateBrand(Brand brand)
        {
            await brandsrepo.Add(brand);
        }

        public bool DeleteBrand(string brandName)
        {
            try
            {
                var DataList = brandsrepo.GetAll().Where(x => x.BrandName == brandName).ToList();
                foreach (var item in DataList)
                {
                    brandsrepo.Delete(item);
                }
                return true;
            }
            catch (Exception) 
            {
                return true;
            }
        }
        public bool UpdateBrand(Brand brand) 
        {
            brandsrepo.Update(brand);
            return true;
        }

        public IEnumerable<Brand> GetAllBrands() 
        {
        return brandsrepo.GetAll();
        }

        public Brand GetBrandById(int id)
        {
           return brandsrepo.GetById(id);
        }
    }
}
