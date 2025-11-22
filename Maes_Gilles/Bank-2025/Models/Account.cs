public delegate void NegativeBalanceDelegate(Account account);

public abstract class Account : IBankAccount{
    
    public string Number { get; private set; }
    public double Balance { get; protected set; }
    public Person Owner { get; private set; }

    public event Action<Account> NegativeBalanceEvent;

    public Account(string Number, Person Owner) {
        
        this.Number = Number;
        this.Owner = Owner;

    }

    public Account(string Number, Person Owner, double Balance) {
        
        this.Number = Number;
        this.Owner = Owner;
        this.Balance = Balance;

    }

    public virtual void Withdraw(double amount) {
        
        if(amount < 0) throw new ArgumentOutOfRangeException("Le montant doit être supérieur à 0");
        else if(amount > Balance) throw new InsufficientBalanceException("Solde insuffisant");
        else Balance -= amount;

    }  
        
    public virtual void Deposit(double amount) {
        
        if(amount < 0) throw new ArgumentOutOfRangeException("Le montant doit être supérieur à 0");
        else Balance += amount;
        
    }
    protected abstract double CalculInterest();
    public void ApplyInterest() => Balance += CalculInterest();

    protected void OnNegativeBalance() => NegativeBalanceEvent?.Invoke(this);

}