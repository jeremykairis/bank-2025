public class Person(string firstName, string lastName, DateTime birthDate) 
{
    public string FirstName {get; set;} = firstName;
    public string LastName {get; set;} = lastName;
    public DateTime BirthDate {get; set;} = birthDate;
}

public class CurrentAccount
{
    public string Number { get; set; }
    public double Balance { get; private set; } 
    public double CreditLine { get; set; }
    public Person Owner { get; set; }

    public void Withdraw(double amount)
    {
        this.Balance = this.Balance - amount;
    }

    public void Deposit(double amount)
    {
        this.Balance = this.Balance + amount;
    }
}

public class Bank
{
    public Dictionary<string, CurrentAccount> Accounts { get; private set; } = new Dictionary<string, CurrentAccount>();
    public required string Name { get; set; }

    public void AddAccount(string number, CurrentAccount account)
    {
        Accounts.Add(number, account);
    }

    public void DeleteAccount(string number) => Accounts.Remove(number);

    public string GetRegisterOfPersonAccount(Person Owner)
    {
        string view = "";
        foreach (CurrentAccount account in Accounts.Values)
        {
            if (account.Owner == Owner)
            {
                view = $"{view} \n {account.Owner} : {account.Number} => solde = {account.Balance}";
            }
        }
        return view;
    }
}