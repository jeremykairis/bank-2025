using Microsoft.VisualBasic.FileIO;

class Account(string nombre, double balance, Person? owner)
{
    private string Nombre { get; set; } = nombre;
    private double Balance { get; set; } = balance;
    private Person? owner { get; set; } = owner;
    protected double solde = balance;

    // Méthode abstraite pour calculer les intérêts
    protected virtual double calculInterets()
    {
        return 0;
    }

    // Méthode publique pour appliquer les intérêts et afficher un message
    public void ApplyInterest()
    {
        double interets = calculInterets();
        solde += interets;
        Console.WriteLine($"Intérêts appliqués : {interets:F2} €. Nouveau solde : {solde:F2} €");
    }

    // Méthode pour consulter le solde actuel
    public double GetSolde()
    {
        return solde;
    }

    // Classe LivretEpargne
    public class LivretEpargne : Account
    {
        public LivretEpargne(double solde) : base("", solde, null) { }

        protected override double calculInterets()
        {
            // Taux fixe 4,5 %
            return solde * 0.045;
        }
    }

    // Classe CompteCourant
    public class CompteCourant : Account
    {
        public CompteCourant(double solde) : base("", solde, null) { }

        protected override double calculInterets()
        {
            double taux = (solde >= 0) ? 0.03 : 0.0975;
            return solde * taux;
        }
    }


    // Méthodes pour retirer et déposer de l'argent

    public virtual void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Le montant du retrait doit être supérieur à zéro.");
        }
        if (amount > Balance)
        {
            throw new InvalidOperationException("Fonds insuffisants pour le retrait.");
        }
        Balance -= amount;
    }

    // Méthode pour déposer de l'argent
    public virtual void Deposit(double amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Le montant du dépôt doit être supérieur à zéro.");
        }

        Balance += amount;
    }

    // Constructeur avec le numéro et le titulaire

    private Account(string nombre, Person owner) :
        this(nombre, 0.0, owner)
    {
    }

    // Supprimer la déclaration du type délégué "BalanceNegativeDelegate"
    
       public delegate void NegativeBalanceDelegate(Account account);

 
    // Déclaration de l'événement utilisant Action
    public event Action<Account>? BalanceNegativeEvent;
    

    // Déclaration de l'événement utilisant Func
    public event Func<Account, bool>? BalanceNegativeFuncEvent;

}