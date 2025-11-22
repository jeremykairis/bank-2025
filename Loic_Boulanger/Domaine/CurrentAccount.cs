using System;

namespace Loic_Boulanger.Domaine
{
    public class CurrentAccount : Account
    {
        private double creditLine;
        
        public double CreditLine
        {
            get => creditLine;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                        "La ligne de crédit doit être supérieure ou égale à 0.");
                }

                creditLine = value;
            }
        }

        public CurrentAccount(string number, Person owner, double creditLine)
            : base(number, owner)
        {
            if (creditLine < 0)
                throw new ArgumentException("La ligne de crédit doit être positive.");
            
            CreditLine = creditLine;
        }
        public event Action<Account>? NegativeBalanceEvent;

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

            Balance -= amount; // Décrémente directement le solde
            if (Balance < 0)
            {
                NegativeBalanceEvent?.Invoke(this);
            }
            
            Console.WriteLine($"Retrait de {amount:C} effectué. Nouveau solde : {Balance:C}");
        }

        protected override double CalculInterest()
        {
            // Exemple simple : pas d’intérêt sur compte courant si solde négatif
            if (Balance <= 0)
                return 0.0;

            return Balance * 0.001; // 0,1 % d’intérêt positif sur le solde
        }

        public override string ToString()
        {
            return $"[Compte Courant] N° {Number} - Propriétaire : {Owner} - Solde : {Balance:C} - Découvert autorisé : {CreditLine:C}";
        }
    }
}