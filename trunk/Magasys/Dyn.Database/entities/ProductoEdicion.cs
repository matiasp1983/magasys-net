using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Dyn.Database.entities
{
    public class ProductoEdicion
    {
        #region Constructores

        public ProductoEdicion() { }

        public ProductoEdicion(Int32? idProdEdi, Int32? idProd, Int32? est, Double? prec, Int16? cantDisp, string desc)
        {
            idProductoEdicion = idProdEdi;
            idProducto = idProd;
            estado = est;
            precio = prec;
            cantidadDisponible = cantDisp;
            descripcion = desc;
        }

        public ProductoEdicion(IDataRecord obj)
        {
            idProductoEdicion = Convert.ToInt32(obj["idProductoEdicion"]);
            idProducto = Convert.ToInt32(obj["idProducto"]);
            estado = Convert.ToInt16(obj["estado"]);
            cantidadDisponible = Convert.ToInt32(obj["cantidadDisponible"]);
            precio = Convert.ToDouble(obj["precio"]);
            descripcion = obj["descripcion"].ToString();
            CargarProducto();
        }

        #endregion

        #region Propiedades

        private Int32? idProductoEdicion;
        public Int32? IdProductoEdicion
        {
            get { return idProductoEdicion; }
            set { idProductoEdicion = value; }
        }

        private Int32? idProducto;
        public Int32? IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }
        private Producto producto;
        public Producto Producto
        {
            get { return producto; }
            set { producto = value; }
        }

        private Int32? estado;
        public Int32? Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        private Int32? cantidadDisponible;
        public Int32? CantidadUnidades
        {
            get { return cantidadDisponible; }
            set { cantidadDisponible = value; }
        }

        private Double? precio;
        public Double? Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        private string descripcion;
        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }


        #endregion

        #region Propiedades

        public int ObtenerIdDetalleIngreso()
        {
            Database.logic.DetalleIngreso lDetIng = new Database.logic.DetalleIngreso();
            Database.entities.DetalleIngresoProducto det = lDetIng.ObtenerDetallePorEdicion(Convert.ToInt32(idProductoEdicion));
            return Convert.ToInt32(det.IdDetalleIngresoProducto);

        }
        public void CargarProducto()
        {
            Dyn.Database.logic.Producto lProducto = new Dyn.Database.logic.Producto();
            Producto = lProducto.Load(Convert.ToInt32(IdProducto));
        }

        #endregion
    }
}