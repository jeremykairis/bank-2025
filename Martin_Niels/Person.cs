namespace BankApplication_Cours
{
    public class Person
    {
        public Person(string firstName, string lastName, DateTime birthDate) { FirstName = firstName; LastName = lastName; BirthDate = birthDate; }
        public  string FirstName { get; private set; }
        public string LastName { get; private set; }
        public  DateTime BirthDate { get; private set; }
    }
}