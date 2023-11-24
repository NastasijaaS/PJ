using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Decembar_2018
{
    public class Katalog<T> where T : Putovanje, new()
    {
        T[] niz;        // "Lista" putovanja
        int n;          // kapacitet (maksimalno putovanja)
        int c;          // trenutno upisanih putovanja

        public T[] Niz
        {
            get { return this.niz; }
            set { this.niz = value; }
        }
        public T this[int i]
        {
            get { return this.niz[i]; }
            set { this.niz[i] = value; }
        }
        public int N { get { return this.n; } set { this.n = value; } }
        public int C { get { return this.c; } set { this.c = value; } }

        public Katalog(int n = 0)
        {
            N = n;
            C = 0;
            Niz = new T[n];
        }

        public void addTo(T p)
        {
            if (C >= N)
                throw new Exception("Katalog je pun!");
            Niz[C++] = p;
        }
        public void remove(int i)
        {
            if (i < 0 || i >= C)
                throw new Exception("Indeks je van opsega za ukljanjanje!");
            shiftLeft(i);
            C--;
        }
        private void shiftLeft(int i)
        {
            for (int j = i; j < C - 1; j++)
                Niz[j] = Niz[j + 1];
        }

        public void upis(String S)
        {
            try
            {
                using (BinaryWriter bw = new BinaryWriter(new FileStream(S, FileMode.Create)))
                {
                    bw.Write(N);
                    bw.Write(C);
                    for (int i = 0; i < C; i++)
                    {
                        Niz[i].upis(bw);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occurred: " + e.Message);
            }
        }
        public void citaj(String S)
        {
            try {
                using (BinaryReader br = new BinaryReader(new FileStream(S, FileMode.Open)))
                {
                    N = br.ReadInt32();
                    C = br.ReadInt32();
                    Niz = new T[N];

                    for (int i = 0; i < C; i++)
                    {
                        Niz[i] = new T();
                        Niz[i].citaj(br);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occurred: " + e.Message);
            }
        }

        public void removeNotSpecial()
        {
            for (int i = 0; i < C; i++)
                if (Niz[i].SP == SpecialOffer.Rest)
                    remove(i--);
        }
        public void sort(bool dir = true)
        {
            qSort(0, C - 1,dir);
        }
        void qSort(int low, int high,bool dir)
        {
            if (low < high)
            {
                int p = part(low, high, dir);
                qSort(low, p - 1, dir);
                qSort(p + 1, high, dir);
            }
        }
        int part(int low, int high, bool dir)
        {
            T pivot = Niz[high];
            int i = low;
            for (int j = low + 1; j < high; j++)
            {
                if (dir && pivot > Niz[j])
                    swap(i++, j);
                if (!dir && pivot < Niz[j])
                    swap(i++, j);
            }
            swap(i, high);
            return i;
        }
        void swap(int i, int j) { T temp = Niz[i];Niz[i] = Niz[j];Niz[j] = temp; }

        public void print()
        {
            Console.WriteLine("Katalog ima " + C + "/" + N + " putovanja:");
            for (int i = 0; i < C; i++)
            {
                Console.WriteLine("++++++++++++++++++++++++++++++");
                Console.WriteLine((i + 1).ToString() + ". Putovanje:");
                Niz[i].print();
            }
        }
    }
}
