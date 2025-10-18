class Account(string number, double balance, Person owner)
{
    public string Number { get; set; } = number;
    public double Balance { get; protected set; } = balance;
    public Person Owner { get; set; } = owner;
    public virtual void Deposit(double amount)
    {
        Balance += amount;
    }
    public virtual void Withdraw(double amount)
    {
        if (amount > Balance)
        {
            Console.WriteLine("Solde insufisant");
        }
        else
        {
            Balance -= amount;
        }
    }
}