namespace DefaultNamespace;

public abstract class Account
{
    // --- Propriétés publiques ---
    public string Number { get; set; }               // Numéro de compte
    
    public double Balance { get; private set; }      // Solde (lecture seule)
    
    public Person Owner { get; set; } 
    
    // --- Constructeur ---
    
    public Account(string number, Person owner, double creditLine)
    {
        Number = number;
        Owner = owner;
        Balance = 0.0;
    }
    // --- Méthode pour déposer de l'argent ---
    public void Deposit(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Le montant du dépôt doit être positif.");
            return;
        }

        Balance += amount;
        Console.WriteLine($"Dépôt de {amount:C} effectué. Nouveau solde : {Balance:C}");
    }
    // --- Méthode pour retirer de l'argent ---
    public virtual void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Le montant du retrait doit être positif.");
            return;
        }

        if (Balance - amount < 0)
        {
            Console.WriteLine("Fonds insuffisants. Retrait refusé.");
            return;
        }

        Balance -= amount;
        Console.WriteLine($"Retrait de {amount:C} effectué. Nouveau solde : {Balance:C}");
    }

    // ✅ Méthode abstraite protégée
    protected abstract double CalculInterets();

    public void ApplyInterests()
    {
        double interets = CalculInterets();
        Balance += interets;
        Console.WriteLine($"Intérêts de {interets:C} appliqués. Nouveau solde : {Balance:C}");
    }
}