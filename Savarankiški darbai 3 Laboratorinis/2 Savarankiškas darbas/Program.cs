using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Savarankiškas_darbas
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Program p = new Program();
            BranchesContainer branches = new BranchesContainer();
            PlayersContainer football = new PlayersContainer();
            PlayersContainer basketball = new PlayersContainer();
            p.ReadBranchData(branches);
            p.ReadPlayersData("Krepšininkai.csv", basketball);
            p.ReadPlayersData("Futbolininkai.csv", football);
            p.BranchAdded(branches, basketball, football);

            string city;
            Console.WriteLine("Įveskite miestą:");
            city = Console.ReadLine();

            PlayersContainer filteredPlayers = new PlayersContainer();
            int Count = 0;


            Console.WriteLine("Krepšinio komandos ir jų žaidėjai:");
            for (int i = 0; i < branches.Count; i++)
            {
                filteredPlayers = p.FilteredBasketballists(branches, city);

                if (filteredPlayers.Count > 0)
                {
                    p.PrintPlayersToConsole(filteredPlayers);
                    Count++;
                }
            }
            if (Count == 0)
            {
                Console.WriteLine("Tokiame mieste krepšinio komandų nėra");
            }
            Count = 0;
            Console.WriteLine("Futbolo komandos ir jų žaidėjai:");
            Console.WriteLine("");
            for (int i = 0; i < branches.Count; i++)
            {
                filteredPlayers = p.FilteredFootballists(branches, city);
                if (filteredPlayers.Count > 0)
                {
                    p.PrintPlayersToConsole(filteredPlayers);
                    Count++;
                }
            }
            if (Count == 0)
            {
                Console.WriteLine("Tokiame mieste futbolo komandų nėra");
            }


        }
        void ReadBranchData(BranchesContainer branches)
        {
            using (StreamReader reader = new StreamReader(@"komandos.csv"))
            {
                string line = null;
                while (null != (line = reader.ReadLine()))
                {
                    string[] values = line.Split(',');
                    string team = values[0];
                    string city = values[1];
                    string coach = values[2];
                    int matches = int.Parse(values[3]);
                    Branch branch = new Branch(team, city, coach, matches);
                    branches.AddBranch(branch);
                }

            }
        }

        void ReadPlayersData(string fileName, PlayersContainer players)
        {
            using (StreamReader reader = new StreamReader(@fileName))
            {
                string line = null;
                if (fileName == "Krepšininkai.csv")
                {
                    while (null != (line = reader.ReadLine()))
                    {
                        string[] values = line.Split(',');
                        string team = values[0];
                        string name = values[1];
                        string surname = values[2];
                        DateTime birth = DateTime.Parse(values[3]);
                        int amountOfPlayedMatches = int.Parse(values[4]);
                        int score = int.Parse(values[5]);
                        int rebounds = int.Parse(values[6]);
                        int effectiveTransfers = int.Parse(values[7]);
                        Basketballist basketballist = new Basketballist(team, name, surname, birth, amountOfPlayedMatches, score, rebounds, effectiveTransfers);
                        players.AddPlayer(basketballist);
                    }
                }
                else if (fileName == "Futbolininkai.csv")
                {
                    while (null != (line = reader.ReadLine()))
                    {
                        string[] values = line.Split(',');
                        string team = values[0];
                        string name = values[1];
                        string surname = values[2];
                        DateTime birth = DateTime.Parse(values[3]);
                        int amountOfPlayedMatches = int.Parse(values[4]);
                        int score = int.Parse(values[5]);
                        int yellowCards = int.Parse(values[6]);
                        Footballist footballist = new Footballist(team, name, surname, birth, amountOfPlayedMatches, score, yellowCards);
                        players.AddPlayer(footballist);
                    }
                }
            }
        }


        void BranchAdded(BranchesContainer branches, PlayersContainer basketball, PlayersContainer football)
        {

            for (int i = 0; i < branches.Count; i++)
            {
                for (int g = 0; g < basketball.Count; g++)
                {
                    if (branches.GetBranch(i).Team == basketball.GetPlayer(g).Team)
                    {
                        branches.branches[i].Basketballists.AddPlayer(basketball.GetPlayer(g));
                    }
                }

                for (int g = 0; g < football.Count; g++)
                {
                    if (branches.GetBranch(i).Team == football.GetPlayer(g).Team)
                    {
                        branches.branches[i].Footballists.AddPlayer(football.GetPlayer(g));
                    }
                }
            }

        }

        PlayersContainer FilteredBasketballists(BranchesContainer branches, string city)
        {
            PlayersContainer filteredBasketballists = new PlayersContainer();
            for (int i = 0; i < branches.Count; i++)
            {
                if (branches.GetBranch(i).City == city && branches.GetBranch(i).Basketballists.Count > 0)
                {

                    for (int g = 0; g < branches.GetBranch(i).Basketballists.Count; g++)
                    {
                        if (branches.GetBranch(i).Basketballists.GetPlayer(g).Score >= branches.GetBranch(i).Basketballists.Average() &&
                           branches.GetBranch(i).Basketballists.GetPlayer(g).AmountOfPlayedMatches == branches.GetBranch(i).AmountOfPlayedMatches)
                        {
                            filteredBasketballists.AddPlayer(branches.GetBranch(i).Basketballists.GetPlayer(g));
                        }
                    }
                    branches.GetBranch(i).City = "";
                    break;
                }
            }
            return filteredBasketballists;
        }

        PlayersContainer FilteredFootballists(BranchesContainer branches, string city)
        {
            PlayersContainer filteredFootbaliists = new PlayersContainer();
            for (int i = 0; i < branches.Count; i++)
            {
                if (branches.GetBranch(i).City == city && branches.GetBranch(i).Footballists.Count > 0)
                {
                    for (int g = 0; g < branches.GetBranch(i).Footballists.Count; g++)
                    {
                        if (branches.GetBranch(i).Footballists.GetPlayer(g).Score >= branches.GetBranch(i).Footballists.Average() &&
                           branches.GetBranch(i).Footballists.GetPlayer(g).AmountOfPlayedMatches == branches.GetBranch(i).AmountOfPlayedMatches)
                        {
                            filteredFootbaliists.AddPlayer(branches.GetBranch(i).Footballists.GetPlayer(g));
                        }
                    }
                    branches.GetBranch(i).City = "";
                    break;
                }
            }
            return filteredFootbaliists;
        }

        void PrintPlayersToConsole(PlayersContainer players)
        {
            if (players.Count == 0)
            {
                Console.WriteLine("Tokių žaidėjų nėra");
            }
            else
            {
                Console.WriteLine(players.GetPlayer(0).Team);
                for (int i = 0; i < players.Count; i++)
                {
                    Console.WriteLine(players.GetPlayer(i));
                }
            }
        }







    }
}
