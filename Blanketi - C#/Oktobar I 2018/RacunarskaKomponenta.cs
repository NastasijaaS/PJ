using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Oktobar_I_2018
{
    public enum JedinicaMere
    {
        ND = 0,
        GHz,
        GB
    }
    public abstract class RacunarskaKomponenta
    {
        public double KAR { get; set; }
        public JedinicaMere JM { get; set; }
        public int SN { get; set; }

        public RacunarskaKomponenta(JedinicaMere jm=0) { KAR = SN = 0; JM = jm; }
        public RacunarskaKomponenta(JedinicaMere jm, double kar, int sn)
        { KAR = kar; JM = jm; SN = sn; }
        virtual public void ucitaj(BinaryReader bR)
        {
            KAR = bR.ReadDouble();
            JM = (JedinicaMere)JedinicaMere.Parse(typeof(JedinicaMere), bR.ReadString());
            SN = bR.ReadInt32();
        }
       virtual public void upisi(BinaryWriter bW)
        {
            bW.Write(KAR);
            bW.Write(JM.ToString());
            bW.Write(SN);
        }

        public double nomKar(double nom)
        {
            if (nom == 0)
                throw new Exception("Cannot divide by zero!");
            return (nom - KAR) / nom;
        }
        virtual public void print()
        {
            Console.WriteLine("Karakteristika: " + KAR + " " + JM.ToString());
            Console.WriteLine("S/N: " + SN);
        }
    }
}
