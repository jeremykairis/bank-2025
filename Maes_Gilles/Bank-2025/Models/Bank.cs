class Bank {

    public Dictionary<string, Account> Accounts { get; private set; }
    public required string Name { get; set; }

    public Bank() {
        
        Accounts = new Dictionary<string, Account>();

    }

    public void AddAccount(Account account) { Accounts.Add(account.Number, account); }

    public void DeleteAccount(string number) { Accounts.Remove(number); }

    public double GetAccountBalance(Account account) { return account.Balance; }

    public double GetPersonAllAccountSum(Person person) {

        double sum = 0;

        foreach (Account account in Accounts.Values) {

            if (Equals(account.Owner, person)) sum += account.Balance;

        }

        return sum;

    }

    public void NegativeBalanceAction(Account account) => Console.WriteLine($"Le compte {account.Number} vient de passer en négatif");

}