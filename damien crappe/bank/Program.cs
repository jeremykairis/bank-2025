using System;
using System.Collections.Generic; 
using System.Globalization;

class Person
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
class CurrentAccount
{
    public string Number { get; set; }
    public double Balance { get; private set; }
    public double CreditLine { get; set; }
    public Person Owner { get; set; }
    public CurrentAccount(string number, double balance, double creditLine, Person owner)
    {
        Number = number;
        Balance = balance;
        CreditLine = creditLine;
        Owner = owner;
    }
    public void Deposit(double amount)
    {
        Balance += amount;
        return;
    }
    public void Withdraw(double amount)
    {
        if (Balance <= 0)
        {
            Console.WriteLine("Le solde est insuffisant pour effectuer ce retrait.");
            return;
        }
        else if (Balance - amount < -CreditLine)
        {
            Console.WriteLine("Retrait impossible, le compte serait à découvert.");
            return;
        }
        else
        {
            Balance -= amount;
            return;
        }
    }
    public double GetBalance() => Balance;
}
class Bank
{
    public readonly Dictionary<string, CurrentAccount> Accounts = new ();
    public string Name;
    public Bank(string name)
    {
        Name = name;
    }
    public void AddAccount(CurrentAccount account)
    {
        Accounts[account.Number] = account;
        return;
    }
    public void RemoveAccount(string accountNumber)
    {
        Accounts.Remove(accountNumber);
        return;
    }

}
class Methods
{
    public void ShowMoney(CurrentAccount account)
    {
        Console.WriteLine($"Le compte {account.Number} a un solde de {account.Balance} euros.");
    }
    public void ShowMoneySum(Bank bank, Person owner)
    {
        double SumAccount = 0;
        foreach (var account in bank.Accounts.Values)
        {
            if (account.Owner.FirstName == owner.FirstName && account.Owner.LastName == owner.LastName)
            {
                SumAccount += account.GetBalance();
            }
        }
        Console.WriteLine($"La somme des comptes de {owner.FirstName} {owner.LastName} est de {SumAccount} euros.");
        return;
    }
}
class SavingsAccount
{
    public string Number { get; set; }
    public double Balance { get; private set; }
    public DateTime DateLastWithdraw { get; set; }
    public Person Owner { get; set; }
    public SavingsAccount(string number, double balance, Person owner)
    {
        Number = number;
        Balance = balance;
        Owner = owner;
        DateLastWithdraw = DateTime.Now;
    }
    public void Deposit(double amount)
    {
        Balance += amount;
        return;
    }
    public void Withdraw(double amount)
    {
        if (Balance <= 0)
        {
            Console.WriteLine("Le solde est insuffisant pour effectuer ce retrait.");
            return;
        }
        else if (Balance - amount < 0)
        {
            Console.WriteLine("Retrait impossible, le compte serait à découvert.");
            return;
        }
        else
        {
            Balance -= amount;
            return;
        }
    }
    
}

class Program
{
    static void Main()
    {
        // Création d'une personne
        var p1 = new Person("Alice", "Dupont", new DateTime(1990, 5, 12));

        // Création d'une banque
        var bank = new Bank("MaBanque");

        // Création d'un compte
        var account1 = new CurrentAccount("FR123", 1000, 200, p1);
        var account2 = new CurrentAccount("FR456", 500, 100, p1);

        // Ajout des comptes à la banque
        bank.AddAccount(account1);
        bank.AddAccount(account2);

        // Dépôt et retrait
        account1.Deposit(200);
        account1.Withdraw(300);

        // Affichage
        var methods = new Methods();
        methods.ShowMoney(account1);
        methods.ShowMoneySum(bank, p1);
    }
}
