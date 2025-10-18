using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// 1. Création des Personnes
Person client1 = new Person("Marko", "Buhovac", new DateTime(1867, 11, 7));
Person client2 = new Person("Max", "Verstappen", new DateTime(1879, 3, 14));
Person client3 = new Person("Nikola", "Tesla", new DateTime(1856, 7, 10));

Console.WriteLine($"\nCréation du client 1: {client1.FirstName} {client1.LastName}");
Console.WriteLine($"Création du client 2: {client2.FirstName} {client2.LastName}");
Console.WriteLine($"\nCréation du client 3: {client3.FirstName} {client3.LastName}");

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }

    public Person(string firstName, string lastName, DateTime birthDate)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
    }
}

public class CurrentAccount
{
    public string Number { get; private set; }
    
    public double Balance { get; private set; } 
    
    public double CreditLine { get; set; }
    public Person Owner { get; private set; }

    public CurrentAccount(string number, double initialBalance, double creditLine, Person owner)
    {
        Number = number;
        Balance = initialBalance;
        CreditLine = creditLine;
        Owner = owner;
    }

    // Méthode publique pour le dépôt
    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance += amount;
            Console.WriteLine($"Compte {Number}: + {amount:C2} (Dépôt). Nouveau solde: {Balance:C2}");
        }
        else
        {
            Console.WriteLine($"Compte {Number}: Erreur de dépôt. Le montant doit être positif.");
        }
    }

}




