using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Januar_2018
{
    public enum tipSkoka
    {
        ND,
        Uvis,
        Udalj
    }
    public class Skakac : Atleticar
    {
        public tipSkoka TS { get; set; }
        public override jedinica JM { get { return jedinica.Metar; } }

        public override bool bolji(Atleticar a)
        {
            if (this.GetType() != a.GetType())
                throw new Exception("TIpovi nisu kompatibilni za poredjenje!");
            return REZ > a.REZ;
        }
        public override void upisiBIN(BinaryWriter bW)
        {
            base.upisiBIN(bW);
            bW.Write(TS.ToString());
        }
        virtual public void upisiTXT(StreamWriter sW)
        {
            base.upisiTXT(sW);
            sW.WriteLine("Tip skoka: " + TS);
        }
        public override void citaj(BinaryReader bR)
        {
            base.citaj(bR);
            TS = (tipSkoka)tipSkoka.Parse(typeof(tipSkoka), bR.ReadString());
        }

        public Skakac() : base() { TS = 0; }
        public Skakac(String ime, String prezime, double rez, tipSkoka ts) : base(ime, prezime, rez) { TS = ts; }
    }
}
