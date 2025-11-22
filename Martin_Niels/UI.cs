using BankApplication_Cours;

// See https://aka.ms/new-console-template for more information

/*
// UI
Console.WriteLine("What is the name of your bank?");
string bankName = Console.ReadLine();
BankApplication_Personnel.Bank account00 = new BankApplication_Personnel.Bank { NameBank = bankName };
Console.WriteLine("What is your name?");
string userName = Console.ReadLine();
Console.WriteLine("What is your first name?");
string userFirstName = Console.ReadLine();
var acc = account00.CreateAccount(userName, userFirstName);

bool running = true;
while (running)
{
    Console.WriteLine("----------------------------------------------------------------------------------------");
    Console.WriteLine("What action do you want to do?\n1) Show account info\n2) Make a transaction\n3) Quitter");
    int action = Int32.Parse(Console.ReadLine());
    Console.WriteLine("----------------------------------------------------------------------------------------");
    switch (action)
    {
        case 1:
            // Show account info
            long totalBalance = acc.SumOfAllAccountsBalance();
            Console.WriteLine($"Name: {acc.Name}\nFirst name: {acc.FirstName}\nChecking account number: {acc.CheckingAccountNumber}\nChecking account balance: {acc.CheckingAccBalance}\nSavings account number: {acc.SavingAccountNumber}\nSavings account balance: {acc.SavingAccBalance}\nIBAN: {acc.IBAN}\nTotal balance: {totalBalance}");
            break;
        case 2:
            // Transaction
            Console.WriteLine("Do you want to deposit or withdraw money?");
            string transact = Console.ReadLine();
            bool a = true;
            if (transact == "deposit")
            {
                a = true;
            }
            else
            {
                a = false;
            }
            Console.WriteLine("With what amount do you want to change your balance?");
            long amount = long.Parse(Console.ReadLine());
            Console.WriteLine("On which account do you want to make the transaction (checkings, savings)?");
            long accType = Int64.Parse(Console.ReadLine());
            acc.Transaction(amount,accType,a);
            // Console.WriteLine($"Balance after transaction: {acc.Balance}");
            break;
        case 3:
            running = false; // Leave terminal
            break;
        default:
            Console.WriteLine("Invalid choice :/");
            break;
    };
}
*/

/*
try
{
    Person person = new Person("Niels", "Martin", new DateTime(2003, 11, 1));
    CurrentAccount currAcc = new CurrentAccount("123", person);
    currAcc.CreditLine = -1;

}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
*/