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
        public string AccountNumber { get; private set; }
        public decimal Balance { get; private set; }

        public Client(string firstName, string lastName, DateTime birthDate, string accountNumber)
            : base(firstName, lastName, birthDate)
        {
            AccountNumber = accountNumber;
            Balance = 0.0m; // Initial balance is always 0
        }       
    }

    public class Banque
    {
        public string Name { get; set; }
        public List<Client> Clients { get; private set; }

        public Banque(string name)
        {
            Name = name;
            Clients = new List<Client>();
        }

        public void AddClient(Client newClient)
        {
            if (newClient != null)
            {
                Clients.Add(newClient);
                Console.WriteLine($" {newClient.FirstName} {newClient.LastName} nouveau client.");
            }
        }

        public void DisplayClientList()
        {
            Console.WriteLine($"\n--- Clients  {Name} ---");
            foreach (var client in Clients)
            {
                Console.WriteLine($"Client: {client.FirstName} {client.LastName}, Account Number: {client.AccountNumber}, Balance: ${client.Balance}");
            }
        }

        public void DisplayClient(string accountNumber)
        {
            foreach (var client in Clients)
            {
                if (client.AccountNumber == accountNumber)
                {
                    Console.WriteLine($"Client {client.FirstName} {client.LastName} account number {client.AccountNumber} is a client of bank {Name}.");
                }
            }
        }
    }
}