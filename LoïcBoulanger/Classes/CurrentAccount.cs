namespace LoïcBoulanger.Classes;

public class CurrentAccount
{
    // --- Propriétés publiques ---
    public string Number { get; set; }               // Numéro de compte
    public double Balance { get; private set; }      // Solde (lecture seule)
    public double CreditLine { get; set; }           // Découvert autorisé
    public Person Owner { get; set; }                // Propriétaire du compte

    // --- Constructeur ---
    public CurrentAccount(string number, Person owner, double creditLine)
    {
        Number = number;
        Owner = owner;
        CreditLine = creditLine;
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
    public void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Le montant du retrait doit être positif.");
            return;
        }

        if (Balance - amount < -CreditLine)
        {
            Console.WriteLine("Fonds insuffisants. Retrait refusé.");
            return;
        }

        Balance -= amount;
        Console.WriteLine($"Retrait de {amount:C} effectué. Nouveau solde : {Balance:C}");
    }

    // --- Méthode d'affichage optionnelle ---
    public override string ToString()
    {
        return $"Compte n°{Number}, Propriétaire : {Owner.FirstName}, Solde : {Balance:C}, Découvert autorisé : {CreditLine:C}";
    }
}