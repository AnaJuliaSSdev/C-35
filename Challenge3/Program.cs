namespace Challenge3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount account1 = new BankAccount("Dragonborn", 50, "2011");
            BankAccount account2 = new BankAccount("Carl Johnson", 200, "2004");
            BankAccount account3 = new BankAccount("Nicolas Cage", -10, "1960");

            Bank bank = new Bank();
            bank.AddAccount(account1);
            bank.AddAccount(account2);
            bank.AddAccount(account3);

            account1.Deposit(1000);
            account1.Deposit(10);

            account2.Transfer(account1, 100);

            account2.ApplyInterest(10);
            account2.Deposit(10);

            account1.PrintTransactionHistory();
            Console.WriteLine("\n");
            account2.PrintTransactionHistory();


            Console.WriteLine($"\nBalance of account {account2.AccountNumber}: {account2.Balance}");
            Console.WriteLine($"\nBalance of account {account1.AccountNumber}: {account1.Balance}");

            double totalBalance = bank.BalanceAggregatedAccounts();
            Console.WriteLine($"\n\nTotal balance of all accounts: {totalBalance}");

            Console.WriteLine("\nOver drawn accounts:");
            bank.PrintOverdrawnAccounts();
        }
    }
}
