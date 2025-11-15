using System;
using Loic_Boulanger.Domaine;

class Program
{

    static void Main()
    {
        try
        {
            var owner = new Person("Alice", "Durand");

        // Utilise CurrentAccount (compte courant) avec découvert de 500 €
        var account = new CurrentAccount("12345", owner, 500);

        account.Deposit(1000);
        account.Withdraw(1200);  // OK → solde = -200
        account.Withdraw(400);   // REFUSÉ → dépasserait le découvert

        Console.WriteLine($"\nSolde final du compte {account.Number} : {account.Balance:C}");
        }
    
        catch (Exception ex)
        {
            Console.WriteLine($"Erreur : {ex.Message}");
    }
    }
        
}
