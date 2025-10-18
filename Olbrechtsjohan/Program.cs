using static System.Console;
using System;
using Models;

public class Program
{
    public static void Main()
    {
        
        Banque myBank = new Banque("First Bank");
        WriteLine($" {myBank.Name}!");

        
        Client client1 = new Client("Maximus", "Durian", new DateTime(1985, 5, 10), "FR001");
        Client client2 = new Client("Aliigna", "Herie", new DateTime(1992, 11, 20), "FR002");

        myBank.AddClient(client1);
        myBank.AddClient(client2);

        
        WriteLine($"\n--- transfer {client1.FirstName} ---");
        client1.Deposit(500.0m);
        client1.Withdraw(75.5m);

    
        myBank.DisplayClientList();
    }
}
