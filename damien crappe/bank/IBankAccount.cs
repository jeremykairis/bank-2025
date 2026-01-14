internal interface IBankAccount : IAccount
{
    Person Owner { get;}
    void ApplyInterest();
}
