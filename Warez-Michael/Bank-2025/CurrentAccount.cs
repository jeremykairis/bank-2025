/*
creer une classe "CurrentAccount" qui permet la gestion d' un compte
propirété publique : Nombre,double balance(lecture seule), CreditLine ,Owner
methodes publiques : void Withdraw, void deposit(double amount)
*/

class CurrentAccount(string nombre,double balance, double creditline, Person Owner)

{
    public string Nombre { get; set; } = nombre;
    private double _balance = balance;
    public double Balance => _balance;
    public double creditline { get; set; } = creditline;

    public Person owner { get; set; } = Owner;
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

    public void Deposit(double amount)
    {
        _balance += amount;
    }
}