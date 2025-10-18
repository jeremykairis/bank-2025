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
    public void GetBalance(string number)
    {
        if (Accounts.ContainsKey(number))
        {
            Console.WriteLine($"Compte : {number} | Solde : {Accounts[number].Balance}€");
        }
        else
        {
            Console.WriteLine($"Le compte {number} n'existe pas");
        }
    }
    public void GetAccountsInfos(Person user)
    {
        double totalBalance = 0;
        bool hasAccount = false;
        foreach (CurrentAccount account in Accounts.Values)
        {
            if (user == account.Owner)
            {
                totalBalance += account.Balance;
                hasAccount = true;
                GetBalance(account.Number);
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