/*
Créer une classe "Person" implémentant : 
les propiétés publiques : Nom,Prénom,Anniversaire
*/


// Définition de la classe Person
class Person
{
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public DateTime BirthDate { get; set; }

    public Person(string firstName, string lastName, DateTime birthDate)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
    }

// Surcharge de la méthode ToString pour afficher les informations de la personne
    public override string ToString()
    {
        return $"{FirstName} {LastName}, Born on: {BirthDate:d}";
    }
}

