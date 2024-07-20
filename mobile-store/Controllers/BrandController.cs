using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mobile_store.Models;
using mobile_store.Services.BrandService.IBrandService;

namespace mobile_store.Controllers
{
    public class BrandController : BaseAPIController
    {
        private readonly IBrandService _brandServices;
        public BrandController (IBrandService brandServices)
        {
            _brandServices = brandServices;
        }
        //Brand
        //add brand
        [HttpPost]
        public IActionResult AddBrand(Brand brand)
        {
            if (brand == null)
                return BadRequest();
            if (ModelState.IsValid)
                _brandServices.CreateBrand(brand);
            return Ok();
            return BadRequest();

        }
        //delete brand
        [HttpDelete]
        public IActionResult DeleteBrand(string brandName) 
        {
            if (brandName == null)
                return BadRequest();
            if (ModelState.IsValid)
                _brandServices.DeleteBrand(brandName);
            return Ok();
            return BadRequest();
        }
        //update brand
        [HttpPatch]
        public IActionResult UpdateBrand(Brand brand) 
        { 
            if (_brandServices.UpdateBrand(brand))
                return Ok();
            return BadRequest();
        }
        //getall
        [HttpGet]
        public ActionResult<IEnumerable<Brand>> GetAllBrands() 
        {
        try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                return Ok(_brandServices.GetAllBrands());
            }
            catch (Exception ex) 
            {
                return BadRequest($"{ex.Message} {ex.StackTrace}");
            }
        }
        //get by id 
        [HttpGet]
        public ActionResult<Brand> GetBrandById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var data = _brandServices.GetBrandById(id);
            return Ok(data);
        }

    }
}
