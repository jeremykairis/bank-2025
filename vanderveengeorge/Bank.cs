class Bank(Dictionary<string, CurrentAccount> accounts, string name)
{
    public Dictionary<string, CurrentAccount> Accounts { get; private set; } = accounts;
    public string Name { get; set; } = name;
    public void AddAccount(CurrentAccount account)
    {
        if (Accounts.ContainsKey(account.Number))
        {
            Console.WriteLine("Le compte existe déjà !");
        }
        else
        {
            Accounts.Add(account.Number, account);
        }
    }
    public void DeleteAccount(string number)
    {
        if (Accounts.ContainsKey(number))
        {
            Accounts.Remove(number);
        }
        else
        {
            Console.WriteLine("Le compte n'existe pas !");
        }
    }
    public void GetAccountsInfos(Person user)
    {
        double totalBalance = 0;
        bool hasAccount = false;
        foreach (CurrentAccount account in Accounts.Values)
        {
            if (user.FirstName == account.Owner.FirstName
            && user.LastName == account.Owner.LastName
            && user.BirthDate == account.Owner.BirthDate)
            {
                totalBalance += account.Balance;
                hasAccount = true;
                account.GetBalance();
            }
        }
        if (hasAccount)
        {
            Console.WriteLine($"Solde total de {user.FirstName} {user.LastName} : {totalBalance}€");
        }
        else
        {
            Console.WriteLine($"{user.FirstName} {user.LastName} n'a pas de comptes");
        }
    }
}