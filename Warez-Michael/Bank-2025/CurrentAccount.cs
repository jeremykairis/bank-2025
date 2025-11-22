/*
creer une classe "CurrentAccount" qui permet la gestion d' un compte
propirété publique : Nombre,double balance(lecture seule), CreditLine ,Owner
methodes publiques : void Withdraw, void deposit(double amount)
*/
using System;
// Définition de la classe CurrentAccount qui hérite de Account
class CurrentAccount(string nombre, double balance, double creditline, Person Owner)



//: Account(nombre, balance, Owner)
{
    public string Nombre { get; set; } = nombre;
    private double _balance = balance;
    public double Balance => _balance;
    private decimal _creditLine = (decimal)creditline;
    internal required object lignecredit;

    public Person owner { get; set; } = Owner;

    // Méthode pour retirer de l'argent
    public void Withdraw(double amount)
    {
        if (amount > Balance)
        {
            Console.WriteLine("Solde insufisant");
        }
        else
        {
            _balance -= amount;
        }
    }
    // Méthode pour déposer de l'argent
    public void Deposit(double amount)
    {
        _balance += amount;
    }



    // Constructeur avec le numéro et le titulaire
    //et le numéro, le titulaire et le solde comme paramètres
    public CurrentAccount(string nombre, double balance, Person owner)
        : this(nombre, balance, 0.0, owner)
    {   
    }


    // Propriété pour la ligne de crédit
    private decimal creditline;
    public decimal Creditline
    {
        get => creditline;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value), "La valeur doit être supérieure ou égale à zéro.");
            creditline = value;
        }

    }

    public required object CreditLine { get; internal set; }


    // Méthode pour mettre à jour la ligne de crédit
    public void UpdateCreditLine(decimal newCreditLine)
    {
        Creditline = newCreditLine;
        Console.WriteLine("La ligne de crédit a été mise à jour.");
    }

    //Déclenchez l' évenement NegativeBalanceEvent lorsque le solde devient négatif

    private void NegativeBalanceEvent(CurrentAccount currentAccount)
    {
        throw new NotImplementedException();
    }
    
    private void CheckNegativeBalance()
    {
        if (Balance < 0)
        {
            NegativeBalanceEvent(this);
        }
    }

    
}
