using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oktobar_I_2018
{
    public class Processor : RacunarskaKomponenta
    {
        public double SK { get; set; }

        public Processor() : base(JedinicaMere.GHz) { SK = 0; }
        public Processor(double sk, double kar, int sn) : base(JedinicaMere.GHz, kar, sn) { SK = sk; }
        public override void ucitaj(BinaryReader bR)
        {
            base.ucitaj(bR);
            SK = bR.ReadDouble();
        }
        public override void upisi(BinaryWriter bW)
        {
            base.upisi(bW);
            bW.Write(SK);
        }
        public override void print()
        {
            base.print();
            Console.WriteLine("Snaga: " + SK + " W");
        }
    }
}
