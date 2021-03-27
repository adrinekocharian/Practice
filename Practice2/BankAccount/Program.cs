using DepositCalculator;
using System;
using System.Collections;

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DepositAccount depositAccount = new DepositAccount(balance: 1000m, duration: 6);
                depositAccount.DepositPaymenetType = DepositReturnType.Monthly;

                Console.WriteLine("Starting Balance is {0}", depositAccount.Balance);

                // Calculates when pay deposit based on DepositPaymentType using DepositAccount's StartDate and LastPaymentDate properties
                switch (depositAccount.DepositPaymenetType)
                {
                    case DepositReturnType.Monthly:

                        break;
                    case DepositReturnType.Yearly:
                        break;
                    case DepositReturnType.AtTheEnd:
                        break;
                    default:
                        break;
                }

                depositAccount.PayDeposit();

                Console.WriteLine("Balance after getting deposit {0}", depositAccount.Balance);

                BankAccount bankAccount = new BankAccount(1000);
                bankAccount = new BankAccount(1000);
                bankAccount.Deposit(-100);
                bankAccount.Withdraw(10000);
            }
            catch (WrongIntestRateException ex)
            {
                Console.WriteLine($"WrongIntestRateException {ex.StackTrace}");
                Console.WriteLine(ex.CauseOfError);
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.ErrorTimeStamp);
                foreach (DictionaryEntry de in ex.Data)
                {
                    Console.WriteLine($"{de.Key} {de.Value}");
                }
            }
            catch (NegativeWithdrawOrDepositAmountException ex)
            {
                Console.WriteLine($"NegativeWithdrawOrDepositAmountException {ex.StackTrace}");
                Console.WriteLine(ex.CauseOfError);
                Console.WriteLine(ex.Message);
                foreach (DictionaryEntry de in ex.Data)
                {
                    Console.WriteLine($"{de.Key} {de.Value}");
                }
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine($"InsufficientBalanceException {ex.StackTrace}");
                Console.WriteLine(ex.CauseOfError);
                Console.WriteLine(ex.Message);
                foreach (DictionaryEntry de in ex.Data)
                {
                    Console.WriteLine($"{de.Key} {de.Value}");
                }
            }

            Console.ReadLine();
        }
    }
}