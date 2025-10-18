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
Console.WriteLine($"Création du client 3: {client3.FirstName} {client3.LastName}");

// 2. Création des Comptes Courants
CurrentAccount account1 = new CurrentAccount("FR12345", 500.00, 1000.00, client1);
CurrentAccount account2 = new CurrentAccount("FR67890", 2500.50, 500.00, client1);
CurrentAccount account3 = new CurrentAccount("US98765", 10.00, 5000.00, client2);

// 3. Création de la Banque et ajout des comptes
Bank bnp = new Bank("BNP Paribas");
bnp.AddAccount(account1);
bnp.AddAccount(account2);
bnp.AddAccount(account3);

Console.WriteLine($"\nLa banque '{bnp.Name}' a été créée et gère {bnp.Accounts.Count} comptes.");

// 4. Test des opérations sur les comptes
Console.WriteLine("\n--- OPÉRATIONS BANCAIRES ---");

Console.WriteLine($"Solde initial de {client1.FirstName} (Compte {account1.Number}): {account1.GetBalance():C2}");
account1.Deposit(100.00);
account1.Withdraw(300.00);
account1.Withdraw(1500.00);

Console.WriteLine($"\nSolde de {client2.FirstName} (Compte {account3.Number}): {account3.GetBalance():C2}");
account3.Withdraw(5005.00);

// 5. Test de la méthode de rapport global (Somme des comptes d'une personne)
Console.WriteLine("\n--- RAPPORT GLOBAL DE LA BANQUE ---");

double totalMarko = bnp.GetTotalBalanceForPerson(client1);
Console.WriteLine($"Solde total pour {client1.FirstName} {client1.LastName}: {totalMarko:C2}");

double totalMax = bnp.GetTotalBalanceForPerson(client2);
Console.WriteLine($"Solde total pour {client2.FirstName} {client2.LastName}: {totalMax:C2}");

// Test de suppression de compte
Console.WriteLine("\n--- GESTION DES COMPTES ---");
bnp.DeleteAccount(account3.Number);
Console.WriteLine($"Le compte {account3.Number} a été supprimé.");
Console.WriteLine($"La banque gère maintenant {bnp.Accounts.Count} comptes.");

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
    // Méthode publique pour le retrait
    public void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine($"Compte {Number}: Erreur de retrait. Le montant doit être positif.");
            return;
        }

        double allowedThreshold = -CreditLine;

        if (Balance - amount >= allowedThreshold)
        {
            Balance -= amount;
            Console.WriteLine($"Compte {Number}: - {amount:C2} (Retrait). Nouveau solde: {Balance:C2}");
        }
        else
        {
            Console.WriteLine($"Compte {Number}: Retrait de {amount:C2} refusé. Le solde disponible ({Balance + CreditLine:C2}) est insuffisant.");
        }
    }
    // Méthode publique pour le retrait
    public double GetBalance()
    {
        return Balance;
    }

}

public class Bank
{
    public List<CurrentAccount> Accounts { get; } 
    public string Name { get; set; }

    public Bank(string name)
    {
        Name = name;
        Accounts = new List<CurrentAccount>();
    }

    // Méthode publique pour ajouter un compte
    public void AddAccount(CurrentAccount account)
    {
        if (Accounts.Any(a => a.Number == account.Number))
        {
            Console.WriteLine($"Erreur: Le compte {account.Number} existe déjà dans la banque.");
        }
        else
        {
            Accounts.Add(account);
            Console.WriteLine($"Compte {account.Number} ajouté à la banque {Name}.");
        }
    }

    // Méthode publique pour supprimer un compte
    public void DeleteAccount(string number)
    {
        CurrentAccount accountToRemove = Accounts.FirstOrDefault(a => a.Number == number);

        if (accountToRemove != null)
        {
            Accounts.Remove(accountToRemove);
        }
        else
        {
            Console.WriteLine($"Erreur: Le compte {number} n'existe pas dans la banque.");
        }
    }

    // 5. Méthode pour donner la somme de tous les comptes d'une personne
    public double GetTotalBalanceForPerson(Person owner)
    {
        double total = Accounts
            .Where(account => account.Owner == owner) 
            .Sum(account => account.Balance);
            
        return total;
    }
}




