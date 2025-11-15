/*
Définir l'interface IBankAccount et invoquer la methode ApplyInterest et d' offrir l'
accès en lecture au "Owner" et au "Number"
*/

// Définition de l'interface IBankAccount
public interface IBankAccount
{
    string Number { get; set; }
    double Balance { get; }

    
// Propriété pour le titulaire du compte
    void Deposit(double amount);
    void Withdraw(double amount);
    void ApplyInterest();

}

