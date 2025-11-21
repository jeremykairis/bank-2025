class SavingsAccount : Account {
    
    public DateTime DateLastWithdraw { get; private set; }

    public SavingsAccount(string Number, Person Owner) : base(Number, Owner) {}
    public SavingsAccount(string Number, Person Owner, double Balance) : base(Number, Owner, Balance) {}

    protected override double CalculInterest() { return Balance * 0.045; }
    public override void Withdraw(double amount) {
        base.Withdraw(amount);
        DateLastWithdraw = DateTime.Now;
    }

}