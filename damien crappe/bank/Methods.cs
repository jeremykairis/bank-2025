class Methods
{
    public void ShowMoney(CurrentAccount account)
    {
        Console.WriteLine($"Le compte {account.Number} a un solde de {account.Balance} euros.");
    }
    public void ShowMoneySum(Bank bank, Person owner)
    {
        double SumAccount = 0;
        foreach (var account in bank.Accounts.Values)
        {
            if (account.Owner.FirstName == owner.FirstName && account.Owner.LastName == owner.LastName)
            {
                SumAccount += account.Balance;
            }
        }
        Console.WriteLine($"La somme des comptes de {owner.FirstName} {owner.LastName} est de {SumAccount} euros.");
        return;
    }
}
