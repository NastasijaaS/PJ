using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Januar_2018
{
    public enum jedinica
    {
        ND,
        Metar,
        Sekund
    }
    public abstract class Atleticar
    {
        public static Random rand = new Random(); // samo da se ne bi davao iste rezultate u RDP
        public double REZ { get; set; }
        public abstract jedinica JM { get; }
        public String IME { get; set; }
        public String PREZ { get; set; }
        abstract public bool bolji(Atleticar a);
        public double RDP { get { return rand.NextDouble(); } }


        public Atleticar() { REZ = 0; IME = PREZ = ""; }
        public Atleticar(String ime, String prez, double rez) { IME = ime; PREZ = prez; REZ = rez; }

        virtual public void upisiBIN(BinaryWriter bW)
        {
            bW.Write(IME);
            bW.Write(PREZ);
            bW.Write(REZ);
            //bW.Write(JM.ToString()); // zapravo nije neophodno
        }
        virtual public void upisiTXT(StreamWriter sW)
        {
            sW.WriteLine("Ime: " + IME);
            sW.WriteLine("Prezime: " + PREZ);
            sW.WriteLine("Rezultat: " + REZ + " " + JM.ToString());
        }
        virtual public void citaj(BinaryReader bR)
        {
            IME = bR.ReadString();
            PREZ = bR.ReadString();
            REZ = bR.ReadDouble();
            //JM = (jedinica)jedinica.Parse(typeof(jedinica), bR.ReadString()); // totalno nije neophodno, odgovarajuci konst to moze sam da postavi
        }

    }
}
