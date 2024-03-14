namespace Challenge3
{
    internal class Bank
    {
        private List<BankAccount> accounts;

        public Bank()
        {
            accounts = new List<BankAccount>();
        }

        public void AddAccount(BankAccount account)
        {
            accounts.Add(account);
        }

        public double BalanceAggregatedAccounts()
        {
            return accounts.Sum(account => account.Balance);
        }

        public void PrintOverdrawnAccounts()
        {
            var overdrawnAccounts = accounts.Where(account => account.IsOverdrawn());

            foreach (var account in overdrawnAccounts)
            {
                Console.WriteLine($"{account.Owner}'s account with balance {account.Balance}");
            }
        }

        public void PrintTransactionHistory(string accountNumber)
        {
            foreach (BankAccount account in accounts)
            {
                if (account.AccountNumber == accountNumber)
                {
                    account.PrintTransactionHistory();
                    return;
                }
            }
            Console.WriteLine($"Account {accountNumber} not found.");
        }
    }
}
