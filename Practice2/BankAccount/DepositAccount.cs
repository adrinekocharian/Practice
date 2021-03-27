using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DepositCalculator;

namespace BankAccount
{
    class DepositAccount : BankAccount
    {
        public DateTime StartDate { get; set; }
        public DateTime LastPaymentDate { get; set; }
        public int Duration { get; set; }
        public DepositReturnType DepositPaymenetType { get; set; } = DepositReturnType.AtTheEnd;

        private Calculator depositCalculator;

        /// <summary>
        /// Creates a deposit account.
        /// </summary>
        /// <param name="balance">Currrent balance of the account.</param>
        /// <param name="duration">The duration is in months.</param>
        public DepositAccount(decimal balance, int duration)
        {
            this.Balance = balance;
            this.Duration = duration;
            this.StartDate = DateTime.Now;
            this.LastPaymentDate = this.StartDate;

            this.depositCalculator = new Calculator(this.Duration);
        }

        public void PayDeposit()
        {
            var deposit = this.depositCalculator.Calculate(this.Balance, this.DepositPaymenetType);  // 1000

            decimal tax = CalculateTax(deposit, 10); // 100
            this.Balance += deposit - tax;  //x + 1000 - 100 
        }

        private decimal CalculateTax(decimal income, decimal tax)
        {
            return (income * tax) / 100;
        }

    }
}
