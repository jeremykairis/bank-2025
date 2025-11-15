/*
Définir l'interface IAccount afin de limiter l'acces à consulter la propriété Balance
et aux méthodes Deposit et Withdraw.
*/

// Définition de l'interface IAccount
public interface IAccount
{
    double Balance { get; }
    void Withdraw(double amount);
    void Deposit(double amount);
}