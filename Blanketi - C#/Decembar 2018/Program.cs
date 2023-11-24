using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decembar_2018
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Katalog<Letovanje> kL = new Katalog<Letovanje>(5);
                Katalog<Zimovanje> kZ = new Katalog<Zimovanje>(10);

                kL.addTo(new Letovanje(2.3f,4.3f,"Nemam pojma",5,4.6f,7.6f,5.7f));
                kL.addTo(new Letovanje(7.6f,6.7f,"Nemam blage veze",10,6.8f,8.3f,6.5f));
                kL.addTo(new Letovanje(5.6f,7.8f,"Nemam najblazije veze",15,6.7f,5.9f,4.6f));
                kL.addTo(new Letovanje(6.7f, 9.5f, "JBG VISE", 12, 7.8f, 4.3f, 5.6f));

                kL.print();
                kL.sort();
                kL.upis("Input.bin");
                Katalog<Letovanje> kLcopy = new Katalog<Letovanje>();
                kLcopy.citaj("Input.bin");

                Console.WriteLine("\n\nKopija:\n\n");
                kLcopy.print();
            }
            catch (Exception e)
            { Console.WriteLine("Error occurred: " + e.Message); }
            
        }
    }
}
