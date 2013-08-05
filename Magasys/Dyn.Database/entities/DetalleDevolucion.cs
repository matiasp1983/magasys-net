using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dyn.Database.entities
{
    class DetalleDevolucion
    {
        #region Constructores

        public DetalleDevolucion() { }

        public DetalleDevolucion(Int32? idDetalleDevol, Int32? idDevol, Int32? IdDetalleIngrProd, Int16? est, Int32? cantid)
        {
            idDetalleDevolucion = idDetalleDevol;
            idDevolucion = idDevol;
            IdDetalleIngresoProductos = IdDetalleIngrProd;
            estado = est;
            cantidad = cantid;
        }

        #endregion

        #region Propiedades

        private Int32? idDetalleDevolucion;

        public Int32? IdDetalleDevolucion
        {
            get { return idDetalleDevolucion; }
            set { idDetalleDevolucion = value; }
        }

        private Int32? idDevolucion;

        public Int32? IdDevolucion
        {
            get { return idDevolucion; }
            set { idDevolucion = value; }
        }

        private Int32? idDetalleIngresoProductos;

        public Int32? IdDetalleIngresoProductos
        {
            get { return idDetalleIngresoProductos; }
            set { idDetalleIngresoProductos = value; }
        }

        private Int16? estado;

        public Int16? Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        private Int32? cantidad;

        public Int32? Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        #endregion
    }
}
