using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace April_2018
{
    public class Student : IComparable
    {
        public String IME { get; set; }
        public String PREZ { get; set; }
        public int BP { get; set; }

        public Student() { IME = PREZ = ""; BP = 0; }
        public Student(String ime, String prezime, int bp) { IME = ime; PREZ = prezime; BP = bp; }
        public void upisiBIN(BinaryWriter bW)
        {
            bW.Write(IME);
            bW.Write(PREZ);
            bW.Write(BP);
        }
        public void citaj(BinaryReader bR)
        {
            IME = bR.ReadString();
            PREZ = bR.ReadString();
            BP = bR.ReadInt32();
            if (BP < 0)
                throw new Exception("Broj poena ne moze biti negativan broj!");
        }
        public void upisiTXT(StreamWriter sW)
        {
            sW.WriteLine("Ime: " + IME);
            sW.WriteLine("Prezime: " + PREZ);
            sW.WriteLine("Broj ostvarenih poena na takmicenju: " + BP);
        }

        public int GetHashCode(object obj)
        {
            throw new NotImplementedException();
        }

        public int CompareTo(object obj)
        {
            if (obj.GetType() == typeof(Student))
                return CompareTo((Student)obj);
            else
                throw new Exception("Wrong types!");
        }
        public int CompareTo(Student s)
        {
            if (BP > s.BP)
                return -1;
            if (BP < s.BP)
                return 1;
            return 0;
        }
    }
}
