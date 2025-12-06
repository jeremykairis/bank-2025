abstract class Account : IBankAccount
{
    public string Number { get; private set; }
    public double Balance { get; private set; }
    public Person Owner { get; private set; }

    public event Action<Account>? NegativeBalanceEvent;

    protected Account(string number, Person owner)
    {
        Number = number;
        Owner = owner;
        Balance = 0;
    }

    protected Account(string number, Person owner, double balance)
    {
        Number = number;
        Owner = owner;
        Balance = balance;
    }

    public virtual void Deposit(double amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount),
                "Le montant du dépôt doit être supérieur à 0.");

        Balance += amount;
    }

    public virtual void Withdraw(double amount)
    {
        if (amount <= 0)
            throw new ArgumentOutOfRangeException(nameof(amount),
                "Le montant du retrait doit être supérieur à 0.");

        if (!CanWithdraw(amount))
            throw new InsufficientBalanceException("Le montant ne peut pas être retiré.");

        Balance -= amount;
    }

    protected virtual bool CanWithdraw(double amount) => Balance - amount >= 0;

    protected abstract double CalculInterest();

    public void ApplyInterest()
    {
        double interest = CalculInterest();
        Balance += interest;
    }

    // Méthode protégée pour déclencher l'événement
    protected void OnNegativeBalance()
    {
        NegativeBalanceEvent?.Invoke(this);
    }
}