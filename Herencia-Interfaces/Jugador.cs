using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herencia_Interfaces
{
    public abstract class Jugador
    {
        public int Velocidad { get; set; }
        public int Tiro { get; set; }
        public int Regate { get; set; }
        public int Defensa { get; set; }
        public int Pase { get; set; }
        public int Fisico { get; set; }

        public Jugador (int velocidad, int tiro, int regate, int defensa, int pase, int fisico)
        {
            Velocidad = velocidad;
            Tiro = tiro;
            Regate = regate;
            Defensa = defensa;
            Pase = pase;
            Fisico = fisico;
        }
    }
}
