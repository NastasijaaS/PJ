using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decembar_2017
{
    class Program
    {
        public static Random rand = new Random();
        public static String randStr(int l)
        {
            String ret = "";
            ret += (char)'A' + rand.Next(0, 26);
            for (int i = 0; i < l; i++)
                ret += (char)'a' + rand.Next(0, 26);
            return ret;
        }
        static void Main(string[] args)
        {
            try
            {
                Paket<Otpornik> PO1 = new Paket<Otpornik>(rand.Next(100, 150), rand.NextDouble() + rand.Next(1, 5));
                Paket<Kondenzator> PK1 = new Paket<Kondenzator>(rand.Next(100, 150), rand.NextDouble() + rand.Next(1, 5));
                for (int i = 0; i < 100; i++)
                {
                    PO1.add(new Otpornik(rand.NextDouble() + rand.Next(0, 10), rand.NextDouble() + rand.Next(0, 10), rand.Next(123456789)));
                    PK1.add(new Kondenzator(rand.NextDouble() + rand.Next(0, 10), rand.NextDouble() + rand.Next(0, 10), rand.Next(123456789)));
                }

                PO1.upisi("Otpornici.bin");
                PK1.upisi("Kondenzatori.bin");

                Paket<Otpornik> PO2 = new Paket<Otpornik>();
                Paket<Kondenzator> PK2 = new Paket<Kondenzator>();

                PO2.ucitaj("Otpornici.bin");
                PK2.ucitaj("Kondenzatori.bin");

                Paket<Otpornik> POR1, POR2, POR3;
                Paket<Kondenzator> PKR1, PKR2, PKR3;

                PO2.razvrstaj(out POR1, out POR2, out POR3);
                PK2.razvrstaj(out PKR1, out PKR2, out PKR3);

                POR1.upisiTXT("Otrpornici01.txt");
                POR2.upisiTXT("Otrpornici1.txt");
                POR2.upisiTXT("Otrpornici5.txt");

                PKR1.upisiTXT("Kondenzatori01.txt");
                PKR2.upisiTXT("Kondenzatori1.txt");
                PKR3.upisiTXT("Kondenzatori5.txt");
            }
            catch (Exception e)
            { Console.WriteLine("Error occurred: " + e.Message); }
        }
    }
}
