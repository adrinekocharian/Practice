using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine();
        }

        #region Methods
        public static void GeneratingDataStreams()
        {
            Console.WriteLine("Generating range");
            //TODO

            Console.WriteLine("\nRepeating:");
            //TODO

            Console.WriteLine("\nRandom stream");
            //TODO
        }

        public static void RemoveElementsFromList()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
            //TODO

        }

        public static void IntersectExceptExample()
        {
            var products1 = new List<string>() { "milk", "butter", "soda" };
            var products2 = new List<string>() { "coffee", "Butter", "milk", "pizza" };

            //TODO
        }

        public static void Projection(IEnumerable<ChessPlayer> players)
        {
            //TODO
            // get rankings from players list
            // get last names of the chess players
            // get full name of the chess players

        }

        public static void Filtering(IEnumerable<ChessPlayer> players)
        {
            //TODO
            // Get all players from chess players list which are from "USA" 
            // Get all players from ches players list whose ranking is more than 2780
            //
        }

        public static void Players()
        {
            //TODO
            // Return all players for each country who have been born after 1988.
            // Ordered by country name
            // Ordered by country and ranking
        }
        #endregion
    }
}
