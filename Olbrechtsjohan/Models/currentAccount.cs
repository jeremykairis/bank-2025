using System;
using Models;
using Abstraction;

namespace Models
{
   public class CurrentAccount : Account
{
    private decimal _lineOfCredit;
    
    public decimal LineOfCredit 
    { 
        get => _lineOfCredit;
        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(LineOfCredit), 
                    "La ligne de crédit doit être supérieure ou égale à 0.");
            }
            _lineOfCredit = value;
        }
    }
        public CurrentAccount(string number, Person owner) 
        : base(number, owner)
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