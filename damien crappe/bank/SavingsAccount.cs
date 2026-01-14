class SavingsAccount : Account
{
    public SavingsAccount(string number, Person owner)
        : base(number, owner)
    {
    }

    public SavingsAccount(string number, Person owner, double balance)
        : base(number, owner, balance)
    {
    }

    // Pour un compte épargne : jamais de négatif
    protected override bool CanWithdraw(double amount) => Balance - amount >= 0;

    protected override double CalculInterest()
    {
        return Balance * 0.045;
    }
}
