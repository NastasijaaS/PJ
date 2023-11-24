using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Decembar_2018
{
    public enum SpecialOffer
    {
        FirstMinute = 0,
        LastMinute,
        Rest
    }
    public abstract class Putovanje
    {
        private String nd;      // naziv destinacije
        private DateTime dpp;   // datum pocetka putovanja
        private int t;          // trajanje putovanja  u danima
        private float od;       // ocena destinacije
        private float os;       // ocena smestaja
        private float op;       // ocena prevoza

        public String ND { get { return this.nd; } set { this.nd = value; } }
        public DateTime DPP { get { return this.dpp; } set { this.dpp = value; } }
        public int T { get { return this.t; } set { this.t = value; } }
        public float OD { get { return this.od; } set { this.od = value; } }
        public float OS { get { return this.os; } set { this.os = value; } }
        public float OP { get { return this.op; } set { this.op = value; } }

        public double O { get { return (OD + OS + OP) / 3; } }

        public SpecialOffer SP { get { return this.recOffer(); } }

        public Putovanje(String nd = "", int t = 0, float od = 1, float os = 1, float op = 1)
        {
            ND = nd;
            DPP = DateTime.Now;
            T = t;
            if (od < 1 || od > 10 || os < 1 || os > 10 || op < 1 || op > 10)
                throw new Exception("Greska pri unosu opsega ocene!");
            OD = od;
            OS = os;
            OP = op;
        }
        public Putovanje(Putovanje P)
        {
            ND = P.ND;
            DPP = P.DPP;
            T = P.T;
            OD = P.OD;
            OS = P.OS;
            OP = P.OP;
        }
        public void setDate(int y, int m, int d)
        { DPP = new DateTime(y, m, d); }
        private SpecialOffer recOffer()
        {
            TimeSpan value = DPP.Subtract(DateTime.Now);
            if (value.TotalDays >= 60)
                return SpecialOffer.FirstMinute;
            if (value.TotalDays <= 7)
                return SpecialOffer.LastMinute;
            return SpecialOffer.Rest;
        }

        public static bool operator <(Putovanje P1,Putovanje P2)
            {
            return P1.DPP < P2.DPP;
        }
        public static bool operator >(Putovanje P1, Putovanje P2)
        {
            return P1.DPP > P2.DPP;
        }

        public void upis(String link)
        {
            try
            {
                using (BinaryWriter bw = new BinaryWriter(new FileStream(link, FileMode.Create)))
                {
                    upis(bw);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured: " + e.Message);
            }
            
        }
        virtual public void upis(BinaryWriter bw)
        {
            bw.Write(ND);
            bw.Write(DPP.ToString());
            bw.Write(T);
            bw.Write(OD);
            bw.Write(OS);
            bw.Write(OP);
        }
        public void citaj(String link)
        {
            try
            {
                using (BinaryReader br = new BinaryReader(new FileStream(link, FileMode.Open)))
                {
                    citaj(br);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occured: " + e.Message);
            }
        }
        virtual public void citaj(BinaryReader br)
        {
            ND = br.ReadString();
            DPP = DateTime.Parse(br.ReadString());
            T = br.ReadInt32();
            float test = br.ReadSingle();
            if (test > 10 || test < 1)
                throw new Exception("Ocena destinacije je van dozvoljenog opsega!");
            OD = test;
            test = br.ReadSingle();
            if (test > 10 || test < 1)
                throw new Exception("Ocena smestaja je van dozvoljenog opsega!");
            OS = test;
            test = br.ReadSingle();
            if (test > 10 || test < 1)
                throw new Exception("Ocena putovanja je van dozvoljenog opsega!");
            OP = test;
        }
        virtual public void print()
        {
            Console.WriteLine("Naziv destinacije: " + ND);
            Console.WriteLine("Datum polaska: " + DPP.ToShortDateString());
            Console.WriteLine("Trajanje u danima: " + T);
            Console.WriteLine("Ocena destinacije: " + OD);
            Console.WriteLine("Ocena smestaja: " + OS);
            Console.WriteLine("Ocena putovanja: " + OP);
        }
    }
}
