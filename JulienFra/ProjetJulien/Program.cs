var person = new Person("Alice", "Dupont", new DateTime(1990,1,1));
var current = new CurrentAccount("CA123", person, 100);
var savings = new SavingsAccount("SA123", person);

var bank = new Bank("Ma Banque");
bank.AddAccount(current);
bank.AddAccount(savings);

current.Deposit(500);
savings.Deposit(1000);

current.Withdraw(550); // autorisé grâce au CreditLine
savings.Withdraw(200);

Console.WriteLine("Épargne : " + savings.GetBalance());
Console.WriteLine("Courant : " + current.GetBalance());
Console.WriteLine(bank.GetTotalBalance(person)); // 750
public class Person
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
public abstract class Account
{
    public string Number { get; set; }
    public double Balance { get; protected set; }
    public Person Owner { get; set; }

    public Account(string number, Person owner)
    {
        Number = number;
        Owner = owner;
        Balance = 0;
    }

    public virtual void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Le montant d'un retrait doit être positif");
            return;
        }

        if (Balance - amount < 0)
        {
            Console.WriteLine("Fond insuffisant");
            return;
        }

        Balance -= amount;
    }

    public virtual void Deposit(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Le montant doit être positif.");
            return;
        }

        Balance += amount;
    }

    public double GetBalance()
    {
        return Balance;
    }
    protected abstract double CalculInterets();
    public void ApplyInterest()
    {
        Balance += CalculInterets();
    }
}

public class CurrentAccount : Account
{
    public double CreditLine { get; set; }

    public CurrentAccount(string number, Person owner, double creditLine = 0)
        : base(number, owner)
    {
        CreditLine = creditLine;
    }

    public override void Withdraw(double amount)
    {
        if (Balance - amount < -CreditLine)
        {
            Console.WriteLine("Fond insuffisant");
            return;
        }

        Balance -= amount;
    }

    protected override double CalculInterets()
    {
        if (Balance >= 0)
            return Balance * 0.03;     
        else
            return Balance * 0.0975;
    }
}


public class SavingsAccount : Account
{
    public DateTime DateLastWithdraw { get; private set; }

    public SavingsAccount(string number, Person owner)
        : base(number, owner)
    {
        DateLastWithdraw = DateTime.MinValue;
    }

    public override void Withdraw(double amount)
    {
        if (Balance - amount < 0)
        {
            Console.WriteLine("Fond insuffisant");
            return;
        }

        Balance -= amount;
        DateLastWithdraw = DateTime.Now;
    }

    protected override double CalculInterets()
    {
        return Balance * 0.045;
    }
}

public class Bank
{
    public Dictionary<string, Account> Accounts { get; } = new();
    public string Name { get; set; }
    public Bank(string name)
    {
        Name = name;
    }
    public void AddAccount(Account account)
    {
        if (!Accounts.ContainsKey(account.Number))
        {
            Accounts.Add(account.Number, account);
        }
        else
        {
            Console.WriteLine("Ce compte existe déjà !");
        }
    }
    public void DeleteAccount(string number)
    {
        if (Accounts.ContainsKey(number))
        {
            Accounts.Remove(number);
        }
        else
        {
            Console.WriteLine("Aucun compte avec ce numéro trouvé.");
        }
    }
    public double GetTotalBalance(Person person)
    {
        double total = 0;

        foreach (var acc in Accounts.Values)
        {
            if (acc.Owner == person)
            {
                total += acc.GetBalance();
            }
        }

        return total;
    }

}

