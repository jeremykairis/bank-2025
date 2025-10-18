using System.Reflection.Metadata.Ecma335;

class CurrentAccount : Account
{
    public double CreditLine { get; set; }
    public CurrentAccount(string number, double balance, double creditLine, Person owner) : base(number, balance, owner)
    {
        CreditLine = creditLine;
    }
    public override void Withdraw(double amount)
    {
        if (GetBalance() - amount < -CreditLine)
        {
            Console.WriteLine("Retrait impossible, le compte dépasserait la ligne de crédit.");
        }
        else
        {
            SetBalance(GetBalance() - amount);
        }
    }
    protected override double CalculInterest()
    {
        if (GetBalance() < 0)
        {
            return GetBalance() * 0.03;
        }
        else
        {
            return GetBalance() * 0.0975;
        }
    }
}
