namespace Battle_System_C_
{
    public class Digimon
    {
        private string name;
        private int HP, level, initiative = 0;

        public Digimon()
        {
            name = "NULL";
            HP = 0;
            level = 0;
            initiative = 0;
        }

        public Digimon(StreamReader rdr)
        {
            initiative = 0;

            string line = rdr.ReadLine();
            string[] values = line.Split(' ');

            level = Convert.ToInt32(values[0]);
            name = values[1];
            HP = Convert.ToInt32(values[2]);
        }

        public string GetName()
        {
            return name;
        }

        public int GetInitiative()
        {
            return initiative;
        }

        public int GetHP()
        {
            return HP;
        }

        public void Print()
        {
            Console.WriteLine(initiative + "  :\t" + name + "   " + HP);
        }

        public void SetInitiative()
        {
            initiative = rolls.D20(); // You need to replace this with actual d20 roll logic
        }

        public void RollATK(Player[] PC, int PlayerCount, Partner[] PMon, int PartnerCount)
        {
            int roll = rolls.D20();
            int dmg = 0, taker = 0;
            int rollType, rollAmount = level;

            if (roll > 10 && roll != 20)
            {
                Console.WriteLine("\nEnemy Rolled: " + roll);
                rollType = rolls.ATKValue();
                dmg = rolls.General(rollType) * rollAmount;
                Console.WriteLine("\n\n");
                for (int i = 0; i < PlayerCount; i++)
                {
                    PC[i].Print();
                }
                for (int i = 0; i < PartnerCount; i++)
                {
                    PMon[i].Print();
                }
                Console.Write("\nSelect Your Target: ");
                taker = Convert.ToInt32(Console.ReadLine());

                if (taker <= PlayerCount)
                {
                    PC[taker - 1].ChangeHP(dmg);
                    Console.WriteLine("\nYour Damage Output is: " + dmg);
                }
                else if (taker > PlayerCount)
                {
                    PMon[taker - PlayerCount - 1].ChangeHP(dmg);
                    Console.WriteLine("\nYour Damage Output is: " + dmg);
                }
                Console.WriteLine();
                return;
            }
            else if (roll == 1)
            {
                Console.WriteLine("NAT 1");
                Console.WriteLine("Select Attack Type");
                rollType = Convert.ToInt32(Console.ReadLine());
                this.ChangeHP(rolls.General(rollType) * rollAmount);
                Console.WriteLine();
                return;
            }
            else if (roll == 20)
            {
                Console.WriteLine("NAT 20");
                rollType = rolls.ATKValue();
                dmg = (rolls.General(rollType) * rollAmount) * 2;
                Console.WriteLine("\n\n");
                for (int i = 0; i < PlayerCount; i++)
                {
                    PC[i].Print();
                }
                Console.Write("\nSelect Your Target: ");
                taker = Convert.ToInt32(Console.ReadLine());
                PC[taker - 1].ChangeHP(dmg);
                Console.WriteLine("\nYour Damage Output is: " + dmg);
                Console.WriteLine();
                return;
            }
            else
            {
                Console.WriteLine("Enemy Rolled: " + roll);
                Console.WriteLine("\nMissed!");
                return;
            }
        }

        public void ChangeHP(int damage)
        {
            if (HP > 0 && damage <= HP)
            {
                HP -= damage;
                if (HP < 0)
                {
                    HP = 0;
                }
            }
            else if (damage >= HP)
            {
                HP = 0;
            }
        }
    }
}
