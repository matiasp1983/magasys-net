using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.entities
{
    public class DetalleVenta
    {
        #region Constructores

        public DetalleVenta() { }

        public DetalleVenta(Int32? idDetalleVen, Int32? idVent, Int32? idProd, Double? precioUnid, Int32? cantid,
               Double? subTot, Int32? idProdEdic, string nom)
        {
            idDetalleVenta = idDetalleVen;
            idVenta = idVent;
            idProducto = idProd;
            precioUnidad = precioUnid;
            cantidad = cantid;
            subTotal = subTot;
            idProductoEdicion = idProdEdic;
            nombre = nom;
        }

        public DetalleVenta(IDataRecord obj) 
        { 
            idDetalleVenta = Convert.ToInt32(obj["idDetalle"]);
            idVenta = Convert.ToInt32(obj["idVenta"]);
            idProducto = Convert.ToInt32(obj["idProducto"]);
            nombre = Convert.ToString(obj["nombre"]);
            precioUnidad = Convert.ToDouble(obj["precioUnidad"]);
            cantidad = Convert.ToInt32(obj["cantidad"]);
            subTotal = Convert.ToDouble(obj["subTotal"]);
            idProductoEdicion = Convert.ToInt32(obj["idProductoEdicion"]);
        }

        #endregion

        #region Propiedades

        private Int32? idDetalleVenta;

        public Int32? IdDetalleVenta
        {
            get { return idDetalleVenta; }
            set { idDetalleVenta = value; }
        }
        
        private Int32? idVenta;

        public Int32? IdVenta
        {
            get { return idVenta; }
            set { idVenta = value; }
        }

        private Int32? idProducto;

        public Int32? IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        
        private Double? precioUnidad;

	    public Double? PrecioUnidad
	    {
		    get { return precioUnidad;}
		    set { precioUnidad = value;}
	    }
	
         private Int32? cantidad;

	    public Int32? Cantidad
	    {
		    get { return cantidad;}
		    set { cantidad = value;}
	    }

        private Double? subTotal;

	    public Double? SubTotal
	    {
		    get { return subTotal;}
		    set { subTotal = value;}
	    }

        private Int32? idProductoEdicion;

        public Int32? IdProductoEdicion
        {
            get { return idProductoEdicion; }
            set { idProductoEdicion = value; }
        }
        
        #endregion
    }
}
