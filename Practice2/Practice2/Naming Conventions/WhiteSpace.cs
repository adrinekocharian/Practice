using System;
using System.Collections.Generic;
using System.Text;

namespace Practice2.Naming_Conventions
{
    class Whitespace
    {
        public void Method1()
        {
            int x = 9;Console.WriteLine(x + 100);Console.ReadLine();
            // Example 1:
            Console
            .
            WriteLine
            (
            "Hello World!"
            )
            ;

            // Example 2:
            string firstWord = "Hello"; string lastWord = "World"; Console.WriteLine(firstWord + " " + lastWord + "!");
        }

        /// <summary>
        /// 
        /// </summary>
        public void RollingDice()
        {
            Random dice = new Random();

            int roll1 = dice.Next(1, 7);
            int roll2 = dice.Next(1, 7);
            int roll3 = dice.Next(1, 7);
            
            int total = roll1 + roll2 + roll3;            
            Console.WriteLine($"Dice roll: {roll1} + {roll2} + {roll3} = {total}");

            if ((roll1 == roll2) || (roll2 == roll3) || (roll1 == roll3))
            {
                if ((roll1 == roll2) && (roll2 == roll3)) 
                {
                    Console.WriteLine("You rolled triples!  +6 bonus to total!");
                    total += 6;
                } 
                else 
                {
                    Console.WriteLine("You rolled doubles!  +2 bonus to total!");
                    total += 2;
                }
            }
        }
    }
}
