using System;
using System.IO;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_System_C_
{
    public class Partner
    {
        private string name, partner;
        private int HP, initiative = 0;

        public Partner()
        {
            HP = 0;
            initiative = 0;
            name = "NULL";
            partner = "NULL";
        }

        public Partner(StreamReader rdr)
        {
            initiative = 0;

            string line = rdr.ReadLine();
            string[] values = line.Split('\t'); // Assuming you are using tab as the separator

            if (values.Length >= 2)
            {
                name = values[0];
                partner = values[1];
            }

            HP = 0;
            initiative = 0;
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
            Console.WriteLine(initiative + " :\t" + name + "   " + HP);
        }

        public void SetInitiative()
        {
            Console.Write("Enter " + name + "'s Initiative: ");
            initiative = Convert.ToInt32(Console.ReadLine());
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

        public void SetHP()
        {
            Console.Write("Enter " + name + "'s HP: ");
            HP = Convert.ToInt32(Console.ReadLine());
        }
    }
}
