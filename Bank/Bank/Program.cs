public class Person
{
    public string FirstName {get;private set; }
    public string LastName {get;private set; }
    public DateTime BirthDate { get; private set; }
    public Person (string firstName, string lastName, DateTime birthDate)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
    }
}
public class Bank
{
    public Dictionary<string,Account> Accounts {get;}
    public string Name { get; set; }
    public Bank (string name)
    {
        Name=name;
        Accounts = new Dictionary<string,Account> ();
    }
    void AddAccount (Account account)
    {
        Accounts[account.Number] = account;

        account.NegativeBalanceEvent += HandleNegativeBalance;
    }
    void DeleteAccount(string number)
    { 
        Accounts.Remove(number);
    }
    public double GetTotalAccount (Person owner)
    {
        double total = 0;
        foreach (var entry in Accounts.Values)
        {
            if (entry.Owner == owner)
            {
                total += entry.Balance;
            }
        }
        return total;
    }

    private void HandleNegativeBalance (Account account)
    {
        Console.WriteLine($"Le compte {account.Number} vient de passer en négatif ");
    }
}

public interface IAccount
{
    double Balance { get; }
    void Deposit(double amount);
    void Withdraw(double amount);
}
public interface IBankAccount : IAccount
{
    string Number { get; }
    Person Owner { get; }
    void ApplyInterest();
}

public abstract class Account :IBankAccount
{
    public string Number { get; set; }
    public double Balance { get; private set; }
    public Person Owner { get; set; }

    public event Action<Account> NegativeBalanceEvent;

    protected void OnNegativeBalance()
    {
        NegativeBalanceEvent ?.Invoke(this);
    }

    protected Account(string number, Person owner)
    {
        Number = number;
        Owner = owner;
        Balance = 0;
    }

    protected Account(string number,Person owner,double InitialBalance)
    {
        Number = number;
        Owner = owner;
        Balance = InitialBalance;
    }

    protected void ChangeBalance(double value)
    {
        Balance = value;
    }
    public virtual void Deposit(double amount)
    {
        if (amount <= 0) throw new ArgumentOutOfRangeException();
        ChangeBalance(Balance + amount);
    }
    public virtual void Withdraw(double amount)
    {
        if (amount <= 0) throw new ArgumentOutOfRangeException();
        if (Balance >= amount)
            ChangeBalance(Balance - amount);
        else
            throw new InsufficientBalanceExcepetion("Fonds Insuffisants");
    }
    protected abstract double CalculInterets();
    public void ApplyInterest()
    {
        double interets = CalculInterets();
        ChangeBalance(Balance + interets);
    }
}

public class CurrentAccount : Account
{
    private double creditLine;

    public double CreditLine
    {
        get => creditLine;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "La ligne de crédit doit être supérieure ou égale à 0.");
            creditLine = value;
        }
    }
    public CurrentAccount(string number, Person owner, double creditLine)
        : base(number, owner)
    {
        CreditLine = creditLine;
    }
    public CurrentAccount(string number, Person owner, double Creditline,double InitialBalance)
        : base(number, owner, InitialBalance)
    {
        CreditLine = Creditline;
    }
    public override void Withdraw(double amount)
    {
        if (amount <= 0) throw new ArgumentOutOfRangeException();

        double NewBalance = Balance - amount;

        if (NewBalance >= -CreditLine)
        {
            ChangeBalance(NewBalance);

            if (Balance < 0)
            {
                OnNegativeBalance();
            }
        }
        else
            throw new InvalidOperationException("Au-dessus de la ligne de crédit.");
    }
    public double GetCurrentAccountBalance()
    {
        return Balance;
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
    public DateTime DateLastWithdraw {get;private set;}
    public SavingsAccount(string number, Person owner)
        : base (number, owner)
    {
        DateLastWithdraw = DateTime.MinValue;
    }
    public SavingsAccount(string number, Person owner, double InitialBalance) : base(number, owner, InitialBalance)
    {
        DateLastWithdraw = DateTime.MinValue;
    }
    public override void Withdraw(double amount)
    {
        base.Withdraw(amount);
        DateLastWithdraw = DateTime.Now;
    }
    protected override double CalculInterets()
    {
        return Balance * 0.045;
    }

}

public class InsufficientBalanceExcepetion: Exception
{
    public InsufficientBalanceExcepetion()
    {}
    public InsufficientBalanceExcepetion(string message)
        : base(message)
    {}
    public InsufficientBalanceExcepetion(string message, Exception innerException)
        :base(message, innerException)
    {}
}