using Loic_Boulanger.Domaine;

namespace LoïcBoulanger2.Domain;

public class CurrentAccount : Account
{
    public double CreditLine { get; private set; }

    public CurrentAccount(string number, Person owner, double creditLine)
        : base(number, owner, creditLine)
    {
        CreditLine = creditLine;
    }

    public override void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Le montant du retrait doit être positif.");
            return;
        }

        if (Balance - amount < -CreditLine)
        {
            Console.WriteLine("Fonds insuffisants (limite de découvert atteinte). Retrait refusé.");
            return;
        }

        base.Withdraw(amount); // Call only once, after checks
    }

    protected override double CalculInterest()
    {
        if (Balance <= 0)
        {
            return (Balance * 0.03);
        }
        else
        {
            return Balance * 0.0975;
        }
        
    }
}
