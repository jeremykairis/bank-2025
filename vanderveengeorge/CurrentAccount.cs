class CurrentAccount(string number, double balance, double creditLine, Person owner) : Account(number, balance, owner)
{
    public double CreditLine { get; set; } = creditLine;
    public override void Withdraw(double amount)
    {
        if (amount > Balance + CreditLine)
        {
            Console.WriteLine("Solde insufisant");
        }
        else
        {
            base.Withdraw(amount);
        }
    }

}