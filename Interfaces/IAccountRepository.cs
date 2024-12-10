using BankAccountManagement.Models;

namespace BankAccountManagement.Interfaces
{
    public interface IAccountRepository
    {
        int CreateAccount(Account account);
        Account GetAccountByID(int accountID);

        bool UpdateAccountBal(int accountID, decimal newBalance);

        bool DeleteAccountBal(int accountID);   

    }
}
