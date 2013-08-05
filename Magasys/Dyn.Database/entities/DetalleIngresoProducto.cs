using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dyn.Database.entities
{
    class DetalleIngresoProducto
    {
        #region Constructores

        public DetalleIngresoProducto() { }

        public DetalleIngresoProducto(Int32? idDetalleIngProd, Int32? idIngrProd, Int32? idProd, Int32? cantidadUnid, DateTime? fechaDevol,
            Int16? est)
        {
            idDetalleIngresoProducto = idDetalleIngProd;
            idIngresoProductos = idIngrProd;
            idProducto = idProd;
            cantidadUnidades = cantidadUnid;
            fechaDevolucion = fechaDevol;
            estado = est;
        }

        #endregion

        #region Propiedades

        private Int32? idDetalleIngresoProducto;

        public Int32? IdDetalleIngresoProducto
        {
            get { return idDetalleIngresoProducto; }
            set { idDetalleIngresoProducto = value; }
        }
        
        private Int32? idIngresoProductos;

        public Int32? IdIngresoProductos
        {
            get { return idIngresoProductos; }
            set { idIngresoProductos = value; }
        }

        private Int32? idProducto;

        public Int32? IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }

        private Int32? cantidadUnidades;

        public Int32? CantidadUnidades
        {
            get { return cantidadUnidades; }
            set { cantidadUnidades = value; }
        }

        private DateTime? fechaDevolucion;

        public DateTime? FechaDevolucion
        {
            get { return fechaDevolucion; }
            set { fechaDevolucion = value; }
        }

        private Int16? estado;

        public Int16? Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        #endregion

    }
}
