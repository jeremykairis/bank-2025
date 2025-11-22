class CurrentAccount : Account {
    
    public double CreditLine {
        
        get { return CreditLine; }
        set {
            
            if(value < 0) throw new ArgumentOutOfRangeException("La limite de crédit est inférieur ou égale à 0");
            else CreditLine = value;

        }

    }

    public CurrentAccount(string Number, Person Owner) : base(Number, Owner) {}
    public CurrentAccount(string Number, Person Owner, double Balance) : base(Number, Owner, Balance) {}

    protected override double CalculInterest() {
        
        if(Balance >= 0) return Balance * 0.03;
        else return Balance * 0.0975;

    }

    public override void Withdraw(double amount) {
        
        if(amount <= 0) throw new ArgumentOutOfRangeException("Le montant doit être supérieur à 0");
        else if(Balance - amount < -CreditLine) throw new InsufficientBalanceException("Solde insuffisant");
        else {
            
            bool wasPositive = Balance >= 0;
            Balance -= amount;

            if(wasPositive && Balance < 0) OnNegativeBalance();

        }

    }

}