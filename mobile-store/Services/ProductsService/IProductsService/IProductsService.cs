using mobile_store.Models;

namespace mobile_store.Services.ProductsService.IProductsService
{
    public interface IProductsService
    {
        public  Task CreateProducts(Products products);

        public IEnumerable<Products> GetAllProducts();

        public bool DeleteProducts(string productName);

        public bool UpdateProducts(Products products);

        public Products GetProductsById(int id);
    }
}
