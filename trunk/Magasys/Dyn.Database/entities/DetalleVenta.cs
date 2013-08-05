using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dyn.Database.entities
{
    class DetalleVenta
    {
        #region Constructores

        public DetalleVenta() { }

        public DetalleVenta(Int32? idDetalleVen, Int32? idVent, Int32? idProd, Double precioUnid, Int32? cantid, Double subTot)
        {
            idDetalleVenta = idDetalleVen;
            idVenta = idVent;
            idProducto = idProd;
            precioUnidad = precioUnid;
            cantidad = cantid;
            subTotal = subTot;
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
        
        private Double precioUnidad;

	    public Double PrecioUnidad
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

        private Double subTotal;

	    public Double SubTotal
	    {
		    get { return subTotal;}
		    set { subTotal = value;}
	    }
	
        #endregion
    }
}
