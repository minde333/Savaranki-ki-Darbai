using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Savarankiškas_darbas
{
    class PlayersContainer
    {
        public const int maxAmountOfPlayers = 1000;
        public Player[] players;
        public int Count { get; private set; }
        public PlayersContainer()
        {
            players = new Player[maxAmountOfPlayers];
        }
        public void AddPlayer(Player player)
        {
            players[Count] = player;
            Count++;
        }
        public Player GetPlayer(int index)
        {
            return players[index];
        }
        public double Average()
        {
            double number = 0;
            for (int i = 0; i < Count; i++)
            {
                number = number + GetPlayer(i).Score;
            }
            return number / Count;
        }



    }
}
