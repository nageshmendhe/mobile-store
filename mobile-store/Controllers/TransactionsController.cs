using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mobile_store.Models;
using mobile_store.Services.TransactionService.ITransactionService;
using System.Transactions;
using Transactions = mobile_store.Models.Transactions;

namespace mobile_store.Controllers
{
    public class TransactionsController : BaseAPIController
    {
        private readonly ITransactionsService _transactionService;

        public  TransactionsController (ITransactionsService transactionService)
        {
            _transactionService = transactionService;
        }
        //add transaction
        [HttpPost]
        public IActionResult AddTransaction (Transactions transactions)
        {
            if (transactions == null)
                return BadRequest();
            if (ModelState.IsValid)
                 return Ok(_transactionService.CreateTransaction(transactions));
            return BadRequest();
        }
        //delete 
        [HttpDelete]
        public IActionResult DeleteTransaction (int id) 
        {
            if (id == null)
                return BadRequest();
            if (ModelState.IsValid)
                return Ok(_transactionService.DeleteTransaction(id));
            return BadRequest();
        
        }
        //update
        [HttpPatch]
        
        public IActionResult UpdateTransaction(Transactions transactions)
        {
            if(_transactionService.UpdateTransaction(transactions))
                return Ok();
            return BadRequest();
        }
        //get all
        [HttpGet]
        public ActionResult<IEnumerable<Transactions>> GetAllTransactions()
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                return Ok(_transactionService.GetAllTransactions());
            }
            catch (Exception ex)
            {
                return BadRequest($"{ex.Message} {ex.StackTrace}");
            }
        }
        //get by id
        [HttpGet]
        public ActionResult <Transactions> GetTransactionsById(int id)
        { 
            if (!ModelState.IsValid)
                return BadRequest();
            var data = _transactionService.GetTransactionsById(id);
            return Ok(data);


        }

    }

}
