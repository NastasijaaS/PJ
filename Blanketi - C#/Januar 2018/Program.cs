using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Januar_2018
{
    class Program
    {
        public static String randStr(int l)
        {
            String ret = "";
            ret += (char)('A' + Atleticar.rand.Next(0, 26));
            for(int i=0;i<l;i++)
                ret+= (char)('a' + Atleticar.rand.Next(0, 26));
            return ret;
        }
        static void Main(string[] args)
        {
            
            try {
                Takmicenje<Trkac> T1 = new Takmicenje<Trkac>(Atleticar.rand.Next(100, 150),Atleticar.rand.NextDouble());
                Takmicenje<Skakac>S1=new Takmicenje<Skakac>(Atleticar.rand.Next(100, 150), Atleticar.rand.NextDouble());

                for (int i = 0; i < 100; i++)
                {
                    T1.add(new Trkac(randStr(10), randStr(15), Atleticar.rand.NextDouble() + Atleticar.rand.Next(60, 200), (tipStaze)(Atleticar.rand.Next(1, 4))));
                    S1.add(new Skakac(randStr(10), randStr(15), Atleticar.rand.NextDouble() + Atleticar.rand.Next(10, 20), (tipSkoka)(Atleticar.rand.Next(1, 3))));
                }

                T1.upisiBIN("trkaci.bin");
                S1.upisiBIN("skakaci.bin");

                Takmicenje<Trkac> T2 = new Takmicenje<Trkac>();
                Takmicenje<Skakac> S2 = new Takmicenje<Skakac>();

                T2.ucitaj("trkaci.bin");
                S2.ucitaj("skakaci.bin");

                T2.removeIllegal();
                T2.sort();
                S2.removeIllegal();
                S2.sort();
                
                T2.upisiTXT("trka_rez.txt");
                S2.upisiTXT("skok_rez.txt");
            }
            catch (Exception e) { Console.WriteLine("Error occurred: " + e.Message); }
        }
    }
}
