using System;

namespace Models
{
    public abstract class Account
    {
        public string Number { get; }
        public decimal Balance { get; protected set; }
        public Person Owner { get; }


        protected Account(string number, Person owner, decimal initialBalance = 0)
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
                Console.WriteLine("Le montant du dépôt doit être positif.");
                return;
            }
            Balance += amount;
            Console.WriteLine($"Dépôt de ${amount} effectué. Nouveau solde : ${Balance}");
        }

        public virtual void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Le montant du retrait doit être positif.");
            }
        }

        protected abstract decimal CalculateInterest();
    }
}