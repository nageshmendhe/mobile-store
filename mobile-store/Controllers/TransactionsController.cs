using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using mobile_store.Services.TransactionService.ITransactionService;
using System.Transactions;

namespace mobile_store.Controllers
{
    public class TransactionsController : BaseAPIController
    {
        private readonly ITransactionService _transactionService;

        public  TransactionsController (ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }
    }
}
