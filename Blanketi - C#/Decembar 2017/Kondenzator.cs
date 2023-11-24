using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decembar_2017
{
    public class Kondenzator : Komponenta
    {
        public override mernaJedinica MJ { get { return mernaJedinica.Farad; } }
        public double MV { get; set; }

        public Kondenzator(double mv, double kar, long sn) : base(kar, sn) { MV = mv; }
        public Kondenzator() : base() { MV = 0; }

        public override void ucitaj(BinaryReader bR)
        {
            base.ucitaj(bR);
            MV = bR.ReadDouble();
        }
        public override void upisi(BinaryWriter bW)
        {
            base.upisi(bW);
            bW.Write(MV);
        }
        public override void upisiTXT(StreamWriter sW)
        {
            base.upisiTXT(sW);
            sW.WriteLine("Maksimalni napon: " + MV + " V");
        }
    }
}
