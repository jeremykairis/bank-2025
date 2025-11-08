using System;

namespace Loic_Boulanger.Domaine
{
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException() { }

        public InsufficientBalanceException(string message)
            : base(message) { }

        public InsufficientBalanceException(string message, Exception inner)
            : base(message, inner) { }
    }
}