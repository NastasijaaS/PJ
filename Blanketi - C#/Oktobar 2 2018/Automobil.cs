using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oktobar_2_2018
{
    public enum Auto
    {
        MaliGradski=0,
        Porodicni,
        Luksuzni
    }
    class Automobil : Vozilo
    {
        Auto kategorija;
        
        public Automobil() : base()
        {
            kategorija = 0;
        }

        public Automobil(String naziv, String rg, double kar, Auto kategorija) : base(naziv, rg, kar , (JedinicaMere)0)
        {
            this.kategorija = kategorija;
        }

        public Auto Kategorija { get { return this.kategorija; } }
        
        override public void upisi(StreamWriter sw)
        {
            base.upisi(sw);
            sw.WriteLine(kategorija.ToString());
        }

        public override void citaj(StreamReader sr)
        {
            base.citaj(sr);
            kategorija = (Auto)(Auto.Parse(typeof(Auto), sr.ReadLine()));
        }
        public override bool uporedi(Vozilo V2)
        {
            return (this.KAR > V2.KAR);
        }


    }
}
