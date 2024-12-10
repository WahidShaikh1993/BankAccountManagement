using System.Data;
using BankAccountManagement.Models;
using BankAccountManagement.Interfaces;
using Microsoft.Data.SqlClient;

namespace BankAccountManagement.Repositories
{
    public class AccountRepository : IAccountRepository
    {

        private readonly string _connectionString;

        public AccountRepository(string connectionString)

        {
            _connectionString = connectionString;
        }

        public int CreateAccount(Account account)

        {
            using (SqlConnection connection = new SqlConnection(_connectionString))

            {
                string query = "Insert INTO Accounts (AccountHolderName, Balance, AccountType)" +
                        "Values (@AccountHolderName, @Balance, @AccountType); SELECT SCOPE_IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AccountHolderName", account.AccountHolderName);
                command.Parameters.AddWithValue("@Balance", account.Balance);
                command.Parameters.AddWithValue("@AccountType", account.Balance);

                connection.Open();
                int newAccountId = Convert.ToInt32(command.ExecuteScalar());
                return newAccountId;
            }
        }

        public Account GetAccountByID(int accountId)

        {
            using (SqlConnection connection = new SqlConnection(_connectionString))

            {
                string query = "Select * from Accounts where AccountID = @AccountID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AccountID", accountId);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    return new Account
                    {
                        AccountID = reader.GetInt32(0),
                        AccountHolderName = reader.GetString(1),
                        Balance = reader.GetInt32(2),
                        AccountType = reader.GetString(3),
                        CreatedDate = reader.GetDateTime(4),
                    };
                }
                return null;
            }
        }

        public bool UpdateAccountBal(int accountID, decimal newBalance)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))

            {
                string query = "Update Accounts Set Balance = @Balance Where AccountID = @AccountID ";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@AccountID", accountID);
                command.Parameters.AddWithValue("@Balance", newBalance);

                connection.Open();
                int rowAffected = command.ExecuteNonQuery();
                return rowAffected > 0;
            }
        }


    }
}