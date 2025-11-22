class Bank
{
    public readonly Dictionary<string, Account> Accounts = new();
    public string Name;

    public Bank(string name)
    {
        Name = name;
    }

    public void AddAccount(Account account)
    {
        Accounts[account.Number] = account;
        
        account.NegativeBalanceEvent += NegativeBalanceAction;
    }

    public void RemoveAccount(string accountNumber)
    {
        if (Accounts.TryGetValue(accountNumber, out var account))
        {
            account.NegativeBalanceEvent -= NegativeBalanceAction;
            Accounts.Remove(accountNumber);
        }
    }

    private void NegativeBalanceAction(Account account)
    {
        Console.WriteLine($"Le numéro de compte {account.Number} vient de passer en négatif");
    }
}