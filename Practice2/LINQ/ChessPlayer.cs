using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace LINQ
{
    public class ChessPlayer
    {
        private int birthYear;
        public int BirthYear
        {
            get
            {
                //Console.WriteLine(birthYear);
                return this.birthYear;
            }

            set
            {
                this.birthYear = value;
            }
        }


        public string LastName { get; set; }

        public string FirstName { get; set; }

        public int Rating { get; set; }

        public string Country { get; set; }

        public int Id { get; set; }

        public override string ToString()
        {
            return $"Full Name: {FirstName + " " + LastName}, Rating = {Rating}, from {Country}, Born in {BirthYear}";
        }

        public static IEnumerable<ChessPlayer> GetChessPlayersList()
        {
            return new List<ChessPlayer>()
            {
                new ChessPlayer()
                {
                    Id = 1,
                    BirthYear = 1990,
                    FirstName = "Magnus",
                    LastName = "Carlsen",
                    Rating = 2862,
                    Country = "NOR"
                },
                new ChessPlayer()
                {
                    Id = 2,
                    BirthYear = 1992,
                    FirstName = "Fabiano",
                    LastName = "Caruana",
                    Rating = 2823,
                    Country = "USA"
                },
                new ChessPlayer()
                {
                    Id = 3,
                    BirthYear = 1985,
                    FirstName = "Shakhriyar",
                    LastName = "Mamedyarov",
                    Rating = 2770,
                    Country = "AZE"
                },
                new ChessPlayer()
                {
                    Id = 4,
                    BirthYear = 1992,
                    FirstName = "Liren",
                    LastName = "Ding",
                    Rating = 2791,
                    Country = "CHN"
                },
                new ChessPlayer()
                {
                    Id = 5,
                    BirthYear = 1994,
                    FirstName = "Anish",
                    LastName = "Giri",
                    Rating = 2764,
                    Country = "NED"
                },
                new ChessPlayer()
                {
                    Id = 6,
                    BirthYear = 1993,
                    FirstName = "Wesley",
                    LastName = "So",
                    Rating = 2770,
                    Country = "USA"
                },
                new ChessPlayer()
                {
                    Id = 7,
                    BirthYear = 1975,
                    FirstName = "Vladimir",
                    LastName = "Kramnik",
                    Rating = 2753,
                    Country = "RUS"
                },
                new ChessPlayer()
                {
                    Id = 8,
                    BirthYear = 1990,
                    FirstName = "Maxime",
                    LastName = "Vachier-Lagrave",
                    Rating = 2784,
                    Country = "FRA"
                },
                new ChessPlayer()
                {
                    Id = 9,
                    BirthYear = 1987,
                    FirstName = "Hikaru",
                    LastName = "Nakamura",
                    Rating = 2736,
                    Country = "USA"
                },
                new ChessPlayer()
                {
                    Id = 10,
                    BirthYear = 1990,
                    FirstName = "Sergey",
                    LastName = "Karjakin",
                    Rating = 2789,
                    Country = "RUS"
                },
                new ChessPlayer()
                {
                    Id = 11,
                    BirthYear = 1990,
                    FirstName = "Ian",
                    LastName = "Nepomniachtchi",
                    Rating = 2789,
                    Country = "RUS"
                },
                new ChessPlayer()
                {
                    Id = 12,
                    BirthYear = 1969,
                    FirstName = "Anand",
                    LastName = "Viswanathan",
                    Rating = 2753,
                    Country = "IND"
                },
                new ChessPlayer()
                {
                    Id = 13,
                    BirthYear = 1982,
                    FirstName = "Levon",
                    LastName = "Aronian",
                    Rating = 2781,
                    Country = "ARM"
                },
            };
        }
    }

    //TODO Define when two chess players are equal
    public class ChessPlayerComparer : IEqualityComparer<ChessPlayer>
    {
        public bool Equals([AllowNull] ChessPlayer x, [AllowNull] ChessPlayer y)
        {
            throw new NotImplementedException();
        }

        public int GetHashCode([DisallowNull] ChessPlayer obj)
        {
            throw new NotImplementedException();
        }
    }
}