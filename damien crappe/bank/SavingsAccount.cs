class SavingsAccount : Account
{
    public SavingsAccount(string number, double balance, Person owner) : base(number, balance, owner)
    {
    }
    public override void Withdraw(double amount)
    {
        if (GetBalance() - amount < 0)
        {
            Console.WriteLine("Retrait impossible, le solde serait négatif.");
        }
        else
        {
            SetBalance(GetBalance() - amount);
        }
    }
    protected override double CalculInterest()
    {
        return GetBalance() * 1.045;
    }
}
