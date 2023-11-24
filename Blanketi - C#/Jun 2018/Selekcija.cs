using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Jun_2018
{
    public class Selekcija<T> where T : Fudbaler, new()
    {
        int n; int c; T[] niz;
        public double NORM { get; set; }
        public Selekcija(int n = 0, double norm = 0) { this.n = n; c = 0; niz = new T[n]; NORM = norm; }

        public void add(T el)
        {
            if (c >= n)
                throw new Exception("Niz je pun!");
            niz[c++] = el;
        }
        public void upisi(String path)
        {
            try
            {
                using (StreamWriter sW = new StreamWriter(new FileStream(path, FileMode.Create)))
                {
                    sW.WriteLine(n);
                    sW.WriteLine(c);
                    sW.WriteLine(NORM);
                    for (int i = 0; i < c; i++)
                        niz[i].upisi(sW);
                }
            }
            catch (Exception e)
            { Console.WriteLine("Error occurred: " + e.Message); }
        }
        public void ucitaj(String path)
        {
            try
            {
                using (StreamReader sR = new StreamReader(new FileStream(path, FileMode.Open)))
                {
                    n = int.Parse(sR.ReadLine());
                    c = int.Parse(sR.ReadLine());
                    NORM = double.Parse(sR.ReadLine());
                    niz = new T[n];
                    for (int i = 0; i < c; i++)
                        (niz[i] = new T()).ucitaj(sR);
                }
            }
            catch (Exception e)
            { Console.WriteLine("Error occurred: " + e.Message); }
        }
        public void razvrstaj(out Selekcija<T> S1, out Selekcija<T> S2)
        {
            S1 = new Selekcija<T>(c, 0.8);
            S2 = new Selekcija<T>(c, 0.4);

            for (int i = 0; i < c; i++)
            {
                if (niz[i].ocekivanaNorma(NORM) < 0.2)
                    throw new Exception("Greska pri odabiru selekcije!");
                if (niz[i].ocekivanaNorma(NORM) > 0.8)
                    S1.add(niz[i]);
                else
                {
                    if (niz[i].ocekivanaNorma(NORM) > 0.2)
                        S2.add(niz[i]);
                }
            }
        }
        public void print()
        {
            Console.WriteLine("Selekcija ima: " + c + "/" + n + " fudbalera.");
            Console.WriteLine("Norma: " + NORM);
            for (int i = 0; i < c; i++)
            {
                Console.WriteLine((i + 1) + ". Fudbaler:");
                niz[i].print();
            }
        }
    }
}
