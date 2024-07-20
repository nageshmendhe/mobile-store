using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mobile_store.Models;
using mobile_store.Services.ProductsService.IProductsService;



namespace mobile_store.Controllers
{  

    public class ProductsController : BaseAPIController
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }
        //add product
        [HttpPost]
        public IActionResult AddProducts (Products products)
        {
            if (products == null)
                return BadRequest();
            if (ModelState.IsValid)
                return Ok(_productsService.CreateProducts(products));
            return BadRequest();
         
        }
        //delete product
        [HttpDelete]
        public IActionResult DeleteProducts (String productName)
        {
        if (productName == null)
                return BadRequest();
            if (ModelState.IsValid)
                return Ok(_productsService.DeleteProducts(productName));
            return BadRequest();
        }
        //update product
        [HttpPatch]
        public IActionResult UpdateProducts(Products products) 
        {
        if (_productsService.UpdateProducts(products))
                return Ok();
        return BadRequest();
        }
        //get all
        [HttpGet]
        public ActionResult<IEnumerable<Products>> GetAllProducts()
        {
            try 
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                return Ok(_productsService.GetAllProducts());
            }
            catch (Exception ex) 
            {
              return BadRequest($"{ex.Message} {ex.StackTrace}");
            }
        }
        //get by id 
        [HttpGet]
        public ActionResult<Products> GetProductsById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var data = _productsService.GetProductsById(id);
            return Ok(data);
        }
    }
}
