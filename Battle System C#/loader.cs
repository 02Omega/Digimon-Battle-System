using System;
using System.IO;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_System_C_
{
    public class DataLoader
    {
        public static Digimon[] Load(string filename, out int size)
        {
            using (StreamReader rdr = new StreamReader(filename))
            {
                size = Convert.ToInt32(rdr.ReadLine());
                Digimon[] Mon = new Digimon[size];
                for (int i = 0; i < size; i++)
                {
                    Mon[i] = new Digimon(rdr);
                }
                return Mon;
            }
        }

        public static Player[] LoadPC(string filename, out int size)
        {
            using (StreamReader rdr = new StreamReader(filename))
            {
                size = Convert.ToInt32(rdr.ReadLine());
                Player[] PC = new Player[size];
                for (int i = 0; i < size; i++)
                {
                    PC[i] = new Player(rdr);
                }
                return PC;
            }
        }

        public static Partner[] LoadPD(string filename, out int size)
        {
            using (StreamReader rdr = new StreamReader(filename))
            {
                size = Convert.ToInt32(rdr.ReadLine());
                Partner[] PMons = new Partner[size];
                for (int i = 0; i < size; i++)
                {
                    PMons[i] = new Partner(rdr);
                }
                return PMons;
            }
        }
    }
}
