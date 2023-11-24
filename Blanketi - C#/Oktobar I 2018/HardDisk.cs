using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oktobar_I_2018
{
    public class HardDisc : RacunarskaKomponenta
    {
        public int MO { get; set; }

        public HardDisc() :base(JedinicaMere.GB){ MO = 0; }
        public HardDisc(int mo, double kar, int sn) : base(JedinicaMere.GB, kar, sn) { MO = mo; }
        public override void ucitaj(BinaryReader bR)
        {
            base.ucitaj(bR);
            MO = bR.ReadInt32();
        }
        public override void upisi(BinaryWriter bW)
        {
            base.upisi(bW);
            bW.Write(MO);
        }
        public override void print()
        {
            base.print();
            Console.WriteLine("Maksimalni broj ortaja: " + MO);
        }
    }
}
