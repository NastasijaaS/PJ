using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oktobar_2_2018
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                VozniPark<Automobil> VP1 = new VozniPark<Automobil>(50, 100);
                VozniPark<Kamion> VP2 = new VozniPark<Kamion>(20, 150);
                VP1.citaj("automobili.txt");
                VP2.citaj("kamioni.txt");
                VP1.izbaciOpasne();
                VP2.izbaciOpasne();
                VP1.sort();
                VP2.sort();
                VP1.upisi("automobili_izlaz.txt");
                VP2.upisi("kamioni_izlaz.txt");
            }
            catch (Exception e) {
                Console.WriteLine("Error:" + e.Message);
            }
        }
    }
}
