using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Savarankiškas_darbas
{
    abstract class Player
    {
        public string Team { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime Birth { get; set; }
        public int AmountOfPlayedMatches { get; set; }
        public int Score { get; set; }

        public Player(string team, string name, string surname, DateTime birth, int amountOfPlayedMatches, int score)
        {
            Team = team;
            Name = name;
            Surname = surname;
            Birth = birth;
            AmountOfPlayedMatches = amountOfPlayedMatches;
            Score = score;
        }


    }
}
