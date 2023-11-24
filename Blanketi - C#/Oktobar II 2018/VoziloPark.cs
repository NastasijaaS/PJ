using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Oktobar_II_2018
{
    public class VoziloPark<T> where T:Vozilo,new()
    {
        int n;
        int c;
        T[] niz;
        int deig;

        public int N { get { return this.n; } set { this.n = value; } }
        public int C { get { return this.c; } set { this.c = value; } }
        public T[] NIZ { get { return this.niz; } set { this.niz = value; } }
        public T this[int i] { get { return this.niz[i]; } set { this.niz[i] = value; } }
        public int DEIG { get { return this.deig; } set { this.deig = value; } }

        public VoziloPark(int n = 0)
        { N = n;C = 0;NIZ = new T[N]; }
        public void add(T el)
        {
            if (C >= N)
                throw new Exception("Park je pun!");
            NIZ[C++] = el;
        }
        public void upisi(String path,bool beautyMode=false)
        {
            try
            {
                using (StreamWriter sW = new StreamWriter(new FileStream(path, FileMode.Create)))
                {
                    if (beautyMode)
                    {
                        sW.WriteLine("U parku ima: " + C + "/" + N + " vozila.");
                        sW.WriteLine("Dozvoljena emisija izduvnih gasova: " + DEIG);
                        for (int i = 0; i < C; i++)
                            NIZ[i].upisiLepo(sW);
                    }
                    else
                    {
                        sW.WriteLine(N);
                        sW.WriteLine(C);
                        sW.WriteLine(DEIG);
                        for (int i = 0; i < C; i++)
                            NIZ[i].upisi(sW);
                    }
                }
            }
            catch (Exception e)
            { Console.WriteLine("Error occurred: " + e.Message); }
        }

        public void citaj(String path)
        {
            try
            {
                using (StreamReader sR = new StreamReader(new FileStream(path, FileMode.Open)))
                {
                    N = int.Parse(sR.ReadLine());
                    C = int.Parse(sR.ReadLine());
                    DEIG = int.Parse(sR.ReadLine());
                    NIZ = new T[N];
                    for (int i = 0; i < c; i++)
                    {
                        NIZ[i] = new T();
                        NIZ[i].citaj(sR);
                    }
                }
            }
            catch (Exception e)
            { Console.WriteLine("Error occurred: " + e.Message); }
        }
        public void removeDangerous()
        {
            for (int i = 0; i < C; i++)
            {
                if (DEIG < NIZ[i].RTE)
                {
                    shiftLeft(i--);
                    C--;
                }
            }
        }
        public void shiftLeft(int i)
        { for (int j = i; j < C - 1; j ++) NIZ[j] = NIZ[j + 1]; }

        public void sort(bool dir=true) { qSort(0, C - 1, dir);}

        private void qSort(int v1, int v2, bool dir)
        {
            if (v1 < v2)
            {
                int p = part(v1, v2, dir);
                qSort(v1, p - 1, dir);
                qSort(p + 1, v2, dir);
            }
        }
        private int part(int v1, int v2, bool dir)
        {
            T pivot = NIZ[v2];
            int i = v1;
            for (int j = v1; j < v2; j++)
            {
                if (dir && NIZ[j] > pivot)
                    swap(i++, j);
                if (!dir && NIZ[j] < pivot)
                    swap(i++, j);
            }
            swap(i, v2);
            return i;
        }
        private void swap(int i, int j)
        {
            T temp = NIZ[i];NIZ[i] = NIZ[j];NIZ[j] = temp;
        }

        public void print()
        {
            Console.WriteLine("U parku ima: " + C + "/" + N + " vozila.");
            Console.WriteLine("Dozvoljena emisija izduvnih gasova: " + DEIG);
            for (int i = 0; i < C; i++)
                NIZ[i].print(); 
        }
    }
}
