using System;
using System.Dynamic;
using System.Globalization;

class Person
{
    public string FirstName;
    public string LastName;
    public DateTime BirthDate;
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
    public double Balance { get; }
    public double CreditLine { get; set; }
    public Person Owner { get; set; }
    public CurrentAccount(string number, double balance, double creditLine, Person owner)
    {
        Number = number;
        Balance = balance;
        CreditLine = creditLine;
        Owner = owner;
    }
    public void Deposit(double amount, double Balance)
    {
        Balance += amount;
        return;
    }
    public void Withdraw(double amount, double Balance)
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
            if (account.Owner == owner)
            {
                SumAccount += account.Balance;
            }
        }
        Console.WriteLine($"La somme des comptes de {owner.FirstName} {owner.LastName} est de {SumAccount} euros.");
        return;
    }
}