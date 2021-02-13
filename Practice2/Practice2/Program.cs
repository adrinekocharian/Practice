using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practice2
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "C:/Desktop/UserName/samples";
            string fileExt = GetFileExtension(input);
            Console.WriteLine(string.IsNullOrEmpty(fileExt) ? "No extension" : fileExt);

            string textToSplit = "rWWWYcc21113++%%)";
            Console.WriteLine($"Split {textToSplit} based on change of characters");
            SplitText(textToSplit);

            string inputText = "Hello World";
            Console.WriteLine($"Letters frequency of \"{inputText}\" text.");
            LettersFrequency(inputText);

            string withoutVowels = RemoveVowels(inputText);
            Console.WriteLine($"{inputText} text without vowels is {withoutVowels}.");

            Console.ReadLine();
        }

        // [A-Z][a-z][0-9]
        // photoes.zip
        /// <summary>
        /// Get the extension from a given filename.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        static string GetFileExtension(string filename)
        {
            string ext = string.Empty;
            for (int i = filename.Length - 1; i >= 0; i--)
            {
                if (filename[i] == '.')
                {
                    ext = filename.Substring(i + 1);
                    break;
                }
            }

            // Check extension rules
            string extUppercase = ext.ToUpper();


            foreach (char item in ext)
            {
                if (char.IsLetterOrDigit(item))
                {

                }

            }
            for (int i = 0; i < ext.Length; i++)
            {
                if (extUppercase[i] >= 0 && extUppercase[i] <= 9)
                    continue;
                if (extUppercase[i] >= 'A' && extUppercase[i] <= 'Z')
                    continue;

                return string.Empty;
            }

            return ext;
        }

        /// <summary>
        /// Remove Vowels from a given input string.
        /// </summary>
        /// <param name="input"></param>
        /// <returns>Returns a text without vowels.</returns>
        static string RemoveVowels(string input)
        {
            StringBuilder result = new StringBuilder();
            foreach (var item in input)
            {
                if (!IsVowel(item))
                {
                    result.Append(item);
                }
            }
            return result.ToString();
        }

        static bool IsVowel(char letter)
        {
            if (letter == 'a' || letter == 'e' || 
                letter == 'o' || letter == 'i' || 
                letter == 'u')
            {
                return true;
            }
            return false;

            // Another option.
            //return letter == 'a' || letter == 'e' || letter == 'o' || letter == 'i' || letter == 'u';

            // Using switch expression
            //bool isVowel = letter switch
            //{
            //    'a' => true,
            //    'e' => true,
            //    _ => false
            //};
            //return isVowel;
        }

        /* "Hello world"
            H - 1
            e - 1
            l - 3
            o - 2 
            r - 1
            d - 1
         * */
        /// <summary>
        /// Print the letters with their frequencies in an input.
        /// </summary>
        /// <param name="input"></param>
        static void LettersFrequency(string input)
        {
            Dictionary<char, int> keyValuePairs = new Dictionary<char, int>();
            List<int> list = new List<int>();
            foreach (char item in input)
            {
                if (!keyValuePairs.ContainsKey(item))
                {
                    keyValuePairs.Add(item, 1);
                }
                else
                {
                    keyValuePairs[item]++;
                }
            }
            foreach (var item in keyValuePairs)
            {
                Console.WriteLine($"{item.Key.ToString()} - {item.Value}");
            }
        }

        /// <summary>
        /// Split text based on a character change.
        /// </summary>
        /// <param name="input"></param>
        static void SplitText(string input)
        {
            //List<string> splittedString = new List<string>();
            //splittedString.Add(input[0].ToString());

            string result = input[0].ToString();
            // Another option
            //string result = input.ElementAt(0).ToString(); 
            
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i] != input[i - 1])
                {
                    result += " " + input[i];
                }
                else
                {
                    result += input[i];
                }
            }
            //foreach (var item in splittedString)
            //{
            //    Console.WriteLine(item);
            //}
            Console.WriteLine(result);
        }

        /// <summary>
        /// Check if given year is a leap year.
        /// </summary>
        /// <returns>Returns true if year is a leap year</returns>
        static bool IsLeapYear(int year)
        {
            return DateTime.IsLeapYear(year);
        }
    }
}
