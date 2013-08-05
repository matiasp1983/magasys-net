using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dyn.Database.entities
{
    class Venta
    {
        #region Constructores
        public Venta() { }

        public Venta(Int32? idVen, DateTime fech, Int16? est, Double? montot)
        {
            idVenta = idVen;
            fecha = fech;
            estado = est;
            montotal = montot;
        }

        #endregion

        #region Propiedades

        private Int32? idVenta;

        public Int32? IdVenta
        {
            get { return idVenta; }
            set { idVenta = value; }
        }

        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        private Int16? estado;

        public Int16? Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        private Double? montotal;

        public Double? MonTotal
        {
            get { return montotal; }
            set { montotal = value; }
        }

        #endregion
    }
}
