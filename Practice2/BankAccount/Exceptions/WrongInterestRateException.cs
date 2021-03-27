using System;

namespace BankAccount
{
    class WrongIntestRateException : ApplicationException
    {   
        public string CauseOfError { get; set; }
        public DateTime ErrorTimeStamp { get; set; }
        public WrongIntestRateException() {}
        public WrongIntestRateException(string cause, DateTime time)
        : this(cause,time,string.Empty) { }
 
        public WrongIntestRateException(string cause, DateTime time, string message)
        : this(cause,time,message, null) { }
 
        public WrongIntestRateException(string cause, DateTime time, string message, Exception inner)
        : base(message, inner)
        {
          CauseOfError = cause;
          ErrorTimeStamp = time;
        }
    }
}