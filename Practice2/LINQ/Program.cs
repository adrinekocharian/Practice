using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var phoneNumbers = PersonPhoneNumbers.GetPhoneNumbers();

            foreach (var item in phoneNumbers)
            {
                Console.WriteLine(item);
            }

            List<int> numbers = new List<int> {1, 2, 3, 4, 5, 6, 7 };
            IEnumerable<int> evenNumbers1 = numbers.Where(x => x % 2 == 0);
            IEnumerable<int> evenNumbers = numbers.Where(x => x % 2 == 0).ToList();

            numbers.Add(8);
            numbers.Add(9);

            //foreach (var item in evenNumbers)
            //{
            //    Console.WriteLine(item);
            //}

            //RemoveElementsFromList();
            //IntersectExceptExample();

            IEnumerable<ChessPlayer> players = ChessPlayer.GetChessPlayersList();
 
            var topFivePlayers = players.OrderByDescending(x => x.Rating)
                                    .ThenBy(x=>x.FirstName)
                                    .Take(5);

            var topPlayers = players.TopPlayersByRating(5);

            Console.WriteLine("    Start where");
            var filtered = players.Where(x => x.BirthYear > 1980);

            Console.WriteLine("    End where");

            Console.WriteLine("    Start filter");
            var filtered2 = players.Filter(x => x.BirthYear > 1980);
            players.First().BirthYear = 1000;

            //Console.WriteLine("*******Where*********");
            //foreach (var item in filtered)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine();
            Console.WriteLine("****Filter******");
            foreach (var item in filtered2)
            {
                Console.WriteLine(item);
            }

            //Projection(players);
            //FilteringPlayers(players);

            //AnyAllContains(players);
            Console.ReadLine();
        }

        #region Methods
        public static void GeneratingDataStreams()
        {
            Console.WriteLine("Generating range");  // 1 2 5 4 7
            //TODO

            Console.WriteLine("\nRepeating:"); // 5 5 5
            //TODO

            Console.WriteLine("\nRandom stream");
            //TODO
        }

        public static void RemoveElementsFromList()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };

            //IEnumerator<int> enumerator = numbers.GetEnumerator();
            //while(enumerator.MoveNext())
            //{
            //    int item = enumerator.Current;
            //    if (item % 2 == 0)
            //    {
            //        numbers.Remove(item);
            //    }
            //    Console.WriteLine(item);
            //}

            //foreach (int num in numbers)
            //{
            //    if (num % 2 == 0)
            //    {
            //        numbers.Remove(num);
            //    }
            //}


            for (int i = 0; i < numbers.Count; i++)
            {
                if (numbers[i] > 7)
                {
                    numbers.Remove(numbers[i]);
                    i--;
                }
            }

            int removedElements = numbers.RemoveAll(x => x % 2 == 0);

            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }

        }

        public static void IntersectExceptExample()
        {
            var products1 = new List<string>() { "milk", "butter", "soda" };
            var products2 = new List<string>() { "coffee", "Butter", "milk", "pizza" };

            IEnumerable<string> intersection = products1.Intersect(products2, new ProductEqComparer());
            foreach (var item in intersection)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("*******");
            var except = products1.Except(products2, new ProductEqComparer());
            foreach (var item in except)
            {
                Console.WriteLine(item);
            }
        }

        public static void Projection(IEnumerable<ChessPlayer> players)
        {
            // get rankings from players list
            var ratings = players.Select(x => x.Rating);

            // get last names of the chess players
            var lastNames = players.Select(player => player.LastName);

            // get full name of the chess players
            var fullNames = players.Select(p => p.FirstName + " " + p.LastName);

            List<ChessPlayer> listOfPlayers = players.ToList();
            ChessPlayer[] arrOfPlayers = players.ToArray();
            listOfPlayers.Add(new ChessPlayer() { Id = 14, FirstName = "A", LastName = "AA" });
            Dictionary<int, ChessPlayer> dictionaryOfPlayers = players.ToDictionary(k => k.Id);
            ILookup<string, ChessPlayer> lookupOfPlayers = players.ToLookup(p => p.Country);

            IEnumerable<ChessPlayer> country = lookupOfPlayers["USA"];
            foreach (var playerGroup in lookupOfPlayers)
            {
                Console.WriteLine(playerGroup.Key);
                foreach (var player in playerGroup)
                {
                    
                }
            }

            foreach (var item in fullNames)
            {
                Console.WriteLine(item);
            }
        }

        public static void AnyAllContains(IEnumerable<ChessPlayer> players)
        {
            if (players == null) throw new ArgumentNullException();

            List<ChessPlayer> players2 = null;
            List<int> numbers = new List<int>();

            if (players2 != null && players2.Any()/*players2.Count > 0*/)
            {
                var first = players2.First();
            }

            int? first1 = numbers?.FirstOrDefault();
            /* 
             * List<int> numbers = new List<int>();
             * ?.     Nullable<T>  default(Nullable<T>)
             *  .FirstOrdefault()   default(T)
             * */

            if (first1 == null)
            {
                //
            }
            var first2 = players.Last(x => x.Country == "RUS");

            var first3 = players2?.LastOrDefault();

            
            var single = players.Single(x => x.Id == 10);
            var single1 = players.SingleOrDefault(x=>x.Id == 1);

            var all = players.All(x => x.Rating > 2780);
            var any = players.Any(x => x.Rating > 2900);

            ChessPlayer otherPlayer = new ChessPlayer()
                                    {
                                        Id = 1,
                                        BirthYear = 1990,
                                        FirstName = "Magnus",
                                        LastName = "Carlsen",
                                        Rating = 2862,
                                        Country = "NOR"
                                    };
            bool contains = players.Contains(otherPlayer, new ChessPlayerComparer());
        }

        public static void FilteringPlayers(IEnumerable<ChessPlayer> players)
        {
            // Get all players from chess players list which are from "USA" 
            // Get all players from ches players list whose ranking is more than 2780
            var groupedPlayers = players.Where(x => x.BirthYear > 1987).GroupBy(x => x.Country);
            var groupedPlayers3 = players.Where(x => x.Country == "USA").GroupBy(x => x.BirthYear);
            var orderedPlayers = players.Where(x => x.BirthYear > 1987).GroupBy(x => x.Country).OrderBy(x => x.Key);
            var orderedPlayers2 = players.Where(x => x.BirthYear > 1987).OrderBy(x => x.FirstName).GroupBy(x => x.Country);

            var groupedPlayers2 = players.GroupBy(x => x.Country).Where(x => x.Key == "ARM");


            foreach (IGrouping<string, ChessPlayer> playerGroup in groupedPlayers)
            {
                Console.WriteLine($"Players from {playerGroup.Key}");
                foreach (var player in playerGroup)
                {
                    Console.WriteLine($"\t{player}");
                }

            }
            // Return all players for each country who have been born after 1987.
            // Ordered by country name
            // Ordered by country and ranking
            var orderedPlayers3 = players.Where(x => x.BirthYear > 1987).OrderBy(x => x.Country).ThenBy(x => x.Rating).ThenByDescending(x=>x.FirstName);
            var orderedPlayers4 = players.Where(x => x.BirthYear < 1987).OrderBy(x => x.Country).ThenByDescending(x => x.Rating);
        }

        public static void ChessPlayersAndTournament()
        {
            //TODO Join
            // Տպել յուրաքանչյուր մրցաշարի հաղթող խաղացողի տվյալները
            // Տպել յուրաքանչյուր մրցաշարի հաղթողների երկրները
            // Տպել մրցաշարերում հաղթող երկրների քանակը - USA - 2; RUS - 3
            // Տպել մրցաշարերում մասնակից երկրները 

        }
        #endregion
    }

    public class ProductEqComparer : IEqualityComparer<string>
    {
        public bool Equals([AllowNull] string x, [AllowNull] string y)
        {
            return string.Equals(x.ToUpper(), y.ToUpper());
            //return string.Equals(x, y, StringComparison.OrdinalIgnoreCase);
        }

        public int GetHashCode([DisallowNull] string obj)
        {
            return obj.ToUpper().GetHashCode();
        }
    }
}
