using System;

namespace BankAccount
{
    class BankAccount
    {
        private static readonly (decimal, decimal) _allowdInterestRateInterval = (0, 22);
        private decimal interestRate;
        public decimal Balance {get; set;}
        public decimal InterestRate
        {
            get => interestRate;
            set
            {
                if (value >= _allowdInterestRateInterval.Item1 && value <= _allowdInterestRateInterval.Item2)
                {
                    interestRate = value;
                }
                else
                {
                    throw new WrongIntestRateException("Interest rate you provided is not allowed", DateTime.Now, "Please provide more reasonable interest rate")
                    {
                        Data =
                        {
                            {"Provided interest rate: ", $"{value}"},
                            {"Acceptable interest rate: ", $"[{_allowdInterestRateInterval.Item1}  {_allowdInterestRateInterval.Item2}]"},
                        }
                    };
                }
            }
        }
        public BankAccount() { }
        public BankAccount(decimal balance)
        {
            //InterestRate = interestRate;
            this.Balance = balance;
        }
        public void Deposit(decimal depositAmount)
        {
            if (depositAmount <= 0 )
            {
                throw new NegativeWithdrawOrDepositAmountException("You cannot deposit non-positive amount", "Please provide positive deposit amount")
                {
                    Data =
                    {
                        {"Provided deposit amount: ", $"{depositAmount}"},
                        {"Date: ", $"{DateTime.Now}"}
                    }
                };
            }
            else
            {
                this.Balance += depositAmount;
            }
        }
        public void Withdraw(decimal withdrawAmount)
        {
            if (withdrawAmount <= 0 )
            {
                throw new NegativeWithdrawOrDepositAmountException("You cannot withdraw non-positive amount", "Please provide positive withdraw amount")
                {
                    Data =
                    {
                        {"Provided deposit amount: ", $"{withdrawAmount}"},
                        {"Date: ", $"{DateTime.Now}"}
                    }
                };
            }
            else if (withdrawAmount > Balance)
            {
                throw new InsufficientBalanceException("Your current balance is not sufficient fot this withdrawal", "Please reconsider your expenses")
                {
                    Data = 
                    {
                        {"Current Balance: ", Balance},
                        {"Withdraw amount: ", withdrawAmount}
                    }
                };
            }
            else
            {
                this.Balance -= withdrawAmount;
            }
        }
    }
}