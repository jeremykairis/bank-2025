using ConsoleApp1;

internal class Program
{
    public static void Main(string[] args)
    {
        DateTime date = DateTime.Now;
        Person client1 = new Person("John", "Doe", date);
        Person client2 = new Person("Angelina", "Jolie", date);
        CurrentAccount account1 = new CurrentAccount("000001", 50000, 100000, client1);
        CurrentAccount account2 = new CurrentAccount("000001", 50000, 100000, client2);
        Bank bank = new Bank("ING BELGIUM");

        bank.AddAccount(account1);
        bank.AddAccount(account2);


        bank.DisplayInfos(account2);
        Console.WriteLine(bank.AllAccountSum(account2));
    
    }
}