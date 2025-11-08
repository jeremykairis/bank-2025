class Bank
{
    public string BankName { get; private set; }
    public Dictionary<string, CurrentAccount> Accounts { get; private set; }

    public Bank(string name, Dictionary<string, CurrentAccount> accounts)
    {
        BankName = name;
        Accounts = accounts;
    }

    void AddAccount(CurrentAccount account)
    {
        if (Accounts.ContainsKey(account.Number))
        {
            throw new ArgumentException("Account with this number already exists.");
        }
        Accounts[account.Number] = account;
    }
    void deleteAccount(string accountNumber)
    {
        if (!Accounts.ContainsKey(accountNumber))
        {
            throw new KeyNotFoundException("Account not found.");
        }
        Accounts.Remove(accountNumber);
    }
    double getBalance(string accountNumber)
    {
        if (!Accounts.ContainsKey(accountNumber))
        {
            throw new KeyNotFoundException("Account not found.");
        }
        return Accounts[accountNumber].Balance;
    }
    double getWholeBalance()
    {
        double totalBalance = 0;
        foreach (var account in Accounts.Values)
        {
            totalBalance += account.Balance;
        }
        return totalBalance;
    }
}