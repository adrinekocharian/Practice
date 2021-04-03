using System;
using System.Collections.Generic;
using System.Linq;

namespace Practice7
{
    class Program
    {
        static void Main(string[] args)
        {
            Reflection.Test();

            Lesson l = new Lesson();

            var apList = new List<Airport> { new Airport("Charles de Gaulle", "33", AirportSizes.SuperMega)
                                      , new Airport("Gyumri", "374", AirportSizes.Small)
                                      , new Airport("Zvartnots", "374", AirportSizes.Medium)
                                      , new Airport("LAX", "500", AirportSizes.Mega)
            };


            var orderedList = apList.OrderBy(a => Enum.Parse<AirportSizes>(a.SizeName)).Select(a => new { a.Name, a.CountryCode, a.SizeName });
            var orderedList2 = apList.OrderBy(a => a.Size).Select(a => new { a.Name, a.CountryCode, a.SizeName });
            apList.Sort(new AirportComparer());

            foreach (var item in orderedList2)
                Console.WriteLine(item.Name);
        }
    }
}