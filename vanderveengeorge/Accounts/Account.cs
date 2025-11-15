abstract class Account : IBankAccount
{
    public string Number { get; private set; }
    public double Balance { get; private set; }
    public Person Owner { get; private set; }
    public Account(string number, Person owner)
    {
        Number = number;
        Owner = owner;
    }
    public Account(string number, double balance, Person owner) : this(number, owner)
    {
        Balance = balance;
    }

    public virtual void Deposit(double amount)
    {
        ArgumentOutOfRangeException.ThrowIfLessThan(amount, 0);
        Balance += amount;
    }
    public virtual void Withdraw(double amount)
    {
        if (amount <= Balance)
        {
            Balance -= amount;
        }
        else
        {
            throw new InsufficientBalanceException("Solde insufisant !");
        }
    }
    protected abstract double CalculateInterest();
    public virtual void ApplyInterest()
    {
        Balance += CalculateInterest();
    }
}