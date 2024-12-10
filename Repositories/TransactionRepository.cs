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
    }
}
