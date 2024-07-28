using mobile_store.Models;
using mobile_store.Repository.IRepository;

namespace mobile_store.Services.TransactionsService
{
    public class TransactionsService : Services.TransactionService.ITransactionService.ITransactionsService
    {
        private readonly IRepository<Transactions> transactionrepo;

        public TransactionsService(IRepository<Transactions> _transactionrepo) 
        {
          transactionrepo = _transactionrepo;
        }

        public async Task CreateTransaction(Transactions transactions)
        {
           await transactionrepo.Add(transactions);
        }

        public bool DeleteTransaction(int id)
        {
            try
            {
                var DataList = transactionrepo.GetAll().Where(x => x.Id == id).ToList();
                foreach (var item in DataList)
                {
                    transactionrepo.Delete(item);
                }
                return true;
            }
            catch (Exception)
            {
                return true;
            }
        }
        public bool UpdateTransaction(Transactions transactions)
        {
            transactionrepo.Update(transactions);
            return true;
        }

        public IEnumerable<Transactions> GetAllTransactions()
        {
            return transactionrepo.GetAll();
        }

        public Transactions GetTransactionsById(int id) 
        {
            return transactionrepo.GetById(id);
        }
    }
}
