using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace April_2018
{
    class Program
    {
        public static readonly Random rand = new Random();
        public static String randStr(int l)
        {
            String ret = "";
            ret += (char)('A' + rand.Next(0, 26));
            for (int i = 0; i < l; i++)
                ret += (char)('a' + rand.Next(0, 26));
            return ret;
        }
        static void Main(string[] args)
        {
            Fakultet F1 = new Fakultet("Elektronski fakultet");
            for (int i = 0; i < 10; i++)
            {
                EkipaN n = new EkipaN((Disciplina)rand.Next(1, 4));
                EkipaS s = new EkipaS((Disciplina)rand.Next(4, 9));
                for (int j = 0; j < 20; j++)
                {
                    n.add(new Student(randStr(10), randStr(15), rand.Next(20, 100)));
                    s.add(new Student(randStr(10), randStr(15), rand.Next(20, 100)));
                }
                F1.add(n);
                F1.add(s);
            }
            F1.upisiBIN("Faks.bin", "Nauka.bin", "Sport.bin");
            ///
            /////////////////////////////////////////////////////////////
            ///
            Fakultet F2 = new Fakultet();
            F2.ucitaj("Faks.bin", "Nauka.bin", "Sport.bin");
            F2.sortN();
            F2.sortS();
            F2.upisiBIN("Faks2.bin", "Nauka2.bin", "Sport2.bin");
        }
    }
}
