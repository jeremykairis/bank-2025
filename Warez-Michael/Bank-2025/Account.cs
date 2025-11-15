using Microsoft.VisualBasic.FileIO;

class Account(string nombre, double balance, Person owner)
{
    private string Nombre { get; set; } = nombre;
    private double Balance { get; set; } = balance;
    private Person owner { get; set; } = owner;

    public virtual void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Le montant du retrait doit être supérieur à zéro.");
        }
        if (amount > Balance)
        {
            throw new InvalidOperationException("Fonds insuffisants pour le retrait.");
        }
        Balance -= amount;
    }

    public virtual void Deposit(double amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Le montant du dépôt doit être supérieur à zéro.");
        }

        Balance += amount;
    }

    // Constructeur avec le numéro et le titulaire
    //et le numéro, le titulaire et le solde comme paramètres
    private Account(string nombre, Person owner) :
        this(nombre, 0.0, owner)
    {
    }
    // ajouter un événement appelé NegativeBalanceEvent dont le délégué "NegativeBalanceDelegate"
    // devra recevoir en parametre un objet de type "account" et ne rien envoyer

    // Déclaration du délégué
    public delegate void NegativeBalanceDelegate(Account account);

    // Déclaration de l'événement
    public event NegativeBalanceDelegate? NegativeBalanceEvent;

    // Changer le type de l'événement appelée "BalanceNegativeEvent" en utilisant le délégué "action" ou "func"
    public event Action<Account>? BalanceNegativeEvent;

    public event Func<Account, bool>? BalanceNegativeFuncEvent;
    
    
}