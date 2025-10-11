using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Bank
    {
        Dictionary<string, CurrentAccount> accounts = new Dictionary<string, CurrentAccount>();
        private static int id;
        private string name;

        public Bank(string name)
        {
            this.name = name;
            
        }

        public void AddAccount(CurrentAccount account)
        {
            id = id + 1;
            this.accounts.Add(id.ToString(), account);
        }

        public void DeleteAccount(string number)
        {
            this.accounts.Remove(number);
        }

        public void DisplayInfos(CurrentAccount account)
        {
            Console.WriteLine($"Le solde du compte n° {account.GetNumber()} appartenant à {account.GetOwner().ToString()} est de {account.GetBalance()} euros");
        }

        public double AllAccountSum(CurrentAccount account)
        {
            return account.GetBalance() + account.GetCreditLine();
        }

        public Dictionary<string, CurrentAccount> GetAccounts()
        {
            return this.accounts;
        }

        public string GetName()
        {
            return this.name;
        }

        public void SetName(string name)
        {
            this.name = name;
        }
    }
}
