using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Oktobar_II_2018
{
    public enum JedinicaMere
    {
        km_h,
        l_km,
        ND
    }
    public abstract class Vozilo
    {
        String nv;          // naziv vozila
        String rov;         // registarska oznaka vozila
        double kar;         // mkasimalna brzina km/h automobila, odnosno potrosnja goriva l/km kamiona
        JedinicaMere jm;    // jedinica mere (ujedno i tip)

        public String NV { get { return this.nv; } set { this.nv = value; } }
        public String ROV { get { return this.rov; } set { this.rov = value; } }
        public double KAR { get { return this.kar; } set { this.kar = value; } }
        public JedinicaMere JM { get { return this.jm; } set { this.jm = value; } }
        public int RTE
        {get { return testEmisije(); } }



        public Vozilo()
        { NV = ROV = "UNKNOWN"; KAR = 0; JM = JedinicaMere.ND; }
        public Vozilo(String nv, String rov, double kar, JedinicaMere jm)
        {
            NV = nv;
            ROV = rov;
            KAR = kar;
            JM = jm;
        }

        virtual public void upisi(StreamWriter sW)
        {
            sW.WriteLine(NV);
            sW.WriteLine(ROV);
            sW.WriteLine(KAR);
            sW.WriteLine(JM.ToString());
        }
        virtual public void citaj(StreamReader sR)
        {
            NV=sR.ReadLine();
            ROV = sR.ReadLine();
            KAR = int.Parse(sR.ReadLine());
            JM = (JedinicaMere)JedinicaMere.Parse(typeof(JedinicaMere), sR.ReadLine());
        }
        public void upisi(String lok,bool beautyMode=false)
        {
            try
            {
                using (StreamWriter sW = new StreamWriter(new FileStream(lok, FileMode.Create)))
                {
                    if (beautyMode)
                        upisiLepo(sW);
                    else
                        upisi(sW);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occurred: " + e.Message);
            }
        }

        virtual public void upisiLepo(StreamWriter sW)
        {
            sW.WriteLine("Naziv vozila: " + NV);
            sW.WriteLine("Registracijski broj: " + ROV);
            sW.WriteLine("Karakteristika: " + KAR + " " + JM.ToString());
        }

        public void citaj(String lok)
        {
            try
            {
                using (StreamReader sR=new StreamReader(new FileStream(lok, FileMode.Open)))
                    citaj(sR);
            }
            catch (Exception e)
            {
                Console.WriteLine("Error occurred: " + e.Message);
            }
        }

        abstract public bool uporedi(Vozilo v2); // iako to samo poredi kar, ali dobro.... neka bude apstraktna

        public int testEmisije() { Random rand = new Random(); return (int)(rand.NextDouble() * rand.Next(0, 200) * kar) % 200; }

        public static bool operator>(Vozilo v1,Vozilo v2)
        { return v1.uporedi(v2); }
        public static bool operator<(Vozilo v1,Vozilo v2)
        { return v2.uporedi(v1); }

        virtual public void print()
        {
            Console.WriteLine("Naziv vozila: " + NV);
            Console.WriteLine("Registracijski broj: " + ROV);
            Console.WriteLine("Karakteristika: " + KAR + " " + JM.ToString());
        }


    }
}
