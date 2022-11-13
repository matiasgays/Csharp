using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace ControlTemperatura
{
    public class Paises
    {
        public List<Pais> paises;

        public Paises ()
        {
            paises = new List<Pais>();
        }

        public void ImprimirPaises(Pais[] paisesAImprimir)
        {
            TablePrinter t = new TablePrinter("Pais", "Mes", "Temp Media");
            foreach (Pais pais1 in paisesAImprimir)
            {
                t.AddRow(pais1.pais,"","");
                foreach ( var kvp in pais1.tempMensuales)
                {
                    t.AddRow("", kvp.Key, kvp.Value);
                }
            }
            t.Print();
        }

        public string MediaTrimestral( Pais[] paisesACalcular)
        {
            TablePrinter t = new TablePrinter("Pais", "Mes", "Media Trimestral");
            decimal mayorMediaTrimestal = 0;
            string paisMayorMediaTrimestral = "";
            foreach (Pais pais1 in paisesACalcular)
            {
                t.AddRow(pais1.pais, "", "");
                int trimestre = 3;
                int numTrimestre = 1;
                decimal tempTrimestral = 0;
                int count = 1;
                foreach (var kvp in pais1.tempMensuales)
                {
                    tempTrimestral += kvp.Value;
                    if (count % trimestre == 0)
                    {
                        decimal mediaTrimestal = tempTrimestral / trimestre;
                        if ( mediaTrimestal > mayorMediaTrimestal )
                        {
                            mayorMediaTrimestal = mediaTrimestal;
                            paisMayorMediaTrimestral = pais1.pais;
                        }
                        t.AddRow("", numTrimestre, mediaTrimestal);
                        numTrimestre++;
                        count = 1;
                        tempTrimestral = 0;
                    }
                    else
                    {
                        count++;
                    }
                }
            }
            t.Print();
            return paisMayorMediaTrimestral;
        }

    }
}
