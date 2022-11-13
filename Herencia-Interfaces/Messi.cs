using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herencia_Interfaces
{
    public class Messi : Jugador, IJugador
    {
        public Messi(int velocidad, int tiro, int regate, int defensa, int pase, int fisico) : base(velocidad, tiro, regate, defensa, pase, fisico)
        {

        }

        public void colocarPase()
        {
            Console.WriteLine($"Messi tiene un regate de {Pase}");
        }

        public void correr()
        {
            Console.WriteLine($"Messi tiene un regate de {Velocidad}");
        }

        public void defender()
        {
            Console.WriteLine($"Messi tiene un regate de {Defensa}");
        }

        public void regatear()
        {
            Console.WriteLine($"Messi tiene un regate de {Regate}");
        }

        public void rematar()
        {
            Console.WriteLine($"Messi tiene un regate de {Tiro}");
        }

        public void soportarEmbate()
        {
            Console.WriteLine($"Messi tiene un regate de {Fisico}");
        }
    }
}
