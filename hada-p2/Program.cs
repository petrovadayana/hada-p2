using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hada
{
    class Program
    {
        static void Main(string[] args)
        {
            Equipo equipoLocal = getTeam("local");
            Equipo equipoVisitante = getTeam("visitante");

            equipoLocal.moverJugadoresEnBucle();
            equipoVisitante.moverJugadoresEnBucle();

            // Si tuviera más tiempo pondría un condicional para decidir quien gana, etc.
        }

        private static Equipo getTeam(string estado)
        {
            Console.Write($"Introduce el número máximo de jugadores del equipo {estado}: ");
            int jugadores = int.Parse(Console.ReadLine());

            Console.Write($"Introduce el nombre del equipo {estado}: ");
            string nombre = Console.ReadLine();
            return new Equipo(jugadores, nombre);
        }
    }
}
