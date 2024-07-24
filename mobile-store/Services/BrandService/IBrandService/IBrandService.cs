using mobile_store.Models;

namespace mobile_store.Services.BrandService.IBrandService
{
    public interface IBrandService
    {
        public  Task CreateBrand(Brand brand);

        public IEnumerable<Brand> GetAllBrands();

        public bool DeleteBrand(string brandName);

        public bool UpdateBrand(Brand brand);

        

        public Brand GetBrandById(int id);
    }
}
