using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Dyn.Database.entities
{
    public class DetalleIngresoProducto
    {
        #region Constructores

        public DetalleIngresoProducto() { }

        public DetalleIngresoProducto(Int32? idDetalleIngProd, Int32? idIngrProd, Producto prod, Int32? cantidadUnid, DateTime? fechaDevol,
            Int16? est, Int32? idProdEdi)
        {
            idDetalleIngresoProducto = idDetalleIngProd;
            idIngresoProductos = idIngrProd;
            producto = prod;
            cantidadUnidades = cantidadUnid;
            fechaDevolucion = fechaDevol;
            estado = est;
            idProductoEdicion = idProdEdi;
        }

        public DetalleIngresoProducto(IDataRecord obj)
		{
            idDetalleIngresoProducto = Convert.ToInt32(obj["idDetalleIngresoProducto"]);
            idIngresoProductos = Convert.ToInt32(obj["idIngresoProductos"]);
            cantidadUnidades = Convert.ToInt32(obj["cantidadUnidades"]);
            fechaDevolucion = Convert.ToDateTime(obj["fechaDevolucion"]);
            estado = Convert.ToInt16(obj["estado"]);
            producto.IdProducto = Convert.ToInt32(obj["idProducto"]);
            idProductoEdicion = Convert.ToInt32(obj["idProductoEdicion"]);

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

        private Producto producto;
        public Producto Producto
        {
            get { return producto; }
            set { producto = value; }
        }

        private Int32? idProductoEdicion;
        public Int32? IdProductoEdicion
        {
            get { return idProductoEdicion; }
            set { idProductoEdicion = value; }
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
