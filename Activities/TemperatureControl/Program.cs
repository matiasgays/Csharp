using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace ControlTemperatura
{
    class Program
    {
        private static int i;

        static void Main(string[] args)
        {
            Paises listaPaises = new Paises();
            Pais[] paises = new Pais[3];
            for (i = 0; i < paises.Length; i++)
            {
                paises[i] = Pais.InsertarPais();
            };
            listaPaises.ImprimirPaises(paises);
            string paisMayorTemperatura = listaPaises.MediaTrimestral(paises);
            Console.WriteLine($"El pais con mayor temperatura trimestarl es {paisMayorTemperatura}");
        }
    }
}
