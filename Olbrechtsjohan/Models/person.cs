using System;
using System.Collections.Generic;

namespace Models
{
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

        public int CalculateAge()
        {
            int age = DateTime.Today.Year - BirthDate.Year;
            if (BirthDate.Date > DateTime.Today.AddYears(-age))
            {
                age--;
            }
            return age;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"First Name: {FirstName}, Last Name: {LastName}, Age: {CalculateAge()}");
        }
    }

    public class Client : Person
    {
        public Client(string firstName, string lastName, DateTime birthDate)
            : base(firstName, lastName, birthDate)
        {
        }
    }

    public class Banque
    {
        public string Name { get; set; }
        public List<Account> Accounts { get; private set; }

        public Banque(string name)
        {
            Name = name;
            Accounts = new List<Account>();
        }

        public void AddAccount(Account newAccount)
        {
            if (newAccount != null)
            {
                Accounts.Add(newAccount);
                Console.WriteLine($"Account {newAccount.Number} for {newAccount.Owner.FirstName} {newAccount.Owner.LastName} has been added.");
            }
        }

        public void DisplayAccountsList()
        {
            Console.WriteLine($"\n--- compte de  {Name} ---");
            foreach (var account in Accounts)
            {
                Console.WriteLine($"Account: {account.Number}, Propietaire: {account.Owner.FirstName} {account.Owner.LastName}, Balance: ${account.Balance}");
            }
        }
    }
}