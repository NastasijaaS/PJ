using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jun_2018
{
    public class Napadac : Fudbaler
    {
        public override UcinakF TIP { get; set; }
        public int BM { get; set; }

        public Napadac() : base() { TIP = UcinakF.BrojGolova; BM = 0; }
        public Napadac(int bm, int uf, String ime, String prez) : base(uf, ime, prez) { TIP = UcinakF.BrojGolova; BM = bm; }

        override public void upisi(StreamWriter sW)
        {
            base.upisi(sW);
            sW.WriteLine(BM);
        }
        override public void ucitaj(StreamReader sR)
        {
            base.ucitaj(sR);
            BM = int.Parse(sR.ReadLine());
        }
        override public void print()
        {
            base.print();
            Console.WriteLine("Broj minuta koliko napadac moze da izdrzi u igri: " + BM);
        }
    }
}
