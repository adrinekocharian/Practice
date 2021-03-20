using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LINQ
{
    public static class LinqExtensions
    {
        public static IEnumerable<ChessPlayer> TopPlayersByRating(this IEnumerable<ChessPlayer> source, int count)
        {
            return source.OrderByDescending(x => x.Rating).Take(count);
        }

        public static IEnumerable<ChessPlayer> Filter(this IEnumerable<ChessPlayer> source, Func<ChessPlayer, bool> predicate)
        {
            //List<ChessPlayer> result = new List<ChessPlayer>();
            foreach (var item in source)
            {
                if (predicate(item))  // item.BirthYear > 1980
                {
                    yield return item;
                    //result.Add(item);
                }
            }
            //return result;
        }

    }
}
