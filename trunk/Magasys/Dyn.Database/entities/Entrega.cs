using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Dyn.Database.entities
{
    public class Entrega
    {
        #region Constructores

        public Entrega () { }

        public Entrega(Int32? idEnt, ReservaEdicion reserva, DateTime? fec)
        {
            CodEntrega = idEnt;
            ReservaEdicion = reserva;
            Fecha = fec;
        }
        public Entrega(IDataRecord obj)
		{
            codEntrega = Convert.ToInt32(obj["idDevolucion"]);
            ReservaEdicion.CodReservaEdicion = Convert.ToInt32(obj["codReservaEdicion"]);
            fecha = Convert.ToDateTime(obj["fecha"]);
		}

        #endregion

        #region Propiedades

        private Int32? codEntrega;
        public Int32? CodEntrega
        {
            get { return codEntrega; }
            set { codEntrega = value; }
        }

        private ReservaEdicion reservaEdicion = new ReservaEdicion();
        public ReservaEdicion ReservaEdicion
        {
            get { return reservaEdicion; }
            set { reservaEdicion = value; }
        }

        private DateTime? fecha;

        public DateTime? Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        #endregion

    }
}
