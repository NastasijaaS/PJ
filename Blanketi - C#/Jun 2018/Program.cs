using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jun_2018
{
    class Program
    {
        public static readonly Random rand = new Random();
        public static String randStr(int l)
        {
            String ret = "";
            String alnum = "qwertzuiopasdfghjklyxcvbnm";
            ret += (char)('A' + rand.Next(0, 26));
            for (int i = 0; i < l; i++)
                ret += alnum[rand.Next(0, 26)];
            return ret;
        }
        static void Main(string[] args)
        {
            try
            {
                int num = rand.Next(250, 500);
                Selekcija<Napadac> SN1 = new Selekcija<Napadac>(num, rand.NextDouble() * rand.Next(1,10));
                Selekcija<Golman> SG1 = new Selekcija<Golman>(num, rand.NextDouble() * rand.Next(1,10));

                for (int i = 0; i < 250; i++)
                {
                    SN1.add(new Napadac(rand.Next(1,10), rand.Next(10,20), randStr(10), randStr(15)));
                    SG1.add(new Golman(i % rand.Next(1, 5) == 0, rand.NextDouble() * rand.Next(100, 500), randStr(10), randStr(15)));
                }

                SN1.upisi("SN1Output.txt");
                SG1.upisi("SG1Output.txt");

                Selekcija<Napadac> SN2 = new Selekcija<Napadac>();
                Selekcija<Golman> SG2 = new Selekcija<Golman>();
                SN2.ucitaj("SN1Output.txt");
                SG2.ucitaj("SG1Output.txt");

                Selekcija<Napadac> SN2S, SN2R;
                Selekcija<Golman> SG2S, SG2R;

                SN2.razvrstaj(out SN2S, out SN2R);
                SG2.razvrstaj(out SG2S, out SG2R);

                SN2S.upisi("SN2Startna.txt");
                SG2S.upisi("SG2Startna.txt");
                SN2R.upisi("SN2Rezervna.txt");
                SG2R.upisi("SG2Rezervna.txt");
            }
            catch (Exception E)
            { Console.WriteLine("Error occurred: " + E.Message); }
        }
    }
}
