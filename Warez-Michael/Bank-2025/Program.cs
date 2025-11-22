
class Program


{
    static void Main(string[] args)
    {
        Person person1 = new Person("John", "Doe", new DateTime(1990, 1, 30));
        Person person2 = new Person("Jane", "Smith", new DateTime(1985, 5, 15));

        CurrentAccount account1 = new CurrentAccount("ACC123", 1000.0, 500.0, person1)
        {
            CreditLine = 500.0,
            lignecredit = 500.0
        };
        
        CurrentAccount account2 = new CurrentAccount("ACC456", 2000.0, 1000.0, person2)
        {
            CreditLine = 1000.0,
            lignecredit = 1000.0
        };

// Affichage des informations des personnes et des comptes
        Console.WriteLine($"Name: {person1.FirstName} {person1.LastName}, Birth Date: {person1.BirthDate:d}");
        Console.WriteLine($"Name: {person2.FirstName} {person2.LastName}, Birth Date: {person2.BirthDate:d}");
        Console.WriteLine($"Account: {account1.Nombre}, Balance: {account1.Balance}, Credit Line: {account1.CreditLine}");
        Console.WriteLine($"Account: {account2.Nombre}, Balance: {account2.Balance}, Credit Line: {account2.CreditLine}");

        Bank ING = new Bank(new Dictionary<string, CurrentAccount>(), "Ma Banque");

        ING.AddAccount(account1);
        ING.AddAccount(account2);
        ING.GetAccountInfo(person1);
        ING.GetAccountInfo(person2);
        ING.RemoveAccount(account1);
        ING.RemoveAccount(account2);
    }
}
