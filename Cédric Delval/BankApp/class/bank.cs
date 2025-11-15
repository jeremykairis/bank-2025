using person;
using account;

namespace bank
{
    public class Bank
    {
        public Dictionary<string, Account> Accounts { get; private set; } = new Dictionary<string, Account>();
        public required string Name { get; set; }

        // Note à moi même : Toute méthode doit conserver l'usage des délégués pour être intégré à ceux-ci à savoir
        //      => ses paramètres (object sender, EventArgs e)

        //  L'usage interne de la méthode devra donc manipuler l'object sender.
        //  Compte tenu de l'incertitude du compilateur, le typage var est préférable.
        public void callbalance(object sender, EventArgs e)
        {
            var account = (Account)sender;
            Console.WriteLine($"Le numéro de compte {account.Number} vient de passer en négatif");
        }

        public void NegativeBalanceAction(Account account)
        {
            account.NegativeBalanceEvent += callbalance;
        }

        public void AddAccount(string number, Account account) 
        {
            Accounts.Add(number, account);
        }

        public void DeleteAccount(string number) 
        {
            Accounts.Remove(number);
        }

        public string GetRegisterOfPersonAccount(Person Owner)
        {
            string view = "";
            foreach (Account account in Accounts.Values)
            {
                if (account.Owner == Owner)
                {
                    view = $"{view} \n {account.Owner.FirstName} {account.Owner.LastName} : {account.Number} => solde = {account.Balance}";
                }
            }
            return view;
        }
    }
}