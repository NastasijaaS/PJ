using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oktobar_II_2018
{
    class Program
    {
        public static readonly Random rand = new Random();
        public static String randString(int lenght)
        {
            String ret = "";
            String pos = "QWERTZUIOPASDFGHJKLYXCVBNM1234567890qwertzuiopasdfghjklyxcvbnm";
            for (int i = 0; i < lenght; i++)
                ret += pos[rand.Next(0, 62)];
            return ret;
        }
        static void Main(string[] args)
        {
            // kreiranje parka automobila, za upis u fajl
            VoziloPark<Automobil> VA1 = new VoziloPark<Automobil>(20);
            VA1.DEIG = rand.Next(50, 199);
            for (int i = 0; i < 20; i++)
                VA1.add(new Automobil((tipAuta)rand.Next(0, 3), randString(rand.Next(10, 20)), randString(rand.Next(10, 15)), rand.Next(5, 20)));
            VA1.upisi("automobil.txt");

            // kreiranje parka kamiona, za upis u fajl
            VoziloPark<Kamion> VK1 = new VoziloPark<Kamion>(20);
            VK1.DEIG = rand.Next(50, 199);
            for (int i = 0; i < 20; i++)
                VK1.add(new Kamion(rand.NextDouble()*rand.Next(0,50), randString(rand.Next(10, 20)), randString(rand.Next(10, 15)), rand.Next(5, 20)));
            VK1.upisi("kamion.txt");

            // citanje parka automobila iz fajla
            VoziloPark<Automobil> VA2 = new VoziloPark<Automobil>();
            VA2.citaj("automobil.txt");

            // citanje parka kamiona iz fajla
            VoziloPark<Kamion> VK2 = new VoziloPark<Kamion>();
            VK2.citaj("kamion.txt");

            // izbacivanje odredjenih elemenata
            VA2.removeDangerous();
            VK2.removeDangerous();

            // sortiranje parkova
            VA2.sort();
            VK2.sort();

            // upis novoformiranih parkova u fajl
            VA2.upisi("automobil_izlaz.txt");
            VK2.upisi("kamion_izlaz.txt");
        }
    }
}
