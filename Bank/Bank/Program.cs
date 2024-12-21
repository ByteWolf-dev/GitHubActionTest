using System;
using System.Collections.Generic;

namespace Bank
{
    // Represents a bank account
    class BankAccount
    {
        public string AccountNumber { get; }
        public string AccountHolder { get; }
        private decimal Balance;

        public BankAccount(string accountNumber, string accountHolder, decimal initialDeposit)
        {
            AccountNumber = accountNumber;
            AccountHolder = accountHolder;
            Balance = initialDeposit;
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine($"Successfully deposited {amount:C} into account {AccountNumber}.");
            }
            else
            {
                Console.WriteLine("Invalid deposit amount. Please enter a positive value.");
            }
        }

        public void Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"Successfully withdrew {amount:C} from account {AccountNumber}.");
            }
            else
            {
                Console.WriteLine("Invalid withdrawal amount or insufficient funds.");
            }
        }

        public void DisplayBalance()
        {
            Console.WriteLine($"Account {AccountNumber} balance: {Balance:C}");
        }
    }

    // Represents the bank system
    class Bank
    {
        private Dictionary<string, BankAccount> accounts = new Dictionary<string, BankAccount>();

        public void CreateAccount(string accountNumber, string accountHolder, decimal initialDeposit)
        {
            if (!accounts.ContainsKey(accountNumber))
            {
                accounts[accountNumber] = new BankAccount(accountNumber, accountHolder, initialDeposit);
                Console.WriteLine($"Account created successfully for {accountHolder} with account number {accountNumber}.");
            }
            else
            {
                Console.WriteLine("Account number already exists. Please use a different account number.");
            }
        }

        public void Deposit(string accountNumber, decimal amount)
        {
            if (accounts.TryGetValue(accountNumber, out var account))
            {
                account.Deposit(amount);
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        public void Withdraw(string accountNumber, decimal amount)
        {
            if (accounts.TryGetValue(accountNumber, out var account))
            {
                account.Withdraw(amount);
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        public void DisplayBalance(string accountNumber)
        {
            if (accounts.TryGetValue(accountNumber, out var account))
            {
                account.DisplayBalance();
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }
    }

    // Main program
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();

            while (true)
            {
                Console.WriteLine("\n--- Bank System Menu ---");
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Check Balance");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Account Number: ");
                        string accountNumber = Console.ReadLine();
                        Console.Write("Enter Account Holder Name: ");
                        string accountHolder = Console.ReadLine();
                        Console.Write("Enter Initial Deposit: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal initialDeposit))
                        {
                            bank.CreateAccount(accountNumber, accountHolder, initialDeposit);
                        }
                        else
                        {
                            Console.WriteLine("Invalid deposit amount.");
                        }
                        break;

                    case "2":
                        Console.Write("Enter Account Number: ");
                        accountNumber = Console.ReadLine();
                        Console.Write("Enter Deposit Amount: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
                        {
                            bank.Deposit(accountNumber, depositAmount);
                        }
                        else
                        {
                            Console.WriteLine("Invalid deposit amount.");
                        }
                        break;

                    case "3":
                        Console.Write("Enter Account Number: ");
                        accountNumber = Console.ReadLine();
                        Console.Write("Enter Withdrawal Amount: ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount))
                        {
                            bank.Withdraw(accountNumber, withdrawAmount);
                        }
                        else
                        {
                            Console.WriteLine("Invalid withdrawal amount.");
                        }
                        break;

                    case "4":
                        Console.Write("Enter Account Number: ");
                        accountNumber = Console.ReadLine();
                        bank.DisplayBalance(accountNumber);
                        break;

                    case "5":
                        Console.WriteLine("Thank you for using the Bank System. Goodbye!");
                        return;

                    default:
                        Console.WriteLine("Invalid option. Please choose a valid menu option.");
                        break;
                }
            }
        }
    }
}
