using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Januar_2018
{
    public class Takmicenje<T> where T : Atleticar, new()
    {
        T[] niz;
        public int MAX { get; set; }
        public int CUR { get; set; }
        public double DVDT { get; set; }
        public Takmicenje(int n = 0, double dvdt = 1) { MAX = n; CUR = 0; niz = new T[MAX]; DVDT = dvdt; }

        public void add(T takmicar)
        {
            if (CUR >= MAX)
                throw new Exception("Niz je pun!");
            niz[CUR++] = takmicar;
        }
        public void removeIllegal()
        {
            for (int i = 0; i < CUR; i++)
            {
                if (niz[i].RDP > DVDT)
                { shiftLeft(i--); CUR--; }
            }
        }

        private void shiftLeft(int v)
        {
            for (int i = v; i < CUR - 1; i++)
                niz[i] = niz[i + 1];
        }
        public void sort() { qSort(0, CUR - 1); }
        public void qSort(int low, int high)
        {
            if (low < high)
            { int p = part(low, high); qSort(low, p - 1); qSort(p + 1, high); }
        }
        public int part(int low, int high)
        {
            T pivot = niz[high];
            int i = low;
            for (int j = low + 1; j < high; j++)
                if (niz[j].bolji(pivot))
                    swap(i++, j);
            swap(i, high);
            return i;
        }
        public void swap(int i, int j) { T temp = niz[i]; niz[i] = niz[j]; niz[j] = temp; }
        public void upisiBIN(String path)
        {
            try
            {
                using (BinaryWriter bW = new BinaryWriter(new FileStream(path, FileMode.Create)))
                {
                    bW.Write(MAX);
                    bW.Write(CUR);
                    bW.Write(DVDT);
                    for (int i = 0; i < CUR; i++)
                        niz[i].upisiBIN(bW);
                }
            }
            catch (Exception e) { Console.WriteLine("Error occurred: " + e.Message); }
        }
        public void ucitaj(String path)
        {
            try
            {
                using (BinaryReader bR = new BinaryReader(new FileStream(path, FileMode.Open)))
                {
                    MAX = bR.ReadInt32();
                    CUR = bR.ReadInt32();
                    DVDT = bR.ReadDouble();
                    niz = new T[MAX];
                    for (int i = 0; i < CUR; i++)
                        (niz[i] = new T()).citaj(bR);
                }
            }
            catch (Exception e) { Console.WriteLine("Error occurred: " + e.Message); }
        }

        public void upisiTXT(String path)
        {
            try
            {
                using (StreamWriter sW = new StreamWriter(new FileStream(path, FileMode.Create)))
                {
                    sW.WriteLine("Takmicenje ima: " + CUR + "/" + MAX + " takmicara.");
                    sW.WriteLine("Dozvoljena granica dopinga je: " + DVDT);
                    for (int i = 0; i < CUR; i++)
                    {
                        sW.WriteLine((i + 1) + ". Takmicar:");
                        niz[i].upisiTXT(sW);
                    }
                }
            }
            catch (Exception e) { Console.WriteLine("Error occurred: " + e.Message); }
        }
    }
}
