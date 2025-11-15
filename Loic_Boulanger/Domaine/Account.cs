namespace Loic_Boulanger.Domaine
{
    // --- Interface de base pour un compte ---
    public interface IAccount
    {
        double Balance { get; }           // Lecture seule du solde
        void Deposit(double amount);      // Méthode de dépôt
        void Withdraw(double amount);     // Méthode de retrait
    }

    // --- Interface d’un compte bancaire ---
    public interface IBankAccount : IAccount
    {
        string Number { get; }            // Lecture seule du numéro de compte
        Person Owner { get; }             // Lecture seule du propriétaire
        void ApplyInterest();             // Méthode d’application des intérêts
    }

    // --- Classe abstraite représentant un compte ---
    public abstract class Account : IBankAccount
    {
        // --- Propriétés publiques ---
        public string Number { get; private set; }    // Numéro de compte (lecture seule)
        public double Balance { get; protected set; } // Solde (accessible aux classes dérivées)
        public Person Owner { get; private set; }     // Propriétaire (lecture seule)

        // --- Constructeur ---
        protected Account(string number, Person owner)
        {
            Number = number;
            Owner = owner;
            Balance = 0.0;
        }

        // --- Méthode pour déposer de l’argent ---
        public void Deposit(double amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(amount), "Le montant du dépôt doit être supérieur à 0.");
            }

            Balance += amount;
            Console.WriteLine($"Dépôt de {amount:C} effectué. Nouveau solde : {Balance:C}");
        }

        // --- Méthode pour retirer de l’argent ---
        public virtual void Withdraw(double amount)
        {
                if (amount <= 0)
    {
        throw new ArgumentOutOfRangeException(nameof(amount),
            "Le montant du retrait doit être supérieur à 0.");
    }

    if (Balance < amount)
    {
        throw new InsufficientBalanceException(
            "Fonds insuffisants : impossible d'effectuer ce retrait.");
    }

    Balance -= amount;
}
            
        // --- Méthode abstraite pour calculer les intérêts ---
        protected abstract double CalculInterest();

        // --- Application des intérêts ---
        public void ApplyInterest()
        {
            double interest = CalculInterest();
            Balance += interest;
            Console.WriteLine($"Intérêts de {interest:C} appliqués. Nouveau solde : {Balance:C}");
        }
    }
}