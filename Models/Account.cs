namespace BankAccountManagement.Models
{
    public class Account
    {
        public int AccountID { get; set; } // Primary key
        public string AccountHolderName { get; set; } = string.Empty; // Account holder's name
        public decimal Balance { get; set; } // Current balance
        public string AccountType { get; set; } = string.Empty; // Account type (e.g., Savings, Current)
        public DateTime CreatedDate { get; set; } = DateTime.Now; // Date the account was created
    }
}
