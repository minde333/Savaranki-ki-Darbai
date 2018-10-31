using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Savarankiškas_darbas
{
    class Footballist : Player
    {
        public int YellowCards { get; set; }
    
        public Footballist(string team, string name, string surname, DateTime birth,
        int amountOfPlayedMatches, int score,
        int yellowCards) : base(team, name, surname, birth, amountOfPlayedMatches, score)
        {
            YellowCards = yellowCards;
        }

        public override string ToString()
        {
            return String.Format("Komanda: {0}, Vardas: {1}, Pavardė: {2}, GimimoData: {3}, ŽaistosRungtynės: {4}, Taškai: {5}, GeltonosKortelės:{6}", Team, Name, Surname, Birth, AmountOfPlayedMatches, Score, YellowCards);
        }
    }
}
