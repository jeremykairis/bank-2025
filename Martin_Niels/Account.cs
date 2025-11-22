namespace BankApplication_Personnel
{
    class Account
    {
        // { get; set; } : get -> allows reading of variable, set -> allows assigning value to variable
        public long CheckingAccountNumber { get; set; } // Long type (16 numbers)
        public long SavingAccountNumber { get; set; }
        public long CheckingAccBalance { get; set; }
        public long SavingAccBalance { get; set; }
        public required string IBAN { get; set; } // Alphanumeric
        public required string Name { get; set; }
        public required string FirstName { get; set; }

        public void Transaction(long amount, long accTypeNumber, bool transaction = true) // If transaction = true -> add montant
        {
            long Balance = 0;
            if (accTypeNumber == CheckingAccountNumber)
            {
                Balance = CheckingAccBalance;
            }
            else
            {
                Balance = SavingAccBalance;
            }

            if (transaction == false && (Balance - amount < 0))
            {
                Console.WriteLine("You don't have enough money on your account.");
                return;
            }
            Balance += (transaction) ? amount : -amount;
        }

        public long ShowCheckingAccountBalance()
        {
            return CheckingAccBalance;
        }
        public long SumOfAllAccountsBalance()
        {
            return (CheckingAccBalance + SavingAccBalance);
        }
    }
}

namespace BankApplication_Cours
{
    public interface IAccount
    {
        // Interface "cache" les méthodes
        // To achieve security - hide certain details and only show the important details of an object (interface).
        public double Balance { get; }
        public void Withdraw(double amount);
        public void Deposit(double amount);
    }

    public interface IBankAccount : IAccount
    {
        public void ApplyInterest();
        public Person Owner { get; } // accès en lecture seulement
        public string AccNumber { get; }
        
        
    }
    abstract class Account : IBankAccount
    {
        // Cette classe va être la classe parente dont SavingsAccount et CurrentAccount vont hériter
        public Account(string accNumber, Person owner) { AccNumber = accNumber; Owner = owner; } // Constructeur qui prends le num et le titulaire
        public Account(string accNumber, Person owner, double balance) { AccNumber = accNumber; Owner = owner; Balance = balance; } // Constructeur qui prends num, titulaire et solde
        public string AccNumber { get; private set; } // Property is accessible/readable by everyone, but only modified in within the class
        public double Balance { get; private set; } // Property is accessible/readable by everyone, but only modified in within the class
        public Person Owner { get; private set; } // Owner is an object

        public virtual void Withdraw(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("Amount cannot be negatif");
            }
            else if ((Balance - amount) < 0)
            {
                throw new InsufficientBalanceException("You don't have enough money in your bank account.");
            }
            else
            {
                Balance -= amount;
            }
        }
        public virtual void Deposit(double amount)
        {
            if (amount < 0)
            {
                throw new ArgumentOutOfRangeException("Amount cannot be negatif.");
            }
            else
            {
                Balance += amount;
            }
        }

        abstract protected double CalculInterest();
        public void ApplyInterest()
        {
            Balance += CalculInterest();
        }

        // EVENTS
        public event Action<object, EventArgs> NegativeBalanceEvent; // Changez type de l'event en utilisant Action<>
        public virtual void OnNegativeBalance()
        {
            NegativeBalanceEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}