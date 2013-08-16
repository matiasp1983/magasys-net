using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Dyn.Database.entities
{
    public class DetalleDevolucion
    {
        #region Constructores

        public DetalleDevolucion() { }

        public DetalleDevolucion(Int32? idDetalleDevol, Int32? idDevol, Int32? IdDetalleIngrProd, Int16? est, Int32? cantid, Producto prod, ProductoEdicion prodEdi)
        {
            idDetalleDevolucion = idDetalleDevol;
            idDevolucion = idDevol;
            IdDetalleIngresoProductos = IdDetalleIngrProd;
            estado = est;
            cantidad = cantid;
            producto = prod;
            productoEdicion = prodEdi;
        }

        public DetalleDevolucion(IDataRecord obj)
		{
            idDetalleDevolucion = Convert.ToInt32(obj["idDetalleDevolucion"]);
            idDevolucion = Convert.ToInt32(obj["idDevolucion"]);
            cantidad = Convert.ToInt32(obj["cantidad"]);
            idDetalleIngresoProductos = Convert.ToInt32(obj["idDetalleIngresoProductos"]);
            estado = Convert.ToInt16(obj["estado"]);
            producto.IdProducto = Convert.ToInt32(obj["idProducto"]);
            this.productoEdicion.IdProductoEdicion  = Convert.ToInt32(obj["idProductoEdicion"]);

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

        private Producto producto;
        public Producto Producto
        {
            get { return producto; }
            set { producto = value; }
        }

        private ProductoEdicion productoEdicion;
        public ProductoEdicion ProductoEdicion
        {
            get { return productoEdicion; }
            set { productoEdicion = value; }
        }



        #endregion
    }
}
