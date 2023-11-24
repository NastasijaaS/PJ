using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oktobar_2_2018
{
    public class VozniPark<T> where T : Vozilo, new()
    {
        int br;
        int max;
        T[] niz;
        int deig;

        public VozniPark(int n, int deig)
        {
            max = n;
            br = 0;
            niz = new T[n];
            this.deig = deig;
        }

        public int DEIG { get { return this.deig; } set { this.deig = value; } }

        public void add(T el)
        {
            if (br >= max) throw new Exception("Vozni park je pun!");
            niz[br++] = el;
        }

        public void upisi(String path)
        {
            StreamWriter sw = new StreamWriter(new FileStream(path, FileMode.Create));
            sw.WriteLine(br);
            sw.WriteLine(max);
            sw.WriteLine(deig);
            for (int i = 0; i < br; i++)
                niz[i].upisi(sw);
            sw.Close();
        }
        public void citaj(String path)
        {
            StreamReader sr = new StreamReader(new FileStream(path, FileMode.Open));
            br = int.Parse(sr.ReadLine());
            max = int.Parse(sr.ReadLine());
            deig = int.Parse(sr.ReadLine());
            niz = new T[max];
            for (int i = 0; i < br; i++)
            {
                niz[i] = new T();
                niz[i].citaj(sr);
            }
            sr.Close();
        }

        public void izbaciOpasne()
        {
            for (int i = 0; i < br; i++)
                if (niz[i].testEmisije() > deig)
                {
                    for (int j = i--; j < br - 1; j++)
                        niz[j] = niz[j + 1];
                    br--;
                }
        }
        public void sort()
        {
            for (int i = 0; i < br - 1; i++)
                for (int j = i + 1; j < br; j++)
                    if (!niz[i].uporedi(niz[j]))
                    {
                        T temp;
                        temp = niz[i];
                        niz[i] = niz[j];
                        niz[j] = temp;
                    }
        }
    }
}
