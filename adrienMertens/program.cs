class Person
{
    private string FirstName;
    private string LastName;
    private DateTime BirthDate;
}

class CurrentAccount
{
    private string number;
    private double readonly balance;
    private double creditLine;
    private Person owner;

    public void WithDraw(double amount)
    {
        
    }
    public void Deposit(double amount)
    {
        
    }
}

class Bank
{
    private readonly Dictionary<string, CurrentAccount> _accounts
    private string name;
    
    public void AddAccount(CurrentAccount account)
    {
        
    }

    public void DeleteAccount(string number)
    {
        
    }

    public double ReturnSoldeCurrentAccount()
    {
        
    }
    public void ShowAllCurrentAccounts()
    {
        
    }
}
