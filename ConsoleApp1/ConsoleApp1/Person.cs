using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Person
    {
        private DateTime birthDate;
        private string firstName;
        private string lastName;

        public Person(string firstName, string lastName, DateTime birthDate)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthDate = birthDate;
        }
        
        
        public string GetFirstName() {
            return this.firstName;
        }
        public void GetFirstName(string firstName) { 
            this.firstName = firstName;
        }

        public string GetLastName() { 
            return this.lastName; 
        }
        public void SetLastName(string lastName)
        {
            this.lastName = lastName;
        }

        public DateTime GetBirthDate()
        {
            return this.birthDate;
        }
        public void SetBirthDate(DateTime birthDate) { 
            this.birthDate = birthDate;
        }

        override
        public string ToString()
        {
            return $"{this.firstName} {this.lastName}";
        }
    }
}
