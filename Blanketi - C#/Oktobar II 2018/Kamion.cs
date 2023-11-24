using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oktobar_II_2018
{
    public class Kamion : Vozilo
    {
        double nK;

        public double NK { get { return this.nK; } set { this.nK = value; } }

        public Kamion()
            : base() { NK = 0; }
        public Kamion(double nK, String nv, String rov, double kar)
            : base(nv, rov, kar, (JedinicaMere)1) { NK = nK; }

        override public bool uporedi(Vozilo v2)
        {
            return this.KAR < v2.KAR;
        }

        override public void upisi(StreamWriter sW)
        {
            base.upisi(sW);
            sW.WriteLine(NK);
        }
        override public void citaj(StreamReader sR)
        {
            base.citaj(sR);
            NK = double.Parse(sR.ReadLine());
        }

        override public void upisiLepo(StreamWriter sW)
        {
            base.upisiLepo(sW);
            sW.WriteLine("Nosivost kamiona: " + NK + " tona.");
        }
        public override void print()
        {
            base.print();
            Console.WriteLine("Nosivost kamiona: " + NK + " tona.");
        }
    }
}
