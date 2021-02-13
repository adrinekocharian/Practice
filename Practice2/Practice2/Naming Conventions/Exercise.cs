using System;
using System.Collections.Generic;
using System.Text;

namespace Practice2.Naming_Conventions
{
    class Exercise
    {
        public int x = 0;
        public double r = 3;


        // Modify the code to make it more readable.
        public void LetterCount()
        {
            string inputText = "The quick brown fox jumps over the lazy dog.";
            char searchLetter = 'o';

            char[] message = inputText.ToCharArray();
            Array.Reverse(message);
            
            int count = 0;
            foreach (char letter in message) 
            {
                if (letter == searchLetter)
                {
                    count++;
                } 
            }

            Console.WriteLine(message);
            Console.WriteLine($"{searchLetter} appears {count} times.");
        }
    }
}
