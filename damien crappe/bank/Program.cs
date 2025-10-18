using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Person owner1 = new Person("Aaron", "Crappe", new DateTime(2020, 1, 7));
        Person owner2 = new Person("Taylor", "Swifer", new DateTime(2001, 2, 26));

        CurrentAccount currentAccount = new CurrentAccount("123445", 1500.0, 100.0, owner1);
        CurrentAccount currentAccount2 = new CurrentAccount("987654", 2000.0, 500.0, owner2);
        SavingsAccount savingsAccount = new SavingsAccount("968365", 10000.0, owner1);
        SavingsAccount savingsAccount2 = new SavingsAccount("563248", 5000.0, owner2);

        Console.WriteLine($"Le solde du compte d' {currentAccount.Owner.FirstName} est de {currentAccount.GetBalance()} EUR.");

        currentAccount.ApplyInterest();
        Console.WriteLine($"Après application des intérêts, le solde du compte d' {currentAccount.Owner.FirstName} est de {currentAccount.GetBalance()} EUR.");


    }
}
