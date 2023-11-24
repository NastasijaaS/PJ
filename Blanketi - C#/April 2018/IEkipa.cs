using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace April_2018
{
    public enum Disciplina
    {
        ND,
        Matematika,
        Informatika,
        ObjektnoOrijantisanoProgramiranje,
        MuskiFudbal,
        ZenskiFudbal,
        MuskaKosarka,
        ZenskaKosarka,
        Sah
    }
    public interface IEkipa:IComparable
    {
        int BP { get; }
        Disciplina D { get; set; }
        void upisiBIN(BinaryWriter bW);
        void ucitaj(BinaryReader bR);
        void upisiTXT(StreamWriter sW);
        void add(Student s);
        int points();
    }
}
