using LoïcBoulanger2.Domain;

namespace Loic_Boulanger.Domaine;

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
    public void AddAccount(IBankAccount account)
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
        
        // --- 🔹 Méthode pour retourner le solde d’un compte ---
        double GetBalance(string number)
        {
            if (Accounts.ContainsKey(number))
            {
                return Accounts[number].Balance;
            }

            Console.WriteLine($"Erreur : le compte n°{number} n'existe pas.");
            return 0.0;
        }

        // --- 🔹 Méthode pour obtenir la somme totale des comptes d’une personne ---
        double GetTotalBalance(Person owner)
        {
            double total = Accounts.Values
                .Where(acc => acc.Owner == owner)
                .Sum(acc => acc.Balance);

            Console.WriteLine($"Somme totale des comptes de {owner.LastName} : {total:C}");
            return total;
        }

        
    
    }
}