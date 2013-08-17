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
            Int16? est)
        {
            idDetalleIngresoProducto = idDetalleIngProd;
            idIngresoProductos = idIngrProd;
            producto = prod;
            cantidadUnidades = cantidadUnid;
            fechaDevolucion = fechaDevol;
            estado = est;
        }

        public DetalleIngresoProducto(IDataRecord obj)
		{
            idDetalleIngresoProducto = Convert.ToInt32(obj["idDetalleIngresoProductos"]);
            idIngresoProductos = Convert.ToInt32(obj["idIngresoProductos"]);
            cantidadUnidades = Convert.ToInt32(obj["cantidadUnidades"]);
            fechaDevolucion = Convert.ToDateTime(obj["fechaDevolucion"]);
            estado = Convert.ToInt16(obj["estado"]);
            producto.IdProducto = Convert.ToInt32(obj["idProducto"]);
            this.productoEdicion.IdProductoEdicion  = Convert.ToInt32(obj["idProductoEdicion"]);

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

        private ProductoEdicion productoEdicion = new Database.entities.ProductoEdicion();
        public ProductoEdicion ProductoEdicion
        {
            get { return productoEdicion; }
            set { productoEdicion = value; }
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


        #region Operaciones

        public void CalcularDevolucion()
        {
            // HAy que obtener el dato periodicidad para calcular correctamente, por ahora 
            // solo se le asigna un valor al azar

            fechaDevolucion = DateTime.Now;
            Random r = new Random();
            fechaDevolucion.Value.AddDays(r.Next(1,7)); // Agrego un valor al azar!
        }


        #endregion

    }
}
