using System;
using System.Dynamic;
using Models;

public class CurrentAccount
{
    public string number { get; set; }
    public readonly decimal balance { get; set; }

    public DateTime DateLastWithdraw { get; set; }

    public string LastName { get; set; }

   public void Withdraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("montant +.");
                return;
            }
            if (amount > Balance)
            {
                Console.WriteLine("sold insuffiasand.");
                return;
            }
            Balance -= amount;
            Console.WriteLine($"${amount} he ${Balance}");
        }
    public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("le montant doit etre +e.");
                return;
            }

            Balance += amount;
            Console.WriteLine($"${amount} felisitation nouvlle balance ${Balance}");
        }




}