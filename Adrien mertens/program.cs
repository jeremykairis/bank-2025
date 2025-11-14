using Adrien_mertens;

/// <summary>
/// Point d'entrée de l'application de démonstration bancaire.
/// </summary>
class Program
{
    /// <summary>
    /// Méthode principale qui illustre la création d'une banque,
    /// d'une personne et d'un compte courant, ainsi que quelques opérations.
    /// </summary>
    static void Main()
    {
        // Création d'une banque.
        var bank = new Bank();

        // Création d'une personne qui sera titulaire du compte.
        var person = new Person("Adrien", "Mertens", new DateTime(2000, 10, 23));

        // Création d'un compte courant avec une ligne de crédit de 1000.
        var account = new CurrentAccount("BE123456789", person, 1000);
        
        // Ajout du compte à la banque.
        bank.AddAccount(account);

        // Dépôt d'un montant de 2000 sur le compte.
        account.Deposit(2000);

        // Retrait d'un montant de 100 sur le compte.
        account.WithDraw(100);

        // Affichage du solde actuel du compte via la banque.
        Console.WriteLine($"Le solde du compte {account.Number} est de {bank.ReturnSoldeCurrentAccount(account.Number)}");

        // Affichage de tous les comptes de la banque.
        bank.ShowAllCurrentAccounts();
        
        // Suppression du compte de la banque.
        bank.DeleteAccount(account.Number);
    }
}