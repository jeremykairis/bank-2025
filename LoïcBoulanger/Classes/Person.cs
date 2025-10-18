namespace LoïcBoulanger.Classes;

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public string BirthDate { get; set; }

    public Person(string prenom, string nom)
    {
        FirstName = prenom;
        LastName = nom;
        BirthDate = nom;
    }
}

    