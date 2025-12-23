namespace BankApplication_Cours
{
    class CurrentAccount : Account
    {
        private double creditLine; // field
        public CurrentAccount(string AccNumber, Person Owner) : base(AccNumber, Owner) { }
        public CurrentAccount(string AccNumber, Person Owner, double Balance) : base(AccNumber, Owner, Balance) { }
        public double CreditLine // property, combination of variable and method
        {
            get => creditLine; // get -> returns the value of the variable creditLine
            // set -> assigns a value to the variable creditLine
            // If we want to calculate with "creditline" -> use the property (not the field) or this will bypass the validation
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(CreditLine), "CreditLine has to be over 0.");
                }
                creditLine = value;
            }
        }
        protected override double CalculInterest()
        {
            if (Balance > 0)
            {
                return 0.03; // 3%
            }
            else
            {
                return 0.0975; // 9.75%
            }

        }

        // Déclencher l'événement quand le compte passe en dessous de 0.
        // Mettre ici pcq spécifique au compte !actuelle!
        public override void Withdraw(double amount)
        {
            base.Withdraw(amount);

            if (Balance < 0)
            {
                OnNegativeBalance();  
            }
        }
    }
}