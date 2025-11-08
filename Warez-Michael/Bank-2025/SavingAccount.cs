using System;

public class SavingAccount : IBankAccount
{
    public string Number { get; set; }
    public double Balance { get; private set; }
    public double InterestRate { get; private set; }
    public DateTime DateLastWithdraw { get; private set; }
    

    // Constructeur principal
    public SavingAccount(string number, double balance, double interestRate)
    {
    
        Number = number;
        Balance = balance;
        InterestRate = interestRate;
        DateLastWithdraw = DateTime.MinValue;
        
    }

    // Constructeur simplifié
    
    public SavingAccount(string number) : this(number, 0.0, 0.02)
    {
    }

    // Appliquer les intérêts
    public void ApplyInterest()
    {
        Balance += Balance * InterestRate;
    }

    // Dépôt
    public void Deposit(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Le montant du dépôt doit être positif.");
            return;
        }
        Balance += amount;
    }

    // Retrait avec délai de 30 jours
    public void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Le montant du retrait doit être positif.");
            return;
        }

        if ((DateTime.Now - DateLastWithdraw).TotalDays < 30)
        {
            Console.WriteLine("Retrait refusé : vous devez attendre 30 jours entre deux retraits.");
            return;
        }

        if (amount > Balance)
        {
            Console.WriteLine("Solde insuffisant.");
            return;
        }

        Balance -= amount;
        DateLastWithdraw = DateTime.Now;
    }
}
