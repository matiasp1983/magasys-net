using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dyn.Database.entities
{
    class IngresoProducto
    {
        #region Constructores

        public IngresoProducto() { }

        public IngresoProducto(Int32? idIngresoProd, DateTime fech, Int16? est, Int32? idProv)
        {
            idIngresoProducto = idIngresoProd;
            fecha = fech;
            estado = est;
            idProveedor = idProv;
        }

        #endregion

        #region Propiedades

        private Int32? idIngresoProducto;

        public Int32? IdIngresoProducto
        {
            get { return idIngresoProducto; }
            set { idIngresoProducto = value; }
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

        private Int32? idProveedor;

        public Int32? IdProveedor
        {
            get { return idProveedor; }
            set { idProveedor = value; }
        }

        #endregion
    }
}
