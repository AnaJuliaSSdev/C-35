namespace Challenge3
{
    internal class BankAccount
    {
        public string Owner { get; }
        public double Balance { get; private set; }
        public string AccountNumber { get; }

        private readonly List<string> transactionHistory;

        public BankAccount(string owner, double initialBalance, string accountNumber)
        {
            Owner = owner;
            Balance = initialBalance;
            AccountNumber = accountNumber;
            transactionHistory = new List<string>();
        }
        public void Deposit(double amount)
        {
            Balance += amount;
            transactionHistory.Add($"Deposited {amount}.");
        }

        public bool Withdraw(double amount)
        {
            if (amount > Balance)
            {
                Console.WriteLine("Insufficient funds");
                return false;
            }
            Balance -= amount;
            transactionHistory.Add($"Withdrawn {amount}. Remaining balance: {Balance}");
            return true;
        }

        public void ApplyInterest(double interestRate)
        {
            double interest = Balance * interestRate / 100;
            Balance -= interest;
            transactionHistory.Add($"Interest of {interest} applied to account {AccountNumber}.");
        }

        public void Transfer(BankAccount destinationAccount, double amount)
        {
            if (Withdraw(amount))
            {
                destinationAccount.Deposit(amount);
                transactionHistory.Add($"Transferred {amount} from account {AccountNumber} to account {destinationAccount.AccountNumber}.");
            }
            else
            {
                Console.WriteLine("Transfer failed. Insufficient funds to complete the transaction.");
            }
        }

        public bool IsOverdrawn()
        {
            return Balance < 0;
        }

        public void PrintTransactionHistory()
        {
            Console.WriteLine($"Transaction history for account {AccountNumber}:");
            foreach (string transaction in transactionHistory)
            {
                Console.WriteLine(transaction);
            }
        }
    }
}
