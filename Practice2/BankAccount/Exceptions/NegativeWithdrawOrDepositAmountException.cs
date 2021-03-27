using System;

namespace BankAccount
{
    class NegativeWithdrawOrDepositAmountException : ApplicationException
    {   
        public string CauseOfError { get; set; }
        public NegativeWithdrawOrDepositAmountException() {}
        public NegativeWithdrawOrDepositAmountException(string cause, string message)
        : this(cause, message, null) { }
 
        public NegativeWithdrawOrDepositAmountException(string cause, string message, Exception inner)
        : base(message, inner)
        {
          CauseOfError = cause;
        }
    }
}