using System.Transactions;

namespace BankAccountManagement.Interfaces
{
    public interface ITransactionRepository
    {
        int AddTransaction(Transaction transaction);

        Transaction GetTransaction(int transactionId);
    }
}
