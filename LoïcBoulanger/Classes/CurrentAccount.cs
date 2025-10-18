namespace LoïcBoulanger.Classes;

public class CurrentAccount
{
    public string Number { get; set; }
    public double Balance { get; }
    public double creditsLine {get; set;}
    Person Owner { get; set; }

    public void WithDraw(double amount)
    {
        }

    public void Deposit(double amount)
    {
        }
}