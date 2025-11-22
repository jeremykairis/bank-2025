namespace Loic_Boulanger.Domaine;


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

    // Méthode pour afficher le nom complet de la personne
    public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
}
