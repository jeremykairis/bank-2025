using System;

namespace Models
{
    public class SavingAccount : Account
    {
        public DateTime? DateLastWithdraw { get; private set; }

        public SavingAccount(string number, Person owner, decimal initialBalance = 0)
            : base(number, owner, initialBalance)
        {
        }

        public override void Withdraw(decimal amount)
        {
            base.Withdraw(amount); 

            if (amount > Balance)
            {
                Console.WriteLine("insufficient funds.");
                return;
            }

            Balance -= amount;
            DateLastWithdraw = DateTime.Now;
            Console.WriteLine($" retrai ${amount} . nouvelle: ${Balance}");
        }
    }
}
