class CurrentAccount
{
    public string Number { get; set; }
    public double Balance { get; private set; }
    public double CreditLine { get; private set; }
    public Person Owner { get; set; }
    public CurrentAccount(string number, Person owner, double creditLine = 0)
    {
        Number = number;
        Owner = owner;
        Balance = 0;
        CreditLine = creditLine;
    }
    public void Deposit(double amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Deposit amount must be positive.");
        }
        Balance += amount;
    }
    public void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Withdrawal amount must be positive.");
        }
        if (Balance + CreditLine < amount)
        {
            throw new InvalidOperationException("Insufficient funds including credit line.");
        }
        Balance -= amount;
    }

   
}