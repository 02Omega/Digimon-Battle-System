using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_System_C_
{
    internal class encounter
    {
        public static Digimon[] EnemyArray(int enemyCount, Digimon[] total, int size)
        {
            Digimon[] enemy = new Digimon[enemyCount];
            Random rand = new Random();

            for (int i = 0; i < enemyCount; i++)
            {
                enemy[i] = total[rand.Next(0, size)];
            }

            return enemy;
        }

        public static Digimon[] Initialize(out int enemyCount)
        {
            Console.Write("Enter Dungeon Level: "); // Number & Lvl of enemies
            int size;
            enemyCount = 0;
            char dLevel = Console.ReadKey().KeyChar;
            Digimon[] total;
            
            Digimon[] opponent = null;

            switch (dLevel)
            {
                case '0':
                    total = DataLoader.Load("Rookie.txt", out size);
                    enemyCount = 1;
                    opponent = EnemyArray(enemyCount, total, size);
                    break;
                case '1':
                    total = DataLoader.Load("Rookie.txt", out size);
                    enemyCount = 3;
                    opponent = EnemyArray(enemyCount, total, size);
                    break;
                case '2':
                    total = DataLoader.Load("Rookie.txt", out size);
                    enemyCount = 5;
                    opponent = EnemyArray(enemyCount, total, size);
                    break;
                case '3':
                    total = DataLoader.Load("Champion.txt", out size);
                    enemyCount = 3;
                    opponent = EnemyArray(enemyCount, total, size);
                    break;
                case '4':
                    total = DataLoader.Load("Champion.txt", out size);
                    enemyCount = 5;
                    opponent = EnemyArray(enemyCount, total, size);
                    break;
                case '5':
                    total = DataLoader.Load("Ultimate.txt", out size);
                    enemyCount = 3;
                    opponent = EnemyArray(enemyCount, total, size);
                    break;
                case '6':
                    total = DataLoader.Load("Ultimate.txt", out size);
                    enemyCount = 5;
                    opponent = EnemyArray(enemyCount, total, size);
                    break;
                case '7':
                    total = DataLoader.Load("Mega.txt", out size);
                    enemyCount = 1;
                    opponent = EnemyArray(enemyCount, total, size);
                    break;
                case '8':
                    total = DataLoader.Load("Mega.txt", out size);
                    enemyCount = 2;
                    opponent = EnemyArray(enemyCount, total, size);
                    break;
                case '9':
                    total = DataLoader.Load("Mega.txt", out size);
                    enemyCount = 3;
                    opponent = EnemyArray(enemyCount, total, size);
                    break;
                case 'x':
                    total = DataLoader.Load("Mega.txt", out size);
                    enemyCount = 5;
                    opponent = EnemyArray(enemyCount, total, size);
                    break;
            }

            if (opponent != null)
            {
                for (int i = 0; i < enemyCount; i++)
                {
                    opponent[i].SetInitiative();
                }

                SortByInitiative(opponent);
            }

            Console.Clear();
            return opponent;
        }

        public static void SortByInitiative(Digimon[] array)
        {
            Array.Sort(array, (a, b) => b.GetInitiative().CompareTo(a.GetInitiative()));
        }

        public static Player[] Init(out int playerCount)
        {
            Player[] pc = DataLoader.LoadPC("Players.txt", out playerCount);

            for (int i = 0; i < playerCount; i++)
            {
                pc[i].SetInitiative();
            }

            Utility.SortPlayers(pc, playerCount);
            Console.Clear();
            return pc;
        }

        public static Partner[] InitD(out int partnerCount)
        {
            Partner[] pMon = DataLoader.LoadPD("Partner.txt", out partnerCount);

            for (int i = 0; i < partnerCount; i++)
            {
                pMon[i].SetInitiative();
            }

            Utility.SortPartner(pMon, partnerCount);
            Console.Clear();

            for (int i = 0; i < partnerCount; i++)
            {
                pMon[i].SetHP();
            }

            Utility.SortPartner(pMon, partnerCount);
            Console.Clear();
            return pMon;
        }

        public static void Battle(Digimon[] opponent, int enemyCount, Player[] pc, int playerCount, Partner[] pMons, int partnerCount)
        {
            bool stop = false;
            int count = 0;
            string type;

            do
            {
                Utility.SortedPrint(opponent, pc, pMons, enemyCount, playerCount, partnerCount);
                Console.WriteLine("\n\n");
                Console.Write("Select Mode Defense (d) or Attack (a): ");
                type = Console.ReadLine();

                if (type == "d")
                {
                    Console.Clear();
                    Utility.EnemyDefense(opponent);
                }
                else if (type == "a")
                {
                    Console.Clear();
                    Utility.EnemyAttack(opponent, pc, pMons);
                    count++;
                }

                Console.Clear();

            } while (!Utility.CheckHP(opponent) && count < enemyCount);
        }

        public static void End(Digimon[] opponent, Partner[] PMons, Player[] players)
        {
            if (Utility.CheckHP(opponent))
            {
                Console.WriteLine("Congratulations on clearing the battle!");
            }
            if (Utility.CheckPCHP(PMons, players))
            {
                Console.WriteLine("You Lose!");
            }
        }
    }
}
