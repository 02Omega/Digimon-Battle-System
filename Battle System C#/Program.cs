namespace Battle_System_C_
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            bool dungeonClear = false;

            do
            {
                int enemyCount, playerCount, partnerCount;

                Digimon[] opponents = encounter.Initialize(out enemyCount);
                Player[] players = encounter.Init(out playerCount);
                Partner[] partnerMonsters = encounter.InitD(out partnerCount);

                encounter.Battle(opponents, enemyCount, players, playerCount, partnerMonsters, partnerCount);
                encounter.End(opponents, partnerMonsters, players);

                Utility.ResetDungeon(ref dungeonClear);
                Console.Clear();

            } while (!dungeonClear);
        }
    }
}