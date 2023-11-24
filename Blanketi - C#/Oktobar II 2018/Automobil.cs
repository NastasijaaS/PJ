using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oktobar_II_2018
{
    public enum tipAuta
    {
        MaliGradski=0,
        Porodicni,
        Luksuzni
    }
    public class Automobil
        :Vozilo
    {
        tipAuta tA;


        public Automobil()
            :base() { TA = 0; }
        public Automobil(tipAuta tA, String nv, String rov, double kar)
            : base(nv, rov, kar, 0) { TA = tA; }

        public tipAuta TA
        {
            get { return this.tA; }
            set { this.tA = value; }
        }

        override public bool uporedi(Vozilo v2)
        {
            return this.KAR > v2.KAR;
        }

        override public void upisi(StreamWriter sW)
        {
            base.upisi(sW);
            sW.WriteLine(TA.ToString());
        }
        override public void citaj(StreamReader sR)
        {
            base.citaj(sR);
            TA = (tipAuta)tipAuta.Parse(typeof(tipAuta), sR.ReadLine());
        }
        override public void upisiLepo(StreamWriter sW)
        {
            base.upisiLepo(sW);
            sW.WriteLine("Tip Auta: " + TA.ToString());
        }
        public override void print()
        {
            base.print();
            Console.WriteLine("Tip Auta: " + TA.ToString());
        }
    }
}
