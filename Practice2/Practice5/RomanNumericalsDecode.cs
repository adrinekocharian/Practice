using System;
using System.Collections.Generic;
using System.Text;

namespace Practice5
{
    public class RomanNumericalsDecode
    {
        static Dictionary<char, short> RomanNumnbers = new Dictionary<char, short>()
        {
            ['I'] = 1,
            ['V'] = 5,
            ['X'] = 10,
            ['L'] = 50,
            ['C'] = 100,
            ['D'] = 500,
            ['M'] = 1000
        };
                                                                    
        public static int Decode(string input) // "XVI" "IV", "IX", 'XI', "MCMXC" "VIII" "MMVIII"
        {
            int number = 0;
            if (input.Length > 2)
            {
                if (RomanNumnbers.ContainsKey(input[0]))
                {
                    number += RomanNumnbers[input[0]];
                }
                
                for (int i = 2; i < input.Length; i++)
                {
                    if (RomanNumnbers[input[i - 1]] >= RomanNumnbers[input[i]])
                    {
                        number += RomanNumnbers[input[i - 1]];
                    }
                    else
                    {
                        number -= RomanNumnbers[input[i - 1]];                       
                    }
                }
                number += RomanNumnbers[input[input.Length - 1]];
            }
            else
            {
                if (RomanNumnbers[input[0]] > RomanNumnbers[input[1]])
                {
                    number = RomanNumnbers[input[0]] + RomanNumnbers[input[1]];
                }
                else
                {
                    number = RomanNumnbers[input[1]] - RomanNumnbers[input[0]];
                }
            }

            return number;
        }
    }
}
