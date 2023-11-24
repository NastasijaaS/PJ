using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jun_2018
{
    public class Golman : Fudbaler
    {
        public override UcinakF TIP { get; set; }
        public bool DB { get; set; }

        public Golman() : base() { TIP = UcinakF.ProcenatOdbrana; DB = false; }
        public Golman(bool db, double uf, String ime, String prez) : base(uf, ime, prez) { TIP = UcinakF.ProcenatOdbrana; DB = db; }

        override public void upisi(StreamWriter sW)
        {
            base.upisi(sW);
            sW.WriteLine(DB);
        }
        override public void ucitaj(StreamReader sR)
        {
            base.ucitaj(sR);
            DB = bool.Parse(sR.ReadLine());
        }
        override public void print()
        {
            base.print();
            Console.WriteLine("Golman dobro brani penale: " + (DB ? "TACNO" : "NETACNO"));
        }
    }
}
