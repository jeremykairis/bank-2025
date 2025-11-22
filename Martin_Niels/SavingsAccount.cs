using BankApplication_Personnel;

namespace BankApplication_Cours
{
    class SavingsAccount : Account
    {
        public SavingsAccount(string AccNumber, Person Owner):base(AccNumber,Owner) {} // Constructeur qui prends le num et le titulaire
        public SavingsAccount(string AccNumber, Person Owner, double Balance) : base(AccNumber, Owner, Balance) { } // Constructeur qui prends num, titulaire et solde
        public DateTime DateLastWithdraw { get; private set; }
        protected override double CalculInterest()  // Need to put protected, bcs if base is protected, override needs to be protected too
                                                    // Public -> Everyone can acces it (any class, any code)
                                                    // Protected -> Only this class and subclasses can acces it
                                                    // Private -> Only class itself can acces it
        {
            return 0.045; // We don't do the calculations here bcs Balance is set on private, do calculations on Account.ApplyInterest()
        }

    }
}