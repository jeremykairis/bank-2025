class Account(string nombre, double balance, Person owner)
{
    private string Nombre { get; set; } = nombre;
    private double Balance { get; set; } = balance;
    private Person owner { get;  set; } = owner;

    public virtual void Withdraw(double amount)
    {
        if (amount > Balance)
        {
            Console.WriteLine("Le solde est insuffisant.");
        }
        else
        {
            Balance -= amount;
        }
    }
    public virtual void Deposit(double amount)
    {
        Balance += amount;
    }
    // Constructeur avec le numéro et le titulaire
    //et le numéro, le titulaire et le solde comme paramètres
    private Account(string nombre, Person owner) : 
        this(nombre, 0.0, owner)
    {
    }

}