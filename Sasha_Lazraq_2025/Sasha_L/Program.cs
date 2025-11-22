
    // 1. Classe Person
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }

        public Person(string firstName, string lastName, DateTime birthDate)
        {
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
        }

        public string FullName => $"{FirstName} {LastName}";
    }

    // 7 + 9. Classe abstraite Account
    public abstract class Account
    {
        public string Number { get; set; }
        public Person Owner { get; set; }

        public double Balance { get; private set; } // lecture seule à l'extérieur

        protected Account(string number, Person owner)
        {
            Number = number;
            Owner = owner;
            Balance = 0;
        }

        protected void ApplyDelta(double delta) => Balance += delta;

        public virtual void Deposit(double amount)
        {
            if (amount > 0)
                ApplyDelta(amount);
        }

        public virtual void Withdraw(double amount)
        {
            if (amount > 0 && Balance - amount >= 0)
                ApplyDelta(-amount);
        }

        public double GetBalance() => Balance;

        // 10. Méthode abstraite protégée
        protected abstract double CalculInterets();

        // 11. Méthode publique pour appliquer les intérêts
        public void ApplyInterest()
        {
            double interet = CalculInterets();
            ApplyDelta(interet);
        }
    }

    // 2. Classe CurrentAccount (hérite d’Account)
    public class CurrentAccount : Account
    {
        public double CreditLine { get; set; }

        public CurrentAccount(string number, double creditLine, Person owner)
            : base(number, owner)
        {
            CreditLine = creditLine;
        }

        public override void Withdraw(double amount)
        {
            if (amount > 0 && Balance - amount >= -CreditLine)
                ApplyDelta(-amount);
        }

        // Implémentation de CalculInterets()
        protected override double CalculInterets()
        {
            // 3% si solde positif, sinon 9.75%
            return Balance > 0 ? Balance * 0.03 : Balance * 0.0975;
        }
    }

    // 6. Classe SavingsAccount (hérite d’Account)
    public class SavingsAccount : Account
    {
        public DateTime DateLastWithdraw { get; private set; }

        public SavingsAccount(string number, Person owner)
            : base(number, owner)
        {
            DateLastWithdraw = DateTime.MinValue;
        }

        public override void Withdraw(double amount)
        {
            if (amount > 0 && Balance - amount >= 0)
            {
                ApplyDelta(-amount);
                DateLastWithdraw = DateTime.Now;
            }
        }

        // Implémentation de CalculInterets()
        protected override double CalculInterets()
        {
            // Taux fixe de 4.5%
            return Balance * 0.045;
        }
    }

    // 3 + 8. Classe Bank
    public class Bank
    {
        public string Name { get; set; }
        private Dictionary<string, Account> _accounts;
        public IReadOnlyDictionary<string, Account> Accounts => _accounts;

        public Bank(string name)
        {
            Name = name;
            _accounts = new Dictionary<string, Account>();
        }

        public void AddAccount(Account account)
        {
            if (!_accounts.ContainsKey(account.Number))
                _accounts.Add(account.Number, account);
        }

        public void DeleteAccount(string number)
        {
            if (_accounts.ContainsKey(number))
                _accounts.Remove(number);
        }

        public double GetTotalBalanceOfPerson(Person person)
        {
            double total = 0;
            foreach (var account in _accounts.Values)
            {
                if (account.Owner == person)
                    total += account.Balance;
            }
            return total;
        }
    }

    // Programme principal
    class Program
    {
        static void Main(string[] _)
        {
            var client1 = new Person("Sasha", "Lazraq", new DateTime(1998, 11, 19));
            var client2 = new Person("Alex", "Dupont", new DateTime(1995, 3, 10));

            var current1 = new CurrentAccount("BE123", 500, client1);
            var savings1 = new SavingsAccount("BE999", client1);

            var current2 = new CurrentAccount("BE124", 300, client2);
            var savings2 = new SavingsAccount("BE998", client2);

            var bank = new Bank("Life Bank");

            bank.AddAccount(current1);
            bank.AddAccount(savings1);
            bank.AddAccount(current2);
            bank.AddAccount(savings2);

            // Opérations
            current1.Deposit(1000);
            savings1.Deposit(5000);
            current1.Withdraw(200);
            savings1.Withdraw(300);

            Console.WriteLine($"Solde avant intérêts : {savings1.GetBalance()} €");

            // Application des intérêts
            current1.ApplyInterest();
            savings1.ApplyInterest();

            Console.WriteLine($"Solde après intérêts compte courant : {current1.GetBalance()} €");
            Console.WriteLine($"Solde après intérêts compte épargne : {savings1.GetBalance()} €");

            double total = bank.GetTotalBalanceOfPerson(client1);
            Console.WriteLine($"\nSomme totale des comptes de {client1.FullName} : {total} €");

            Console.WriteLine("\nAppuyez sur une touche pour quitter...");
            Console.ReadKey();
        }
    }

