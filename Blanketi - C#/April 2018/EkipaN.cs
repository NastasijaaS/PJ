using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace April_2018
{
    public class EkipaN : IEkipa
    {
        List<Student> lista;
        public int BP { get { return points(); } }
        public Disciplina D { get; set; }

        public EkipaN() { lista = new List<Student>(); D = 0; }
        public EkipaN(Disciplina d) { lista = new List<Student>(); D = d; }
        public void add(Student s) { lista.Add(s); }
        public int points()
        {
            int ret = 0;
            lista.Sort();
            for (int i = lista.Count - 1; i >= (lista.Count > 3 ? lista.Count - 3 : 0); i--)
                ret += lista[i].BP;
            return ret;
        }
        public void ucitaj(BinaryReader bR)
        {
            int c = bR.ReadInt32();
            D = (Disciplina)Disciplina.Parse(typeof(Disciplina), bR.ReadString());
            lista = new List<Student>(c);
            Student s;
            for (int i = 0; i < c; i++)
            {
                (s = new Student()).citaj(bR);
                lista.Add(s);
            }
        }

        public void upisiBIN(BinaryWriter bW)
        {
            bW.Write(lista.Count);
            bW.Write(D.ToString());
            foreach (Student s in lista)
                s.upisiBIN(bW);
        }

        public void upisiTXT(StreamWriter sW)
        {
            sW.WriteLine("Ekipa se takmici u disciplini " + D.ToString() + " i ima " + lista.Count + " naucnika:");
            foreach (Student s in lista)
                s.upisiTXT(sW);
        }

        public int CompareTo(object obj)
        {
            if (obj.GetType() != typeof(EkipaN))
                throw new Exception("Wrong type!");
            return Compare((EkipaN)obj);
        }
        public int Compare(EkipaN other)
        {
            if (BP > other.BP)
                return -1;
            if (BP < other.BP)
                return 1;
            return 0;
        }
    }
}
