using mobile_store.Models;

namespace mobile_store.Services.TransactionService.ITransactionService
{
    public interface ITransactionsService
    {
        public Task CreateTransaction(Transactions transaction);

        public bool DeleteTransaction(int id);

        public bool UpdateTransaction(Transactions transactions);

        public IEnumerable<Transactions> GetAllTransactions();

        public Transactions GetTransactionsById(int id);
    }
}
