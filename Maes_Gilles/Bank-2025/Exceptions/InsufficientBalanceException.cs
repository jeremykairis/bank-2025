public class InsufficientBalanceException : Exception {
    
    public InsufficientBalanceException() : base() {}

    public InsufficientBalanceException(string message) : base(message) {}

}