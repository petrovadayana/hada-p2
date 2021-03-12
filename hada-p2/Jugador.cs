using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hada
{
    class Jugador
    {
        #region Propiedades
        public static int maxAmonestaciones;
        public static int maxFaltas;
        public static int minEnergia;
        public static Random rand { private get; set; }
        public String name { get; private set; }
        public int puntos;
        private int amonestaciones
        {
            get
            {
                return amonestaciones;
            }

            set
            {
                if ( value > maxAmonestaciones) {
                    amonestacionesMaximoExcedido(this, new AmonestacionesMaximoExcedidoArgs(value));
                    return;
                }

                if (value < 0)
                {
                    amonestaciones = 0;
                    return;
                }

                amonestaciones = value;
            }
        }

        private int faltas
        {
            get
            {
                return faltas;
            }

            set
            {
                if (value > maxFaltas)
                {
                    faltasMaximoExcedido(this, new FaltasMaximoExcedidoArgs(value));
                    return;
                }

                faltas = value;
            }
        }

        private int energia
        {
            get
            {
                return energia;
            }

            set
            {
                if (value < minEnergia)
                {
                    energiaMinimaExcedida(this, new EnergiaMinimaExcedidaArgs(value));
                    return;
                }

                if (value < 0)
                {
                    energia = 0;
                    return;
                }

                if (value > 100)
                {
                    energia = 100;
                    return;
                }

                energia = value;
            }
        }
        #endregion

        #region Constructor
        Jugador(string nombre, int amonestaciones, int faltas, int energia, int puntos)
        {
            this.name = nombre;
            this.amonestaciones = amonestaciones;
            this.faltas = faltas;
            this.energia = energia;
            this.puntos = puntos;
        }
        #endregion

        #region Funciones
        void incAmonestaciones()
        {
            this.amonestaciones += rand.Next(0, 2 + 1);
        }

        void incFaltas()
        {
            this.faltas += rand.Next(0, 3 + 1);
        }

        void decEnergia()
        {
            this.energia -= rand.Next(1, 7 + 1);
        }

        void incPuntos()
        {
            this.puntos += rand.Next(0, 3 + 1);
        }

        bool todoOk()
        {
            if(amonestaciones > maxAmonestaciones)
            {
                return false;
            }

            if(energia < minEnergia)
            {
                return false;
            }

            if(faltas > maxFaltas)
            {
                return false;
            }

            return true;
        }

        void mover()
        {
            if (todoOk())
            {
                incAmonestaciones();
                incFaltas();
                incPuntos();
                decEnergia();
            }
        }

        public override string ToString()
        {
            return $"[{name}] Puntos: {puntos}; Amonestaciones: {amonestaciones}; Faltas: {faltas}; Energía: {energia} %; Ok: {todoOk()}";
        }
        #endregion

        #region Events
        event EventHandler<AmonestacionesMaximoExcedidoArgs> amonestacionesMaximoExcedido;
        event EventHandler<FaltasMaximoExcedidoArgs> faltasMaximoExcedido;
        event EventHandler<EnergiaMinimaExcedidaArgs> energiaMinimaExcedida;
        #endregion
    }

    class AmonestacionesMaximoExcedidoArgs
    {
        #region Propiedades
        private int amonestaciones;
        #endregion

        #region Constructor
        public AmonestacionesMaximoExcedidoArgs(int amonestaciones)
        {
            this.amonestaciones = amonestaciones;
        }
        #endregion
    }

    class FaltasMaximoExcedidoArgs
    {
        #region Propiedades
        private int faltas;
        #endregion

        #region Constructor
        public FaltasMaximoExcedidoArgs(int faltas)
        {
            this.faltas = faltas;
        }
        #endregion
    }

    class EnergiaMinimaExcedidaArgs
    {
        #region Propiedades
        private int energia;
        #endregion

        #region Constructor
        public EnergiaMinimaExcedidaArgs(int energia)
        {
            this.energia = energia;
        }
        #endregion
    }
}