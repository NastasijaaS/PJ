using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Oktobar_2_2018
{
    public enum JedinicaMere
    {
        KPH,
        LPK,
        ND
    }
    public abstract class Vozilo
    {
        String naziv;
        String rg;
        double kar;
        JedinicaMere tip;
        public double KAR { get { return this.kar; } set { this.kar = value; } }
        public JedinicaMere TIP { get { return this.tip; } }
        public String Naziv { get { return this.naziv; } }
        public String RG { get { return this.rg; } }


        public Vozilo()
        {
            naziv = rg = null;
            kar = 0;
            tip = JedinicaMere.ND;
        }

        public Vozilo(String naziv, String rg, double kar, JedinicaMere tip)
        {
            this.naziv = naziv;
            this.rg = rg;
            this.kar = kar;
            this.tip = tip;
        }

        virtual public void upisi(StreamWriter sw)
        {
            sw.WriteLine(naziv);
            sw.WriteLine(rg);
            sw.WriteLine(kar);
            sw.WriteLine(tip.ToString());
        }

        virtual public void citaj(StreamReader sr)
        {
            naziv = sr.ReadLine();
            rg = sr.ReadLine();
            kar = int.Parse(sr.ReadLine());
            tip = (JedinicaMere)JedinicaMere.Parse(typeof(JedinicaMere), sr.ReadLine());
        }

        abstract public bool uporedi(Vozilo V2);

        public double testEmisije()
        {
            Random rand = new Random();
            return (int)(rand.NextDouble() * rand.Next(0, 200) * kar) % 200;
        }
    }
}
