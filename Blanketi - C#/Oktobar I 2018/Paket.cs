using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Oktobar_I_2018
{
    public class Paket<T> where T : RacunarskaKomponenta, new()
    {
        int n; int c; T[] niz;

        public Paket(int n = 0, double nv = 1) { this.n = n; c = 0; niz = new T[n]; NV = nv; }

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
                    bW.Write(n); bW.Write(c); bW.Write(NV);
                    for (int i = 0; i < c; i++) niz[i].upisi(bW);
                }
            }
            catch (Exception e)
            { Console.WriteLine("Error occurred: " + e.Message); }
        }
        public void ucitaj(String path)
        {
            try
            {
                using (BinaryReader bR = new BinaryReader(new FileStream(path, FileMode.Open)))
                {
                    n = bR.ReadInt32(); c = bR.ReadInt32(); NV = bR.ReadDouble(); niz = new T[n];
                    for (int i = 0; i < c; i++) { niz[i] = new T(); niz[i].ucitaj(bR); }
                }
            }
            catch (Exception e)
            { Console.WriteLine("Error occurred: " + e.Message); }
        }
        public void razvrstajOUT(out Paket<T> P1, out Paket<T> P2, out Paket<T> P3)
        {
            P1 = new Paket<T>(c, 0.9);
            P2 = new Paket<T>(c, 0.8);
            P3 = new Paket<T>(c, 0.7);

            for (int i = 0; i < c; i++)
            {
                double v = niz[i].nomKar(NV);
                if (v < 0.7)
                    //throw new Exception("Kvalitet zlj!")
                    ;
                    if (v >= 0.9)
                        P1.add(niz[i]);
                    else
                    {
                        if (v >= 0.8) P2.add(niz[i]);
                        else P3.add(niz[i]);
                    }
            }
        }
        public void razvrstajREF(ref Paket<T> P1, ref Paket<T> P2, ref Paket<T> P3)
        {
            P1 = new Paket<T>(c, 0.9);
            P2 = new Paket<T>(c, 0.8);
            P3 = new Paket<T>(c, 0.7);

            for (int i = 0; i < c; i++)
            {
                double v = niz[i].nomKar(NV);
                if (v < 0.7)
                    //throw new Exception("Kvalitet zlj!")
                    ;
                if (v >= 0.9)
                    P1.add(niz[i]);
                else
                {
                    if (v >= 0.8) P2.add(niz[i]);
                    else P3.add(niz[i]);
                }
            }
        }
        public void print()
        {
            Console.WriteLine("Paket ima: " + c + "/" + n + " komponenata.");
            Console.WriteLine("Nominalna vrednost iznosi: " + NV);
            for (int i = 0; i < c; i++)
                niz[i].print();
        }
    }
}
