using System;
using System.Collections.Generic;
using System.Linq;

namespace BanqueApp
{
    public class CompteBancaire
    {
        public string Numero { get; }
        public string Titulaire { get; }
        public decimal Solde { get; private set; }
        public string Type { get; }

        public CompteBancaire(string numero, string titulaire, string type)
        {
            Numero = numero;
            Titulaire = titulaire;
            Type = type;
            Solde = 0;
        }

        public void Depot(decimal montant)
        {
            Solde += montant;
            Console.WriteLine($"✅ Dépôt de {montant}€ effectué.");
        }

        public bool Retrait(decimal montant)
        {
            if (montant <= Solde)
            {
                Solde -= montant;
                Console.WriteLine($"✅ Retrait de {montant}€ effectué.");
                return true;
            }
            Console.WriteLine("❌ Fonds insuffisants.");
            return false;
        }

        public override string ToString()
        {
            return $"[{Type}] {Numero} - {Titulaire} : {Solde}€";
        }
    }

    public class Banque
    {
        private List<CompteBancaire> comptes = new List<CompteBancaire>();

        public void CreerCompte(string numero, string titulaire, string type)
        {
            if (RechercherCompte(numero) != null)
            {
                Console.WriteLine("❌ Ce numéro de compte existe déjà.");
                return;
            }
            comptes.Add(new CompteBancaire(numero, titulaire, type));
            Console.WriteLine("✅ Compte créé avec succès.");
        }

        public CompteBancaire RechercherCompte(string numero)
        {
            return comptes.FirstOrDefault(c => c.Numero == numero);
        }

        public void AfficherComptes()
        {
            if (comptes.Count == 0)
            {
                Console.WriteLine("📭 Aucun compte enregistré.");
                return;
            }
            Console.WriteLine("📋 Liste des comptes :");
            foreach (var compte in comptes)
            {
                Console.WriteLine(compte);
            }
        }

        public bool Virement(string source, string destination, decimal montant)
        {
            var compteSource = RechercherCompte(source);
            var compteDest = RechercherCompte(destination);

            if (compteSource != null && compteDest != null && compteSource.Retrait(montant))
            {
                compteDest.Depot(montant);
                Console.WriteLine("✅ Virement effectué.");
                return true;
            }
            Console.WriteLine("❌ Virement échoué.");
            return false;
        }
    }

    class Program
    {
        static void Main()
        {
            Banque banque = new Banque();
            bool continuer = true;

            while (continuer)
            {
                Console.WriteLine("\n--- MENU BANQUE ---");
                Console.WriteLine("1. Créer un compte");
                Console.WriteLine("2. Afficher les comptes");
                Console.WriteLine("3. Dépôt");
                Console.WriteLine("4. Retrait");
                Console.WriteLine("5. Virement");
                Console.WriteLine("6. Quitter");
                Console.Write("Choix : ");
                string choix = Console.ReadLine();

                switch (choix)
                {
                    case "1":
                        Console.Write("Numéro de compte : ");
                        string numero = Console.ReadLine();
                        Console.Write("Titulaire : ");
                        string titulaire = Console.ReadLine();
                        Console.Write("Type (Courant/Épargne) : ");
                        string type = Console.ReadLine();
                        banque.CreerCompte(numero, titulaire, type);
                        break;

                    case "2":
                        banque.AfficherComptes();
                        break;

                    case "3":
                        Console.Write("Numéro de compte : ");
                        var cDepot = banque.RechercherCompte(Console.ReadLine());
                        if (cDepot != null)
                        {
                            Console.Write("Montant à déposer : ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal montantDepot))
                                cDepot.Depot(montantDepot);
                        }
                        break;

                    case "4":
                        Console.Write("Numéro de compte : ");
                        var cRetrait = banque.RechercherCompte(Console.ReadLine());
                        if (cRetrait != null)
                        {
                            Console.Write("Montant à retirer : ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal montantRetrait))
                                cRetrait.Retrait(montantRetrait);
                        }
                        break;

                    case "5":
                        Console.Write("Compte source : ");
                        string src = Console.ReadLine();
                        Console.Write("Compte destination : ");
                        string dest = Console.ReadLine();
                        Console.Write("Montant : ");
                        if (decimal.TryParse(Console.ReadLine(), out decimal montantVirement))
                            banque.Virement(src, dest, montantVirement);
                        break;

                    case "6":
                        continuer = false;
                        Console.WriteLine("👋 Merci d’avoir utilisé l’application bancaire.");
                        break;

                    default:
                        Console.WriteLine("❌ Choix invalide.");
                        break;
                }
            }
        }
    }
}