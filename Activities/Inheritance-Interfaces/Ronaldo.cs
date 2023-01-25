using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herencia_Interfaces
{
    public class Ronaldo : Jugador, IJugador
    {
        public Ronaldo (int velocidad, int tiro, int regate, int defensa, int pase, int fisico) : base (velocidad, tiro, regate, defensa, pase, fisico)
        {

        }

        public void correr()
        {
            Console.WriteLine($"Ronaldo tiene un regate de {Velocidad}");
        }

        public void defender()
        {
            Console.WriteLine($"Ronaldo tiene un regate de {Defensa}");
        }

        public void regatear()
        {
            Console.WriteLine($"Ronaldo tiene un regate de {Regate}");
        }

        public void rematar()
        {
            Console.WriteLine($"Ronaldo tiene un regate de {Tiro}");
        }

        public void soportarEmbate()
        {
            Console.WriteLine($"Ronaldo tiene un regate de {Fisico}");
        }

        public void colocarPase()
        {
            Console.WriteLine($"Ronaldo tiene un regate de {Pase}");
        }
    }
}
