
namespace Loic_Boulanger.Domaine
{
    public class SavingsAccount : Account
    {
        public DateTime? DateLastWithdraw { get; private set; }

        public SavingsAccount(string number, Person owner)
            : base(number, owner)
        {
        }

        // Taux fixe de 4,5 %
        protected override double CalculInterest()
        {
            return Balance * 0.045;
        }

        // On enregistre la date du dernier retrait
        public override void Withdraw(double amount)
        {
            base.Withdraw(amount);

            if (amount > 0 && Balance >= 0)
                DateLastWithdraw = DateTime.Now;
        }

        public override string ToString()
        {
            return $"[Compte Épargne] N° {Number} - Propriétaire : {Owner} - Solde : {Balance:C}";
        }
    }
}