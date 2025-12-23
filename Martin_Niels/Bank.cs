namespace BankApplication_Personnel
{
    class Bank
    {
        public required string NameBank; // Public properties start with capital letter
        private List<long> usedCheckingAccountNumbers = new List<long>(); // Use List because don't need to know size when instantiating it.
        private List<long> usedSavingsAccountNumbers = new List<long>();
        private List<long> usedIBANNumbers = new List<long>(); // Use List because don't need to know size when instantiating it.
        private List<BankApplication_Personnel.Account> accounts = new List<BankApplication_Personnel.Account>();
        private Random random = new Random();   // Need to be here bc ensure there's only one random generator used by the entire Bank class instance. 
                                                // C# seeds random instance on time (in milliseconds), so if you create multiple Random objects
                                                // In quick succession, all those instances might get the same seed.
        public BankApplication_Personnel.Account CreateAccount(string name, string firstName, int balance = 1000)
        {
            // CHECKING ACCOUNT
            // Random CheckingAccountNumber
            bool checkOver = false;
            long numCheckingAccount = 0;
            do // Check if numAccount is in usedAccountNumbers
            {
                numCheckingAccount = random.NextInt64(1000000000000000, 9999999999999999); // Random account number
                checkOver = (usedCheckingAccountNumbers.Contains(numCheckingAccount)) ? true : false; // If contains numAccount -> checkOver = false (keep loop)
            } while (checkOver); // 

            usedCheckingAccountNumbers.Add(numCheckingAccount); // Add new account to list of used account numbers

            // SAVINGS ACCOUNT
            // Random SavingsAccountNumber
            checkOver = false;
            long numSavingsAccount = 0;
            do
            {
                numSavingsAccount = random.NextInt64(1000000000000000, 9999999999999999);
                checkOver = (usedSavingsAccountNumbers.Contains(numSavingsAccount) && numSavingsAccount != numCheckingAccount) ? true : false;
            } while (checkOver);

            // Random IBAN number
            checkOver = false;
            long numIBAN = 0;
            do
            {
                numIBAN = random.NextInt64(10000000000000, 99999999999999); // 14 number 
                checkOver = (usedIBANNumbers.Contains(numIBAN)) ? true : false; // If contains numIBAN -> checkOver = true
            } while (checkOver);

            string IBAN = numIBAN.ToString();
            IBAN = "BE" + IBAN;

            // Add all data to the account  
            BankApplication_Personnel.Account account = new BankApplication_Personnel.Account { CheckingAccountNumber = numCheckingAccount, SavingAccountNumber = numSavingsAccount, CheckingAccBalance = 1000, SavingAccBalance = 1000, IBAN = IBAN, Name = name, FirstName = firstName };
            accounts.Add(account);
            return account;
        }
    }
}

namespace BankApplication_Cours
{
    class AccountEventArgs : EventArgs
    {
        public Account Account {get;}
        public AccountEventArgs(Account account) // Constructor, takes one parameter account and assigns it to the field Account
        {
            Account = account;
        } 
    }

    class Bank
    {
        public readonly Dictionary<string, Account> Accounts;
        public required string Name;

        public void AddAccount(Account account)
        {
            Accounts.Add(account.AccNumber, account); 

            // Subscribe to event
            account.NegativeBalanceEvent += NegativeBalanceAction;
        }
    
        public void DeleteAccount(string number)
        {
            Accounts.Remove(number); // remove account by key
        }

        private void NegativeBalanceAction(object sender, EventArgs e)
        {
            Account account = (Account)sender;
            Console.WriteLine($"This account {account.AccNumber} has negative balance.");
        }
    }
}