using mobile_store.Models;
using mobile_store.Repository.IRepository;


namespace mobile_store.Services.TransactionService
{
    public class TransactionService : Services.TransactionService.ITransactionService.ITransactionService
    {
        private readonly IRepository<Transaction> transactionrepo;
    }
}
