namespace BankAccountManagement.Models
{
    public class Transaction
    {
        public int TransactionID { get; set; } // Primary key
        public int AccountID { get; set; } // Foreign key linking to Account
        public decimal Amount { get; set; } // Transaction amount
        public string TransactionType { get; set; } = string.Empty; // Transaction type (Deposit, Withdraw, Transfer)
        public DateTime TransactionDate { get; set; } = DateTime.Now; // Date of the transaction
    }
}
