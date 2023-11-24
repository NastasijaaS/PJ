using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Januar_2018
{
    public enum tipStaze
    {
        ND,
        Duge,
        Srednje,
        Kratke
    }
    public class Trkac : Atleticar
    {
        public tipStaze TS { get; set; }
        public override jedinica JM { get { return jedinica.Sekund; } }

        public override bool bolji(Atleticar a)
        {
            if (this.GetType() != a.GetType())
                throw new Exception("TIpovi nisu kompatibilni za poredjenje!");
            return REZ < a.REZ;
        }
        public override void upisiBIN(BinaryWriter bW)
        {
            base.upisiBIN(bW);
            bW.Write(TS.ToString());
        }
        virtual public void upisiTXT(StreamWriter sW)
        {
            base.upisiTXT(sW);
            sW.WriteLine("Tip staze: " + TS);
        }
        public override void citaj(BinaryReader bR)
        {
            base.citaj(bR);
            TS = (tipStaze)tipStaze.Parse(typeof(tipStaze), bR.ReadString());
        }

        public Trkac() : base() { TS = 0; }
        public Trkac(String ime, String prezime, double rez, tipStaze ts) : base(ime, prezime, rez) { TS = ts; }
    }
}
