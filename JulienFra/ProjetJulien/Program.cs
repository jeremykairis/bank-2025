public class Person
{
    public string FirstName;
    public string LastName;
    public DateTime BirthDate;

    public Person(string firstName, string lastName, DateTime birthDate)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
    }
}

public class CurrentAccount
{
    public string Number { get; set; }
    public double Balance { get; private set; }
    public double CreditLine { get; set; }
    public Person Owner { get; set; }
    public CurrentAccount(string number, Person owner, double creditLine = 0)
    {
        Number = number;
        Owner = owner;
        CreditLine = creditLine;
        Balance = 0;
    }
    public void Withdraw(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("le montant d'un retrait doit être positif");
            return;
        }
        if (Balance - amount < -CreditLine)
        {
            Console.WriteLine("Fond insuffisant");
            return;
        }
        Balance -= amount;
    }
    public void Deposit(double amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("Le montant doit être positif.");
            return;
        }
        Balance += amount;
    }
    public double GetBalance()
    {
        return Balance;
    }
}

public class Bank
{
    public Dictionary<string, CurrentAccount> Account { get; } = new();
    public string Name { get; set; }
    public Bank(string name)
    {
        Name = name;
    }
    public void AddAccount(CurrentAccount account)
    {
        if (!Account.ContainsKey(account.Number))
        {
            Account.Add(account.Number, account);
        }
        else
        {
            Console.WriteLine("Ce compte existe déjà !");
        }
    }
    public void DeleteAccount(string number)
    {
        if (Account.ContainsKey(number))
        {
            Account.Remove(number);
        }
        else
        {
            Console.WriteLine("Aucun compte avec ce numéro trouvé.");
        }
    }
    public double GetTotalBalance(Person person)
    {
        double total = 0;

        foreach (var acc in Account.Values)
        {
            if (acc.Owner == person)
            {
                total += acc.GetBalance();
            }
        }

        return total;
    }

}