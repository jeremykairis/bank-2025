using person;
using account;
using bank;

DateTime fedeBirth = new(year:2001,month:9,day:22);
DateTime modeBirth = new(year:1995,month:7,day:14);

var peopleC = new Person("Frederic", "Delvaux", fedeBirth);
var peopleB = new Person("Molie", "Delvaux", modeBirth);

var cAccount1 = new CurrentAccount("1", peopleC, 2000);
var sAccount1 = new SavingsAccount("2", peopleC);
var cAccount2 = new CurrentAccount("3", peopleB, 2000);

try 
{
    cAccount1.Deposit(5000);
    sAccount1.Deposit(23000);
    cAccount2.Deposit(5000);
}
catch (InsufficientBalanceException)
{
    Console.WriteLine("solde inférieur au retrait.");
}
catch (ArgumentOutOfRangeException)
{
    Console.WriteLine("Depot inférieur à zero.");
}


var ifosupBank = new Bank() { Name = "ifosup"};

ifosupBank.AddAccount("0",cAccount1);
cAccount1.ApplyInteret();
ifosupBank.AddAccount("1",sAccount1);
sAccount1.ApplyInteret();
ifosupBank.AddAccount("2",cAccount2);

Console.WriteLine(ifosupBank.GetRegisterOfPersonAccount(peopleC));
Console.WriteLine(ifosupBank.GetRegisterOfPersonAccount(peopleB));