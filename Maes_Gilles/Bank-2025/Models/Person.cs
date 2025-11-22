public class Person {

    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public DateTime BirthDate { get; private set; }

    public Person(string FirstName, string LastName, DateTime BirthDate) {
        
        this.FirstName = FirstName;
        this.LastName = LastName;
        this.BirthDate = BirthDate;

    }

}

