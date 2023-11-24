using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Oktobar_I_2018
{
    class Program
    {

        public static Random rand = new Random();
        public static String randStr(int l)
        {
            String ret = "";
            String posib = "QWERTZUIOPASDFGHJKLYXCVBNM1234567890qwertzuiopasdfghjklyxcvbnm";
            for (int i = 0; i < l; i++)
                ret += posib[rand.Next(0, 62)];
            return ret;
        }
        static void Main(string[] args)
        {
            try
            {
                Paket<Processor> PP1 = new Paket<Processor>(rand.Next(50, 100), rand.NextDouble() + 0.1);
                Paket<HardDisc> PHD1 = new Paket<HardDisc>(rand.Next(50, 100), rand.NextDouble() + 0.1);

                for (int i = 0; i < 50; i++)
                {
                    PP1.add(new Processor(rand.NextDouble() * rand.Next(1, 5), rand.NextDouble() * rand.Next(1, 10), rand.Next(1234567)));
                    PHD1.add(new HardDisc(rand.Next(567), rand.NextDouble() * rand.Next(1, 10), rand.Next(1234567)));
                }

                PP1.upisi("procesori.bin");
                PHD1.upisi("harddiskovi.bin");

                Paket<Processor> PP2 = new Paket<Processor>();
                Paket<HardDisc> PHD2 = new Paket<HardDisc>();

                PP2.ucitaj("procesori.bin");
                PHD2.ucitaj("harddiskovi.bin");

                Paket<Processor> PP90, PP80, PP70;
                Paket<HardDisc> PHD90=null, PHD80=null, PHD70=null;

                PP2.razvrstajOUT(out PP90, out PP80, out PP70);
                PHD2.razvrstajREF(ref PHD90, ref PHD80,ref PHD70);

                Console.WriteLine("\n\n\n+++++++++++++++++++++++++++++\n\n\n");
                PP90.print();
                Console.WriteLine("\n\n\n+++++++++++++++++++++++++++++\n\n\n");
                PP80.print();
                Console.WriteLine("\n\n\n+++++++++++++++++++++++++++++\n\n\n");
                PP70.print();
                Console.WriteLine("\n\n\n+++++++++++++++++++++++++++++\n\n\n");
                PHD90.print();
                Console.WriteLine("\n\n\n+++++++++++++++++++++++++++++\n\n\n");
                PHD80.print();
                Console.WriteLine("\n\n\n+++++++++++++++++++++++++++++\n\n\n");
                PHD70.print();
            }
            catch (Exception e)
            { Console.WriteLine("Error occurred: " + e.Message); }
        }
    }
}
