using System;
// Définition de la classe Bank qui gère un ensemble de comptes courants
class Bank(Dictionary<string, CurrentAccount> accounts, string name)
{
    public Dictionary<string, CurrentAccount> Accounts { get; private set; } = accounts;
    public string Name { get; set; } = name;
    public Bank(string name) : this([], name)
    {
        {
            Accounts = [];
            Name = name;

        }

    }


    // Méthode pour ajouter un compte courant
    public void AddAccount(CurrentAccount account)
    {
        if (Accounts.ContainsKey(account.Nombre))
        {
            Console.WriteLine("Ce compte existe déja !");
        }
        else
        {
            Accounts.Add(account.Nombre, account);
        }

    }
    // Méthode pour supprimer un compte courant
    public void RemoveAccount(CurrentAccount account, string nombre)
    {
        if (Accounts.ContainsKey(nombre))
        {
            Accounts.Remove(account.Nombre);
            Console.WriteLine("Le compte est supprimé.");
        }
        else
        {
            Console.WriteLine("Compte inexistant !");
        }
    }
    // Méthode pour obtenir le solde d'un compte courant
    public void GetBalance(string nombre)
    {
        if (Accounts.ContainsKey(nombre))
        {
            Console.WriteLine($"Le solde du compte {nombre} est de {Accounts[nombre].Balance}.");
        }
        else
        {
            Console.WriteLine("Compte inexistant !");

        }
    }
    // Méthode pour obtenir les informations d'un compte courant   
    public void GetAccountInfo(Person user)
    {
        double totalBalance = 0;
        bool hasAccount = false;
        foreach (var account in Accounts.Values)
        {
            if (account.owner == user)
            {
                Console.WriteLine($"Compte: {account.Nombre} : Solde: {account.Balance} : Ligne de crédit: {account.lignecredit}");
                totalBalance += account.Balance;
                hasAccount = true;
            }
        }
        // Afficher le solde total ou un message si aucun compte n'est trouvé
        if (!hasAccount)
        {
            Console.WriteLine("Aucun compte trouvé pour cet utilisateur.");
        }
        else
        {
            Console.WriteLine($"Solde total pour {user.FirstName} {user.LastName}: {totalBalance}");
        }
    }
    // Méthode pour supprimer un compte courant
    public void RemoveAccount(CurrentAccount account1)
    {
        if (account1 == null)
        {
            Console.WriteLine("Compte invalide !");
            return;
        }

        if (Accounts.ContainsKey(account1.Nombre))
        {
            Accounts.Remove(account1.Nombre);
            Console.WriteLine("Le compte est supprimé.");
        }
        else
        {
            Console.WriteLine("Compte inexistant !");
        }
    }

    // Méthode pour obtenir le solde d'un compte courant
    public void GetBalance(CurrentAccount account1)
    {
        if (account1 == null)
        {
            Console.WriteLine("Compte invalide !");
            return;
        }

        if (Accounts.ContainsKey(account1.Nombre))
        {
            Console.WriteLine($"Le solde du compte {account1.Nombre} est de {account1.Balance}.");
        }
        else
        {
            Console.WriteLine("Compte inexistant !");
        }
    }
    // Méthode qui traitera l'evenement "negativeBalanceAction" 
    public void NegativeBalanceAction(Account account)
    {
        Console.WriteLine($"Attention : Le  numéro de compte {account} a un solde négatif !");
    }
}