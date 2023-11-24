using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oktobar_2_2018
{
    class Kamion : Vozilo
    {
        int nosivost;

        public Kamion() : base()
        {
            nosivost = 0;
        }
        public Kamion(String naziv, String rg, double kar, int nosivost) : base(naziv,rg,kar,(JedinicaMere)1)
        {
            this.nosivost = nosivost;
        }

        public int Nosivost { get { return this.nosivost; } }
        public override void upisi(StreamWriter sw)
        {
            base.upisi(sw);
            sw.WriteLine(nosivost);
        }

        public override void citaj(StreamReader sr)
        {
            base.citaj(sr);
            nosivost = int.Parse(sr.ReadLine());
        }
        public override bool uporedi(Vozilo V2)
        {
            return this.KAR < V2.KAR;
        }
    }
}
