internal interface IAccount
{
    string Number { get; }
    double Balance { get; }
    void Deposit(double amount);
    void Withdraw(double amount);
}