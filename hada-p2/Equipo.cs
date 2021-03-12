using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hada
{
    class Equipo
    {
        #region Propiedades
        public static int minJugadores;
        public static int maxNumeroMovimientos;
        public int movimientos
        {
            get
            {
                return movimientos;
            }

            private set
            {
                movimientos = value;
            }
        }

        public string nombreEquipo
        {
            get
            {
                return nombreEquipo;
            }

            private set
            {
                nombreEquipo = value;
            }
        }

        private List<Jugador> jugadores;
        #endregion

        #region Constructor
        public Equipo(int nj, string nom)
        {
            this.nombreEquipo = nom;

            if (nj <= 0)
            {
                return;
            }

            this.jugadores = new List<Jugador>();

            for (int i = 0; i < nj; i++)
            {
                Console.Write("Introduce el nombre del {0}º jugador: ", i + 1);
                jugadores.Add(item: new Jugador(Console.ReadLine(), 0, 0, 50, 0));
            }
        }
        #endregion

        #region Funciones
        public bool moverJugadores()
        {
            if (!checkTeamStatus())
            {
                return false;
            }

            for(int i = 0; i < jugadores.Count; i++)
            {
                jugadores[i].mover();
                Console.WriteLine(jugadores[i].ToString());
            }

            if (!checkTeamStatus())
            {
                return false;
            }

            return true;
        }

        public void moverJugadoresEnBucle()
        {
            do
            {
                if (!checkTeamStatus())
                {
                    break;
                }

                moverJugadores();
            } while (true);
        }

        public int sumarPuntos()
        {
            int pointsCounter = 0;

            for(int i = 0; i < jugadores.Count; i++)
            {
                pointsCounter += jugadores[i].puntos;
            }

            return pointsCounter;
        }

        public List<Jugador> getJugadoresExcedenLimiteAmonestaciones()
        {
            List<Jugador> expulsados = new List<Jugador>();

            foreach(Jugador jugador in jugadores)
            {
                if(jugador.Amonestaciones > Jugador.maxAmonestaciones)
                {
                    expulsados.Add(jugador);
                }
            }

            return expulsados;
        }

        public List<Jugador> getJugadoresExcedenLimiteFaltas()
        {
            List<Jugador> lesionados = new List<Jugador>();

            foreach (Jugador jugador in jugadores)
            {
                if (jugador.Faltas > Jugador.maxFaltas)
                {
                    lesionados.Add(jugador);
                }
            }

            return lesionados;
        }

        List<Jugador> getJugadoresExcedenMinimoEnergia()
        {
            List<Jugador> retirados = new List<Jugador>();

            foreach (Jugador jugador in jugadores)
            {
                if (jugador.Energia > Jugador.minEnergia)
                {
                    retirados.Add(jugador);
                }
            }

            return retirados;
        }

        public override string ToString()
        {
            string text = $"[{nombreEquipo}] Puntos: {sumarPuntos()}; Expulsados: {getJugadoresExcedenLimiteAmonestaciones().Count}; Lesionados: {getJugadoresExcedenLimiteFaltas().Count}; Retirados: {getJugadoresExcedenMinimoEnergia().Count}\n";
            foreach(Jugador jugador in jugadores)
            {
                text += ($"{jugador.ToString()}\n");
            }
            return text;
        }

        private bool checkTeamStatus()
        {
            int playerAvailableCounter = 0;

            foreach (Jugador jugador in jugadores)
            {
                if (jugador.todoOk())
                {
                    playerAvailableCounter++;
                }
            }

            if (playerAvailableCounter < minJugadores)
            {
                return false;
            }

            return true;
        }

        private void cuandoAmonestacionesMaximoExcedido()
        {

        }

        private void cuandoFaltasMaximoExcedido()
        {

        }

        private void cuandoEnergiaMinimaExcedida()
        {

        }
        #endregion
    }
}
