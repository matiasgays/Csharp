using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace ControlTemperatura
{
    public class Pais
    {
        public string pais { get; set; }
        public Dictionary<int, decimal> tempMensuales = new Dictionary<int, decimal>();

        public Pais() { }

        public static Pais InsertarPais()
        {
            Pais pais1 = new Pais();
            Console.WriteLine("Inserte un Pais");
            pais1.pais = Console.ReadLine();
            for (int i = 0; i < 12; i++) {
                Console.WriteLine($"Inserte la temperatura media del mes {i}");
                pais1.tempMensuales.Add(i, Convert.ToDecimal(Console.ReadLine()));
            }
            return pais1;
        }
    }
}
