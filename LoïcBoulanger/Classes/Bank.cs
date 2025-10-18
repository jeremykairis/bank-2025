namespace LoïcBoulanger.Classes;
public class Bank
{
    // --- Propriétés ---
    public string Name { get; set; }  // Nom de la banque
    public Dictionary<string, CurrentAccount> Accounts { get; private set; }  // Lecture seule

    // --- Constructeur ---
    public Bank(string name)
    {
        Name = name;
        Accounts = new Dictionary<string, CurrentAccount>();
    }

    // --- Méthode pour ajouter un compte ---
    public void AddAccount(CurrentAccount account)
    {
        if (Accounts.ContainsKey(account.Number))
        {
            Console.WriteLine($"Erreur : le compte n°{account.Number} existe déjà.");
            return;
        }

        Accounts.Add(account.Number, account);
        Console.WriteLine($"Compte n°{account.Number} ajouté avec succès à la banque {Name}.");
    }

    // --- Méthode pour supprimer un compte ---
    public void DeleteAccount(string number)
    {
        if (!Accounts.ContainsKey(number))
        {
            Console.WriteLine($"Erreur : le compte n°{number} n'existe pas.");
            return;
        }

        Accounts.Remove(number);
        Console.WriteLine($"Compte n°{number} supprimé avec succès.");
    }

    // --- (Optionnel) Méthode pour afficher tous les comptes ---
    public void DisplayAccounts()
    {
        Console.WriteLine($"\nListe des comptes dans la banque {Name}:");

        if (Accounts.Count == 0)
        {
            Console.WriteLine("Aucun compte enregistré.");
            return;
        }

        foreach (var account in Accounts.Values)
        {
            Console.WriteLine(account);
        }
    }
}