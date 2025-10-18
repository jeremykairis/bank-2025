using System;

namespace Models
{
    abstract class Account
    {
        public string Number { get; }
        public decimal Balance { get; protected set; }
        public Person Owner { get; }

        abstract public Account(string number, Person owner, decimal initialBalance = 0)
        {
            if (string.IsNullOrWhiteSpace(number))
            {
                throw new ArgumentException("Account number cannot be empty.", nameof(number));
            }

            Number = number;
            Owner = owner ?? throw new ArgumentNullException(nameof(owner));
            Balance = initialBalance;
        }

        public virtual void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount must be positive.");
                return;
            }
            Balance += amount;
            Console.WriteLine($"Deposit of ${amount} successful. New balance: ${Balance}");
        }

        public virtual void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be positive.");
            }
        }
    }
}