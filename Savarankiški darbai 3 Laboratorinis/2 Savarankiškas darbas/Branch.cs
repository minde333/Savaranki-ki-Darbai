using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Savarankiškas_darbas
{
    class Branch
    {
        public string Team { get; set; }
        public string City { get; set; }
        public string Coach { get; set; }
        public int AmountOfPlayedMatches { get; set; }

        public PlayersContainer Basketballists { get; set; }
        public PlayersContainer Footballists { get; set; }

        public Branch(string team, string city, string coach, int amountOfPlayedMatches)
        {
            Team = team;
            City = city;
            Coach = coach;
            AmountOfPlayedMatches = amountOfPlayedMatches;
            Basketballists = new PlayersContainer();
            Footballists = new PlayersContainer();
        }

        public void AddBasketballist(Basketballist basketballist)
        {
            Basketballists.AddPlayer(basketballist);
        }
        public void AddFootballist(Footballist footballist)
        {
            Footballists.AddPlayer(footballist);
        }



    }
}
