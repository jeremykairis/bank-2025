using System;
using Models;

namespace Models
{
    public class CurrentAccount : Account
    {
        public decimal LineOfCredit { get; set; }

        public CurrentAccount(string number, Person owner, decimal initialBalance = 0)
            : base(number, owner, initialBalance)
        {
            LineOfCredit = 0;
        }

        public override void Withdraw(decimal amount)
        {
            base.Withdraw(amount);

            if (amount > Balance + LineOfCredit)
            {
                Console.WriteLine("Le montant du retrait dépasse le solde et la ligne de crédit.");
                return;
            }

            Balance -= amount;
            Console.WriteLine($"Retrait de ${amount} effectué. Nouveau solde : ${Balance}");
        }

        protected override decimal CalculateInterest()
        {
            if (Balance >= 0)
            {
                return Balance * 0.03m;
            }
            return Balance * 0.0975m;
        }
    }
}