using System.Data;
using BankAccountManagement.Models;
using BankAccountManagement.Interfaces;
using Microsoft.Data.SqlClient;

namespace BankAccountManagement.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly string _connectionString;

        public TransactionRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int AddTransaction(Transaction transaction)

        {
            using (SqlConnection connection = new SqlConnection(_connectionString))

            {
                string query = "Insert Into Transactions (TransactionID, AccountID, Amount, TransactionType)" +
                    "Values (@TransactionID, @AccountID, @Amount, @TransactionType); SLECT SCOPE IDENTITY();";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TransactionID", transaction.TransactionID);
                command.Parameters.AddWithValue("@AccountID", transaction.AccountID);
                command.Parameters.AddWithValue("@Amount", transaction.Amount);
                command.Parameters.AddWithValue("@TransactionType", transaction.TransactionType);

                connection.Open();
                int newTransactionID = Convert.ToInt32(command.ExecuteNonQuery());
                return newTransactionID;
            }
        }

        public Transaction GetTransaction(int transactionId)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))

            {
                string query = "SELECT * FROM Transactions WHERE TransactionID = @TransactionID";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TransactionID", transactionId);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                   return new Transaction
                    {
                        TransactionID = reader.GetInt32(0),
                        AccountID = reader.GetInt32(1),
                        Amount = reader.GetInt32(2),
                        TransactionType = reader.GetString(3),
                        TransactionDate = reader.GetDateTime(4),
                    };
                }
                return null;
            }
        }
    }
}
