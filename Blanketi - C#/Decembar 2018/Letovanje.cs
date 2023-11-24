using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Decembar_2018
{
    public class Letovanje
        : Putovanje
    {
        private float opl;      // Ocene plaza na letovanju
        private float ods;      // Ocene dodatnih sadrzaja na letovanju

        public float OPL
        {
            get { return this.opl; }
            set { this.opl = value; }
        }
        public float ODS
        {
            get { return this.ods; }
            set { this.ods = value; }
        }

        public Letovanje()
            : base() { OPL = 1;ODS = 1; }
        public Letovanje(float opl = 1f, float ods = 1f, String naziv = "", int t = 0, float od = 1f, float os = 1f, float op = 1f)
            :base(naziv,t,od,os,op)
        {
            if (opl < 1 || opl > 10 || ods < 1 || ods > 10)
                throw new Exception("Ocena van opsega!");
            OPL = opl;
            ODS = ods;
        }
        public Letovanje(Letovanje L)
            : base(L)
        {
            OPL = L.OPL;
            ODS = L.ODS;
        }

        public override void citaj(BinaryReader br)
        {
            base.citaj(br);
            float test = br.ReadSingle();
            if (test < 1 || test > 10)
                throw new Exception("Ocena plaza na letovanju je van dozvoljenog opsega!");
            OPL = test;
            test = br.ReadSingle();
            if (test < 1 || test > 10)
                throw new Exception("Ocena plaza na letovanju je van dozvoljenog opsega!");
            ODS = test;
        }

        public override void upis(BinaryWriter bw)
        {
            base.upis(bw);
            bw.Write(OPL);
            bw.Write(ODS);
        }
        public override void print()
        {
            base.print();
            Console.WriteLine("Ocena plaza na letovanju: " + OPL);
            Console.WriteLine("Ocena dodatnih sadrzaja letovanja: " + ODS);
        }
    }
}
