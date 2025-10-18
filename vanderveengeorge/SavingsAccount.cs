class SavingsAccount(string number, double balance, DateTime dateLastWithdraw, Person owner) : Account(number, balance, owner)
{
    public DateTime DateLastWithdraw { get; set; } = dateLastWithdraw;
    public override void Withdraw(double amount)
    {
        if (amount > Balance)
        {
            Console.WriteLine("Solde insufissant !");
        }
        else
        {
            Balance -= amount;
            DateLastWithdraw = DateTime.Now;
        }
    }
}