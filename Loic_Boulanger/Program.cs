using System;
using Loic_Boulanger.Domaine;

class Program
{

    static void Main(string[] args)
        {
            // --- Création d'une banque ---
            Bank myBank = new Bank("Banque du Loïc");

            // --- Création d'une personne ---
            Person loic = new Person("Loïc", "Boulanger");

            // --- Création d'un compte courant avec découvert autorisé de 500 ---
            CurrentAccount loicAccount = new CurrentAccount("CC001", loic, 500);

            // --- Ajout du compte à la banque (s'abonne automatiquement à l'événement) ---
            myBank.AddAccount(loicAccount);

            // --- Dépôt initial ---
            loicAccount.Deposit(200);

            // --- Retrait normal (solde reste positif) ---
            loicAccount.Withdraw(100);

            // --- Retrait qui passe le solde en négatif ---
            loicAccount.Withdraw(300); // Devrait déclencher NegativeBalanceEvent

            // --- Retrait dépassant le découvert ---
            loicAccount.Withdraw(500); // Devrait être refusé

            // --- Affichage des comptes ---
            myBank.DisplayAccounts();

            Console.WriteLine("\nAppuyez sur une touche pour quitter...");
            Console.ReadKey();
        }
    }

