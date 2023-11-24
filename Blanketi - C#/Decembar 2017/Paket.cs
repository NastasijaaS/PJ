using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Decembar_2017
{
    public class Paket<T> where T : Komponenta, new()
    {
        T[] niz;
        int n;
        int c;

        public Paket(int n = 0, double nv = 0) { this.n = n; c = 0; niz = new T[n]; NV = nv; }
        public double NV { get; set; }
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
                using (BinaryWriter bW = new BinaryWriter(new FileStream(path, FileMode.Create)))
                {
                    bW.Write(n);
                    bW.Write(c);
                    bW.Write(NV);
                    for (int i = 0; i < c; i++)
                        niz[i].upisi(bW);
                }
            }
            catch (Exception e)
            { Console.WriteLine("Error occurred:" + e.Message); }
        }
        public void ucitaj(String path)
        {
            try
            {
                using (BinaryReader bR = new BinaryReader(new FileStream(path, FileMode.Open)))
                {
                    n = bR.ReadInt32(); c = bR.ReadInt32(); NV = bR.ReadDouble(); niz = new T[n];
                    for (int i = 0; i < c; i++)
                        (niz[i] = new T()).ucitaj(bR);
                }
            }
            catch (Exception e)
            { Console.WriteLine("Error occurred:" + e.Message); }
        }
        public void upisiTXT(String path)
        {
            try
            {
                using (StreamWriter sW = new StreamWriter(new FileStream(path, FileMode.Create)))
                {
                    sW.WriteLine("Paket sadrzi: " + c + "/" + n + " komponenti");
                    sW.WriteLine("Nominalna vrednost komponenti u paketu iznosi: " + NV);
                    for (int i = 0; i < c; i++)
                    {
                        sW.WriteLine((i + 1) + ". Komponenta:");
                        niz[i].upisiTXT(sW);
                    }
                }
            }
            catch (Exception e)
            { Console.WriteLine("Error occurred:" + e.Message); }
        }
        public void razvrstaj(out Paket<T> P1, out Paket<T> P2, out Paket<T> P3)
        {
            P1 = new Paket<T>(c, 0.1);
            P2 = new Paket<T>(c, 0.5);
            P3 = new Paket<T>(c, 5);

            for (int i = 0; i < c; i++)
            {
                if (niz[i].nom(NV) < 0.1)
                    P1.add(niz[i]);
                else
                {
                    if (niz[i].nom(NV) < 1)
                        P2.add(niz[i]);
                    else
                    {
                        if (niz[i].nom(NV) < 10)
                            P3.add(niz[i]);
                        else
                            throw new Exception("Kvalitet je sranje!");
                    }
                }
            }
        }
    }
}
