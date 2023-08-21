using System;
using System.Collections.Generic;
using System.Linq;

namespace Battle_System_C_
{
    public class Utility
    {
        public static void SortDigimon(Digimon[] opponents)
        {
            Array.Sort(opponents, (a, b) => -CompareByInitiative(a, b));
        }

        public static void SortPlayers(Player[] players)
        {
            Array.Sort(players, (a, b) => -ComparePlayersInitiative(a, b));
        }

        public static void SortPartners(Partner[] partners)
        {
            Array.Sort(partners, (a, b) => -ComparePartnerInitiative(a, b));
        }

        private static int CompareByInitiative(Digimon a, Digimon b)
        {
            return b.GetInitiative().CompareTo(a.GetInitiative());
        }

        private static int ComparePlayersInitiative(Player a, Player b)
        {
            return a.GetInitiative().CompareTo(b.GetInitiative());
        }

        private static int ComparePartnerInitiative(Partner a, Partner b)
        {
            return a.GetInitiative().CompareTo(b.GetInitiative());
        }
        public static void SortPlayers(Player[] PC, int size)
        {
            Array.Sort(PC, (a, b) => ComparePlayersInitiative(b, a)); // Sort in descending order
        }

        public static void SortPartner(Partner[] PMon, int size)
        {
            Array.Sort(PMon, (a, b) => ComparePartnerInitiative(b, a)); // Sort in descending order
        }

        public static bool CheckPrint(int[] printedArray, int count, int index)
        {
            for (int i = 0; i < count; i++)
            {
                if (printedArray[i] == index)
                {
                    return false;
                }
            }
            return true;
        }

        public static void SortedPrint(Digimon[] Opponent, Player[] Players, Partner[] PMon, int EnemyCount, int PlayerCount, int PartnerCount)
        {
            int totalEntities = EnemyCount + PlayerCount + PartnerCount;
            int[] SortedInit = new int[totalEntities];

            int countOpponent = 0;
            int[] PrintedOpponent = new int[EnemyCount];

            int countPlayer = 0;
            int[] PrintedPlayer = new int[PlayerCount];

            int countPartner = 0;
            int[] PrintedPartner = new int[PartnerCount];

            int index = 0, opp = 0, play = 0, part = 0;

            // Collect initiative values
            for (int i = 0; i < EnemyCount; i++)
            {
                SortedInit[index] = Opponent[i].GetInitiative();
                index++;
            }
            for (int i = 0; i < PlayerCount; i++)
            {
                SortedInit[index] = Players[i].GetInitiative();
                index++;
            }
            for (int i = 0; i < PartnerCount; i++)
            {
                SortedInit[index] = PMon[i].GetInitiative();
                index++;
            }

            Array.Sort(SortedInit, (a, b) => -a.CompareTo(b)); // Sort in descending order

            while (countOpponent < EnemyCount && countPlayer < PlayerCount && countPartner < PartnerCount)
            {
                for (int i = 0; i < totalEntities; i++)
                {
                    if (countOpponent < EnemyCount && SortedInit[i] == Opponent[opp].GetInitiative() && CheckPrint(PrintedOpponent, countOpponent, opp))
                    {
                        Opponent[opp].Print();
                        PrintedOpponent[countOpponent] = opp;
                        countOpponent++;
                        opp++;
                    }
                    else if (countPlayer < PlayerCount && SortedInit[i] == Players[play].GetInitiative() && CheckPrint(PrintedPlayer, countPlayer, play))
                    {
                        Players[play].Print();
                        PrintedPlayer[countPlayer] = play;
                        countPlayer++;
                        play++;
                    }
                    else if (countPartner < PartnerCount && SortedInit[i] == PMon[part].GetInitiative() && CheckPrint(PrintedPartner, countPartner, part))
                    {
                        PMon[part].Print();
                        PrintedPartner[countPartner] = part;
                        countPartner++;
                        part++;
                    }
                }
            }
        }

        public static bool CheckHP(Digimon[] opponents)
        {
            foreach (var opponent in opponents)
            {
                if (opponent.GetHP() != 0)
                {
                    return false; // If any Digimon has non-zero HP, return false
                }
            }
            return true; // All Digimon have zero HP
        }

        public static bool CheckPCHP(Partner[] partners, Player[] players)
        {

            foreach (var partner in partners)
            {
                if (partner.GetHP() != 0)
                {
                    return false; // If any Partner has non-zero HP, return false
                }
            }

            foreach (var player in players)
            {
                if (player.GetHP() != 0)
                {
                    return false; // If any Player has non-zero HP, return false
                }
            }

            return true; // All Partners, and Players have zero HP
        }



        public static void EnemyDefense(Digimon[] opponents)
        {
            foreach (var opponent in opponents)
            {
                opponent.Print();
            }
            Console.WriteLine("\n\n");

            int target, damage;

            Console.Write("Select Target: ");
            target = Convert.ToInt32(Console.ReadLine());

            if (target >= 1 && target <= opponents.Length)
            {
                Console.Write("Input Damage done: ");
                damage = Convert.ToInt32(Console.ReadLine());
                opponents[target - 1].ChangeHP(damage);
            }
        }

        public static void EnemyAttack(Digimon[] opponents, Player[] players, Partner[] partnerMonsters)
        {
            foreach (var opponent in opponents)
            {
                opponent.Print();
            }
            Console.WriteLine("\n\n");

            for (int i = 0; i < opponents.Length; i++)
            {
                if (opponents[i].GetHP() != 0)
                {
                    Console.WriteLine(opponents[i].GetName());
                    opponents[i].RollATK(players, players.Length, partnerMonsters, partnerMonsters.Length);
                    Console.WriteLine();
                    System.Threading.Thread.Sleep(3000);
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }

        public static void ResetDungeon(ref bool dungeonClear)
        {
            char c;
            Console.Write("Is the dungeon complete? (Y/N): ");
            c = Console.ReadKey().KeyChar;
            dungeonClear = (c == 'Y' || c == 'y');
        }
    }

}