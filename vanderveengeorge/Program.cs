
class Program
{
    static void Main(string[] args)
    {
        // Création d'une instance de la classe Person
        Person person1 = new Person("Alice", "Dupont", new DateTime(1990, 5, 21));
        CurrentAccount compte1 = new CurrentAccount("BE1234-4323-4323-3424", 4553, 423, person1);
        Console.WriteLine(compte1.Balance);
        compte1.CreditLine -= 3;
        compte1.Withdraw(300);
        Console.WriteLine(compte1.Balance);
    }
}