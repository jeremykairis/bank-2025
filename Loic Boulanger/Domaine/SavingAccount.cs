namespace DefaultNamespace;

ublic class SavingAccount : Account
{
    public DateTime DateLastWithdraw { get; set; }

    public SavingAccount(string number, Person owner, double creditLine = 0)
        : base(number, owner, creditLine)
    {
    }
    // Taux fixe de 4,5 %
    protected override double CalculInterets()
    {
        return Balance * 0.045;
    }
}