using System;
using System.Collections.Generic;
using System.Text;

namespace LINQ
{
    public static class Football
    {
        public static void FootballPlayers()
        {
            List<Team> teams = new List<Team>()
            {
                new Team { Name = "Bavaria", Country ="Germany" },
                new Team { Name = "Barcelona", Country ="Spain" },
                new Team() {Name="Juventus", Country = "Italy"}
            };

            List<Player> players = new List<Player>()
            {
                new Player {Name="Messy", Team="Barcelona"},
                new Player {Name="Neimar", Team="Barcelona"},
                new Player {Name="Robben", Team="Bavaria"},
                new Player {Name="Buffon", Team="Juventus"}
            };

            //TODO Football 
            //Return all players from each football club.
        }
    }

    public class Team
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }

    public class Player
    {
        public string Name { get; set; }
        public string Team { get; set; }
    }
}
