using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decembar_2018
{
    public class Zimovanje
        :Putovanje
    {
        private float oss;      // ocena ski staza na zimovanju

        public float OSS
        {
            get { return this.oss; }
            set { this.oss = value; }
        }

        public Zimovanje()
            :base(){ OSS = 1; }

        public Zimovanje(float oss=1f, String naziv = "", int t = 0, float od = 1f, float os = 1f, float op = 1f)
            : base(naziv, t, od, os, op)
        {
            if (oss < 1 || oss > 10)
                throw new Exception("Ocena ski staza zimovanja je van opsega!");
            OSS = oss;
        }
        public Zimovanje(Zimovanje Z)
            : base(Z)
        {
                OSS = Z.OSS;
        }

        public override void citaj(BinaryReader br)
        {
            base.citaj(br);
            float test = br.ReadSingle();
            if(test<1 || test>10)
                throw new Exception("Ocena ski staza zimovanja je van opsega!");
            OSS = test;
        }

        public override void upis(BinaryWriter bw)
        {
            base.upis(bw);
            bw.Write(OSS);
        }
        public override void print()
        {
            base.print();
            Console.WriteLine("Ocena ski staza na zimovanju: " + OSS);
        }
    }
}
