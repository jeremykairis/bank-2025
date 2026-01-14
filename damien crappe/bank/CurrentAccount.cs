class CurrentAccount : Account
{
    private double _creditLine;
    public double CreditLine
    {
        get => _creditLine;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value),
                    "La ligne de crédit doit être >= 0.");
            _creditLine = value;
        }
    }

    public CurrentAccount(string number, Person owner, double creditLine)
        : base(number, owner)
    {
        CreditLine = creditLine;
    }

    public CurrentAccount(string number, Person owner, double balance, double creditLine)
        : base(number, owner, balance)
    {
        CreditLine = creditLine;
    }

    protected override bool CanWithdraw(double amount)
        => Balance - amount >= -CreditLine;

    public override void Withdraw(double amount)
    {
        bool wasPositive = Balance >= 0;
        
        base.Withdraw(amount);
        
        // Déclencher l'événement uniquement si on passe de positif à négatif
        if (wasPositive && Balance < 0)
        {
            OnNegativeBalance();
        }
    }

    protected override double CalculInterest()
    {
        if (Balance < 0)
            return Balance * 0.03;
        else
            return Balance * 0.00975;
    }
}