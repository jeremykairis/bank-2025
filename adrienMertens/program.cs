class Person
{
    public string FirstName { get;set };
    public string LastName { get;set };
    public DateTime BirthDate { get;set };

    public Person(string firstName, string lastName, DateTime birthDate)
    {
        firstName = firstName;
        lastName = lastName;
        birthDate = birthDate;
    }
}

class CurrentAccount
{
    private string Number { get; set };
    private double Balance { get; private set };
    private double CreditLine { get; set };
    private Person Owner { get; set };

    public CurrentAccount(string number,Person owner, double creditLine = 0 )
    {
        Number = number;
        Owner = owner;
        CreditLine = creditLine;
        Balance = 0;
    }

    public void WithDraw(double amount)
    {
        
    }
    public void Deposit(double amount)
    {
        
    }
}

class Bank
{
    private Dictionary<string, CurrentAccount> _accounts = new Dictionary<string, CurrentAccount>();
    private string name { get; set };

    public Bank(string name)
    {
        Name = name;
    }
    
    public void AddAccount(CurrentAccount account)
    {
        
    }

    public void DeleteAccount(string number)
    {
        
    }

    public double ReturnSoldeCurrentAccount()
    {
        
    }
    public void ShowAllCurrentAccounts()
    {
        
    }
}

class Program
{
    static void Main()
    {
        // Exemple d'utilisation
        var bank = new Bank("Ma Banque");
        var person = new Person("Adrien", "Mertens", new DateTime(1990, 1, 1));
        var account = new CurrentAccount("BE123456789", person, 1000);
    }
    
}
