using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class CurrentAccount
    {
        private string number;
        private double balance;
        private double creditLine;
        private Person owner;

        public CurrentAccount(string number, double balance, double creditLine, Person owner)
        {
            this.number = number;
            this.balance = balance;
            this.creditLine = creditLine;
            this.owner = owner;
        }

        public void WithDraw(double amount) {
            this.balance -= amount;
        }

        public void Deposit(double amount) {  
            this.balance += amount; 
        }

        public string GetNumber()
        {
            return this.number;
        }

        public double GetBalance() {
            return this.balance;
        }

        public double GetCreditLine()
        {
            return this.creditLine;
        }

        public void SetCreditLine(double creditLine)
        {
            this.creditLine = creditLine;
        }

        public Person GetOwner() { 
            return owner;
        }
    }
}
