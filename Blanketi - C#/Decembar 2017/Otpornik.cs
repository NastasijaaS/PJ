using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decembar_2017
{
    public class Otpornik : Komponenta
    {
        public override mernaJedinica MJ { get { return mernaJedinica.Om; } }
        public double MP { get; set; }

        public Otpornik(double mp, double kar, long sn) : base(kar, sn) { MP = mp; }
        public Otpornik() : base() { MP = 0; }

        public override void ucitaj(BinaryReader bR)
        {
            base.ucitaj(bR);
            MP = bR.ReadDouble();
        }
        public override void upisi(BinaryWriter bW)
        {
            base.upisi(bW);
            bW.Write(MP);
        }
        public override void upisiTXT(StreamWriter sW)
        {
            base.upisiTXT(sW);
            sW.WriteLine("Maksimalna dozvoljena snaga na otporniku: " + MP + " W");
        }
    }
}
