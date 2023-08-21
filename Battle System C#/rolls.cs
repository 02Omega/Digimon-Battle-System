using System;
using System.IO;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_System_C_
{
    public class rolls
    {
        private static Random rand = new Random();

        public static int General(int type)
        {
            return rand.Next(1, type + 1);
        }

        public static int D20()
        {
            return rand.Next(1, 21);
        }

        public static int D10()
        {
            return rand.Next(1, 11);
        }

        public static int D8()
        {
            return rand.Next(1, 9);
        }

        public static int D6()
        {
            return rand.Next(1, 7);
        }

        public static int D4()
        {
            return rand.Next(1, 5);
        }

        public static int ATKValue()
        {
            int random = rand.Next(4);
            switch (random)
            {
                case 0:
                    return 4;
                case 1:
                    return 6;
                case 2:
                    return 8;
                case 3:
                    return 10;
                default:
                    return 4; // Default case
            }
        }
    }
}
