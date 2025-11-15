using person;

namespace account
{
    public interface IAccount
    {
        public double Balance { get; }
        public void Withdraw() {}
        public void Deposit() {}
    }

    public interface IBankAccount : IAccount
    {
        public Person Owner { get; }
        public string Number { get; }
        public void ApplyInteret() {}
    }

    public class InsufficientBalanceException : Exception
    {

        public InsufficientBalanceException(string message) : base(message)
        {
            Console.WriteLine(message);
        }
    }

    public delegate void NegativeBalanceDelegate(object sender, EventArgs e);

    public abstract class Account : IBankAccount
    {
        public string Number { get; private set; }
        public double Balance { get; private set; }
        public Person Owner { get; private set; }

        public event NegativeBalanceDelegate? NegativeBalanceEvent;


        public Account(string number, Person owner)
        {
            this.Number = number;
            this.Owner = owner;
        }

        public Account(string number, Person owner, double balance)
        {
            this.Number = number;
            this.Owner = owner;
            this.Balance = balance;
        }

        protected void OnNegativeBalance(EventArgs e) {NegativeBalanceEvent?.Invoke(this, e);}

        public virtual void Withdraw(double amount) 
        {
            if (this.Balance > amount)
            {
                this.Balance -= amount; 
            }
            else
            {
                throw new InsufficientBalanceException("The account cannot withdraw that amount of money.");
            }
        }

        public virtual void Deposit(double amount)
        { 
            if (amount > 0)
            {
                this.Balance += amount; 
            }
            else
            {
                throw new ArgumentOutOfRangeException("The amount is lower than zero.");
            }
        }

        public virtual double GetBalance() { return this.Balance; }

        protected abstract double CalculInterets();

        public void ApplyInteret() { this.Balance += CalculInterets(); }
    }

    public class CurrentAccount : Account
    {
        public double CreditLine 
        { 
            get { return CreditLine; }
            set
            {
                if (value <= 0)
                {
                    CreditLine = value;
                } 
                else
                { 
                    throw new ArgumentOutOfRangeException();
                }
            }
        }
        protected const double positiveInterest = 0.03;
        protected const double negativeInterest = 0.0975;

        public CurrentAccount(string number, Person owner) : base (number, owner) {}
        public CurrentAccount(string number, Person owner, double balance) : base (number, owner, balance) {}

        public override void Withdraw(double amount) 
        {
            base.Withdraw(amount);
            if (this.Balance < 0)
            {
                this.OnNegativeBalance(EventArgs.Empty);
            }
        }

        public override double GetBalance() 
        {
            return this.Balance;
        }

        protected override double CalculInterets()
        {
            if (GetBalance() > 0)
            {
                return GetBalance() * positiveInterest;
            }
            else
            {
                return GetBalance() * negativeInterest;
            }
        }
    }

    public class SavingsAccount : Account
    {
        public DateTime DateLastWithdraw { get; private set; }
        public SavingsAccount(string number, Person owner) : base(number, owner) {}
        public SavingsAccount(string number, Person owner, double balance) : base (number, owner, balance) {}

        public override void Withdraw(double amount)
        {
            base.Withdraw(amount);
            this.DateLastWithdraw = DateTime.Today;
        }

        protected override double CalculInterets() { return GetBalance() * 0.045; }
    }
}