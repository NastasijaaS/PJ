using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decembar_2017
{
    public enum mernaJedinica
    {
        ND, Om, Farad
    }
    public abstract class Komponenta
    {
        public double KAR { get; set; }
        public abstract mernaJedinica MJ { get; }
        public long SN { get; set; }

        public Komponenta() { KAR = SN = 0; }
        public Komponenta(double kar, long sn) { KAR = kar; SN = sn; }
        virtual public void upisi(BinaryWriter bW)
        {
            bW.Write(KAR);
            bW.Write(SN);
        }
        virtual public void ucitaj(BinaryReader bR)
        {
            KAR = bR.ReadDouble();
            SN = bR.ReadInt64();
        }

        public double nom(double nv)
        {
            if (nv == 0)
                throw new Exception("Can't divide by zero!"); // vec postoji u skopu /, ali sto da ne
            return Math.Abs((nv - KAR) / nv);
        }
        virtual public void upisiTXT(StreamWriter sW)
        {
            sW.WriteLine("Karakteristika: " + KAR + " " + MJ.ToString());
            sW.WriteLine("S/N: " + SN);
        }
    }
}
