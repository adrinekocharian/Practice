using System;
using System.Collections.Generic;
using System.Text;

namespace DepositCalculator
{
    public class Calculator
    {
        // Duration is defined in months
        public int DepositDuration { get; set; } 
        public decimal InterestRate { get; set; }

        public Calculator(int duration)
        {
            this.DepositDuration = duration;
            this.InterestRate = GetInterestRate(duration);
        }

        public decimal Calculate(decimal currentBalance, DepositReturnType type)
        {
            var yearlyDeposit = currentBalance * this.InterestRate / 100;
            decimal deposit = 0m;
            switch (type)
            {
                case DepositReturnType.Monthly:
                    deposit = yearlyDeposit / 12;
                    break;
                case DepositReturnType.Yearly:
                    deposit = yearlyDeposit;
                    break;
                case DepositReturnType.AtTheEnd:
                    deposit = yearlyDeposit / 12 * this.DepositDuration;
                    break;
                default:
                    break;
            }

            return deposit;
        }


        // [0 - 6] - 9%
        // [6 - 12] - 10%
        // [12 - 15] - 12%
        public decimal GetInterestRate(int duration)
        {
            decimal interestRate = 0m;

            if (duration > 0 && duration <= 6)
                interestRate = 9m;
            if (duration > 6 && duration <= 12)
                interestRate = 10m;
            if (duration > 12 && duration < 15)
                interestRate = 12m;

            return interestRate;
        }
    }
}
