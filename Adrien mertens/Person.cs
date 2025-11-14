namespace Adrien_mertens;

/// <summary>
/// Représente une personne, propriétaire d'un ou plusieurs comptes bancaires.
/// </summary>
public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime BirthDate { get; set; }

    /// <summary>
    /// Constructeur permettant d'initialiser une personne avec ses informations principales.
    /// </summary>
    /// <param name="firstName">Prénom de la personne.</param>
    /// <param name="lastName">Nom de famille de la personne.</param>
    /// <param name="birthDate">Date de naissance de la personne.</param>
    public Person(string firstName, string lastName, DateTime birthDate)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
    }
}