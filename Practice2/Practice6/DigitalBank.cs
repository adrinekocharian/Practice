using System;
using System.Collections.Generic;
using System.Text;

namespace Practice6
{
    public class BankEventArgs : EventArgs
    {
        public decimal Value { get; set; }
    }
    //public delegate void BalanceChanged(decimal change);
    class DigitalBank
    {
        // If we have defined out EventArgs custom class, need to provide it while defining EventHandler
        public event EventHandler<BankEventArgs> BankBalanceChangedEvent;
        public event EventHandler BankBalanceLogger;

        private decimal balance;
        public decimal Balance
        {
            get
            {
                return this.balance;
            }
            set
            {
                if (value < 0m)
                {
                    throw new Exception("Balance cannot be negative.");
                }

                this.balance = value;
                this.BankBalanceChangedEvent(this, new BankEventArgs() { Value = value });
                //this.BankBalanceChangedEvent(this, EventArgs.Empty);
                this.BankBalanceLogger(this, EventArgs.Empty);
                // For invoking an event you can also call Invoke method on a delegate 
                //this.BankBalanceLogger.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
