using System;
using System.Collections.Generic;
using System.Linq;

namespace Loic_Boulanger.Domaine
{
    public class Bank
    {
        // --- Propriétés ---
        public string Name { get; set; }  // Nom de la banque
        public Dictionary<string, IBankAccount> Accounts { get; private set; }  // Liste des comptes

        // --- Constructeur ---
        public Bank(string name)
        {
            Name = name;
            Accounts = new Dictionary<string, IBankAccount>();
        }
                // --- Méthode pour gérer l'événement ---
        public void NegativeBalanceAction(Account account)
        {
            Console.WriteLine($"⚠️ Alerte : le compte n°{account.Number} de {account.Owner} est à découvert ! Solde actuel : {account.Balance:C}");
        }

        // --- Méthode pour ajouter un compte ---
        public void AddAccount(IBankAccount account)
        {
        if (Accounts.ContainsKey(account.Number))
            {
                Console.WriteLine($"❌ Erreur : le compte n°{account.Number} existe déjà.");
                return;
            }

            Accounts.Add(account.Number, account);

            // --- Abonnement à l'événement NegativeBalanceEvent ---
            if (account is CurrentAccount acc)
        {
            acc.NegativeBalanceEvent += NegativeBalanceAction;
        }

            Console.WriteLine($"✅ Compte n°{account.Number} ajouté avec succès à la banque {Name}.");
        }
        // --- Méthode pour supprimer un compte ---
        public void DeleteAccount(string number)
        {
            if (!Accounts.ContainsKey(number))
            {
                Console.WriteLine($"❌ Erreur : le compte n°{number} n'existe pas.");
                return;
            }

            Accounts.Remove(number);
            Console.WriteLine($"🗑️ Compte n°{number} supprimé avec succès.");
        }

        // --- Méthode pour afficher tous les comptes ---
        public void DisplayAccounts()
        {
            Console.WriteLine($"\n📋 Liste des comptes dans la banque {Name}:");

            if (Accounts.Count == 0)
            {
                Console.WriteLine("Aucun compte enregistré.");
                return;
            }

            foreach (var account in Accounts.Values)
            {
                Console.WriteLine($"- Compte n°{account.Number}, propriétaire : {account.Owner}, solde : {account.Balance:C}");
            }
        }

        // --- Méthode pour retourner le solde d’un compte ---
        public double GetBalance(string number)
        {
            if (Accounts.TryGetValue(number, out var account))
            {
                return account.Balance;
            }

            Console.WriteLine($"❌ Erreur : le compte n°{number} n'existe pas.");
            return 0.0;
        }

        // --- Méthode pour obtenir la somme totale des comptes d’une personne ---
        public double GetTotalBalance(Person owner)
        {
            double total = Accounts.Values
                .Where(acc => acc.Owner == owner)
                .Sum(acc => acc.Balance);

            Console.WriteLine($"💰 Somme totale des comptes de {owner.LastName} : {total:C}");
            return total;
        }
        
    }
}
