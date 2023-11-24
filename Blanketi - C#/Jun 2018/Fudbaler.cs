using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jun_2018
{
    public enum UcinakF
    {
        ND,
        BrojGolova,
        ProcenatOdbrana
    }
    public abstract class Fudbaler
    {
        public double UF { get; set; }
        public abstract UcinakF TIP { get; set; }
        public String IME { get; set; }
        public String PREZ { get; set; }

        public Fudbaler() { UF = 0; IME = PREZ = ""; }
        public Fudbaler(double uf/*Za napadaca je int*/, String ime, String prez) { UF = uf; IME = ime; PREZ = prez; }

        virtual public void upisi(StreamWriter sW)
        {
            sW.WriteLine(IME);
            sW.WriteLine(PREZ);
            sW.WriteLine(UF);
        }
        virtual public void ucitaj(StreamReader sR)
        {
            IME = sR.ReadLine();
            PREZ = sR.ReadLine();
            UF = double.Parse(sR.ReadLine());
        }
        public double ocekivanaNorma(double norma)
        {
            if (norma == 0)
                throw new Exception("Can't divide by zero!");
            return UF / norma;
        }
        virtual public void print()
        {
            Console.WriteLine("Ime: " + IME);
            Console.WriteLine("Prezime: " + PREZ);
            Console.WriteLine("Ucinak Fudbalera: " + UF + " " + TIP.ToString());
        }
    }
}
