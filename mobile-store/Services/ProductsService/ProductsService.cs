using mobile_store.Models;
using mobile_store.Repository.IRepository;


namespace mobile_store.Services.ProductService
{
    public class ProductsService : Services.ProductsService.IProductsService.IProductsService
    {
        private readonly IRepository <Products> productsrepo;

        public ProductsService(IRepository <Products> _productsrepo) 
        {
            productsrepo = _productsrepo;
        }

        public async Task CreateProducts(Products products)
        {
            await productsrepo.Add(products);
        }

        public bool UpdateProducts(Products products)
        {
            productsrepo.Update(products);
            return true;
        }

        public bool DeleteProducts(string productName)
        {
            try
            {
                var DataList = productsrepo.GetAll().Where(x => x.ProductName == productName).ToList();
                foreach (var item in DataList)
                {
                    productsrepo.Delete(item);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }

        public IEnumerable<Products> GetAllProducts()
        {
            return productsrepo.GetAll();
        }

        public Products GetProductsById(int id)
        {
            return productsrepo.GetById(id);
        }


    }
}
