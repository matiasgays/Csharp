using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herencia_Interfaces
{
    class Program
    {
        static void Main(string[] args)
        {
            Ronaldo ronaldo = new(71,72,73,74,75,78);
            Messi messi = new(44, 54, 14, 24, 34, 84);

            ronaldo.regatear();
            ronaldo.rematar();
            ronaldo.defender();
            ronaldo.correr();
            ronaldo.soportarEmbate();
            ronaldo.colocarPase();
            messi.regatear();
            messi.rematar();
            messi.defender();
            messi.correr();
            messi.soportarEmbate();
            messi.colocarPase();

        }
    }
}
