using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace April_2018
{
    public class Fakultet
    {
        List<EkipaN> listaN;
        List<EkipaS> listaS;

        public int BP { get { return totalpoints(); } }
        public String Naziv { get; set; }

        public Fakultet() { Naziv = ""; listaN = new List<EkipaN>(); listaS = new List<EkipaS>(); }
        public Fakultet(String naziv) { Naziv = naziv; listaN = new List<EkipaN>(); listaS = new List<EkipaS>(); }

        private int totalpoints()
        {
            int ret = 0;
            foreach (EkipaN n in listaN)
                ret += n.BP;
            foreach (EkipaS s in listaS)
                ret += s.BP;
            return ret;
        }
        public void upisiBIN(String pathF, String pathN, String pathS)
        {
            try
            {
                using (BinaryWriter bW = new BinaryWriter(new FileStream(pathF, FileMode.Create)))
                { bW.Write(Naziv); }

                using (BinaryWriter bW = new BinaryWriter(new FileStream(pathN, FileMode.Create)))
                {
                    bW.Write(listaN.Count);
                    foreach (EkipaN n in listaN)
                        n.upisiBIN(bW);
                }
                using (BinaryWriter bW = new BinaryWriter(new FileStream(pathS, FileMode.Create)))
                {
                    bW.Write(listaS.Count);
                    foreach (EkipaS s in listaS)
                        s.upisiBIN(bW);
                }
            }
            catch (Exception e)
            { Console.WriteLine("Error occurred: " + e.Message); }
        }
        public void ucitaj(String pathF, String pathN, String pathS)
        {
            try
            {
                using (BinaryReader bR = new BinaryReader(new FileStream(pathF, FileMode.Open)))
                { Naziv = bR.ReadString(); }
                int c;
                using (BinaryReader bR = new BinaryReader(new FileStream(pathN, FileMode.Open)))
                {
                    c = bR.ReadInt32();
                    listaN = new List<EkipaN>(c);
                    EkipaN n;
                    for (int i = 0; i < c; i++)
                    {
                        (n = new EkipaN()).ucitaj(bR);
                        listaN.Add(n);
                    }
                }
                using (BinaryReader bR = new BinaryReader(new FileStream(pathS, FileMode.Open)))
                {
                    c = bR.ReadInt32();
                    listaS = new List<EkipaS>(c);
                    EkipaS s;
                    for (int i = 0; i < c; i++)
                    {
                        (s = new EkipaS()).ucitaj(bR);
                        listaS.Add(s);
                    }
                }
            }
            catch (Exception e)
            { Console.WriteLine("Error occurred: " + e.Message); }
        }
        public void upisiTXT(String path)
        {
            try
            {
                sortN();
                sortS();
                using (StreamWriter sW = new StreamWriter(new FileStream(path, FileMode.Create)))
                {
                    sW.WriteLine("Naziv fakulteta: " + Naziv);
                    sW.WriteLine("Fakultet ima " + listaN.Count + " naucne ekipe:");
                    int i = 1;
                    foreach (EkipaN n in listaN)
                    {
                        sW.WriteLine((i++) + ". Ekipa:");
                        n.upisiTXT(sW);
                    }
                    sW.WriteLine("Fakultet ima " + listaS.Count + " sportske ekipe:");
                    i = 1;
                    foreach (EkipaS s in listaS)
                    {
                        sW.WriteLine((i++) + ". Ekipa:");
                        s.upisiTXT(sW);
                    }
                }
            }
            catch (Exception e)
            { Console.WriteLine("Error occurred: " + e.Message); }
        }
        public void add(IEkipa e)
        {
            if (e.GetType() == typeof(EkipaN))
                listaN.Add((EkipaN)e);
            else
            {
                if (e.GetType() == typeof(EkipaS))
                    listaS.Add((EkipaS)e);
                else
                    throw new Exception("What did you try to put in!?");
            }
        }
        public void sortN() { listaN.Sort(); } // dovidjenja
        public void sortS() { listaS.Sort(); } // prijatno
    }
}
