using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Savarankiškas_darbas
{
    class Basketballist : Player
    {
        public int Rebounds { get; set;}
        public int EffectiveTransfers { get; set; }

        public Basketballist(string team, string name, string surname, DateTime birth, 
        int amountOfPlayedMatches, int score, 
        int rebounds, int effectiveTransfers) :base(team, name, surname, birth,amountOfPlayedMatches,score)
        {
            Rebounds = rebounds;
            EffectiveTransfers = effectiveTransfers;
        }

        public override string ToString()
        {
            return String.Format("Komanda: {0}, Vardas: {1}, Pavardė: {2}, GimimoData: {3}, ŽaistosRungtynės: {4}, Taškai: {5}, Atkovojimai: {6}, RezultatyvūsPerdavimai: {7}", Team, Name, Surname, Birth, AmountOfPlayedMatches, Score, Rebounds, EffectiveTransfers);
        }

    }
}
