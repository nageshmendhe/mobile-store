using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mobile_store.Models;
using mobile_store.Services.DealsService.IDealsService;

namespace mobile_store.Controllers
{
    public class DealsController : BaseAPIController
    {
        private readonly IDealsService _dealsService;

        public DealsController(IDealsService dealsService)
        {
            _dealsService = dealsService;
        }
        //deals
        //add deals
        [HttpPost]
        public IActionResult AddDeals(Deals deals)
        {
            if (deals == null)
                return BadRequest();
            if (ModelState.IsValid)
                _dealsService.CreateDeals(deals);
            return Ok();
            return BadRequest();

        }
        //delete deals
        [HttpDelete]
        public IActionResult DeleteDeals(string dealsName)
        {
            if (_dealsService == null)
                return BadRequest();
            if (ModelState.IsValid)
                _dealsService.DeleteDeals(dealsName);
            return Ok();
            return BadRequest();
        }
        //update
        [HttpPatch]
        public IActionResult UpdateDeals(Deals deals)
        {
            if (_dealsService.UpdateDeals(deals))
                return Ok();
            return BadRequest();
        }
        //getall
        [HttpGet]
        public ActionResult<IEnumerable<Deals>> GetAllDeals()
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                return Ok(_dealsService.GetAllDeals());
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} {ex.StackTrace}");
            }
        }
        //get by id
        [HttpGet]
        public ActionResult<Deals> GetDealsById(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var data = _dealsService.GetDealsById(id);
            return Ok(data);
        }
    }
}
