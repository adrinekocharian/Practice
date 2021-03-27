using System;

namespace BankAccount
{
    class InsufficientBalanceException : ApplicationException
    {   
        public string CauseOfError { get; set; }
        public InsufficientBalanceException() {}
 
        public InsufficientBalanceException(string cause, string message)
        : this(cause, message, null) { }
 
        public InsufficientBalanceException(string cause, string message, Exception inner)
        : base(message, inner)
        {
          CauseOfError = cause;
        }
    }
}