using System;
using System.Collections.Generic;
using System.Text;

namespace Practice6
{
    class Program
    {
        public static void Main(string[] args)
        {
            DigitalBank bank = new DigitalBank();

            bank.BankBalanceChangedEvent += Bank_BankBalanceChangedEvent;
            //bank.BankBalanceLogger += Bank_BankLogger;
            bank.BankBalanceLogger += (sender, e) => Console.WriteLine($"***** Balance is changed. ***** \n {sender.GetType()}"); 

            string text;
            do
            {
                Console.WriteLine("Please enter the amount you want to add or subtract.");
                text = Console.ReadLine();
                if (!text.Equals("exit"))
                {
                    try
                    {
                        int input = int.Parse(text);
                        bank.Balance += input; // bank.balance + input
                        Console.WriteLine($"Current balance is {bank.Balance}");
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine($"An {ex.Message} exception occured.\n Please enter a valid value.");
                    }
                }
            }
            while (!text.Equals("exit"));

            Console.ReadLine();
        }

        private static void Bank_BankLogger(object sender, EventArgs e)
        {
            Console.WriteLine("***** Balance is changed. *****");
        }

        private static void Bank_BankBalanceChangedEvent(object sender, BankEventArgs e)
        {
            if (e.Value > 1000m)
            {
                Console.WriteLine("Maximum amount is reached!!!");
            }
        }

        //private static void BankBalanceChangedEventHandler(object sender, EventArgs args)
        //{
        //    if (args.Value > 1000)
        //    {
        //        Console.WriteLine("Maximum amount is reached!");
        //    }
        //}
    }
}
