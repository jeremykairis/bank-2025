abstract class Account
{
    public string Number { get; set; }
    public double Balance { get; private set; }
    public Person Owner { get; set; }
    public Account(string number, double balance, Person owner)
    {
        Number = number;
        Balance = balance;
        Owner = owner;
    }
    public virtual void Deposit(double amount)
    {
        Balance += amount;
        return;
    }
    public virtual void Withdraw(double amount)
    {
        if (Balance <= 0)
        {
            Console.WriteLine("Le solde est insuffisant pour effectuer ce retrait.");
            return;
        }
        else if (Balance - amount < 0)
        {
            Console.WriteLine("Retrait impossible, le compte serait à découvert.");
            return;
        }
        else
        {
            Balance -= amount;
            return;
        }
    }
    public double GetBalance() => Balance;
    protected void SetBalance(double newBalance)
    {
        Balance = newBalance;
    }
    protected abstract double CalculInterest();

    public void ApplyInterest()
    {
        double interests = CalculInterest();
        SetBalance(GetBalance()+interests);
    }
}
