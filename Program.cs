using System;



class Program
{
    static void Main(string[] args)
    {
        Person person1 = new Person
        {
            FirstName = "John",
            LastName = "Doe",
            BirthDate = new DateTime(30, 1, 1990)
        };
        person1 person2 = new Person
        {
            FirstName = "Jane",
            LastName = "Smith",
            BirthDate = new DateTime(15, 5, 1985)
        };
        currentAccount account1 = new CurrentAccount("ACC123", 1000.0, 500.0, person1);
        currentAccount account2 = new CurrentAccount("ACC456", 2000.0, 1000.0, person2);

        Console.WriteLine($"Name: {person1.FirstName} {person1.LastName}, Birth Date: {person1.BirthDate.ToShortDateString()}");
        Console.WriteLine($"Name: {person2.FirstName} {person2.LastName}, Birth Date: {person2.BirthDate.ToShortDateString()}");
        Console.WriteLine($"Account: {account1.Nombre}, Balance: {account1.Balance}, Credit Line: {account1.creditline}");
        Console.WriteLine($"Account: {account2.Nombre}, Balance: {account2.Balance}, Credit Line: {account2.creditline}");
        Bank ING = new Bank(new Dictionary<string, CurrentAccount>(), "Ma Banque");
        ING.AddAccount(account1);
        ING.AddAccount(account2);
        ING.DeleteAccount(account1);
        ING.DeleteAccount(account2);
        ING.GetAccountInfo(person1);
        ING.GetAccountInfo(person2);


    }
}
