using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dyn.Database.entities
{
    class DetallePedido
    {
        #region Constructores

        public DetallePedido() { }

        public DetallePedido(Int32? iDDetallePed, Int32? idPedid, Int32? idProd, Int32? cantidadUnid, Int32? precioUnit)
        {
            iDDetallePedido = iDDetallePed;
            idPedidos = idPedid;
            idProducto = idProd;
            cantidadUnidades = cantidadUnid;
            precioUnitario = precioUnit;
        }

        #endregion

        #region Propiedades

        private Int32? iDDetallePedido;

        public Int32? IDDetallePedido
        {
            get { return iDDetallePedido; }
            set { iDDetallePedido = value; }
        }

        private Int32? idPedidos;

        public Int32? IdPedidos
        {
            get { return idPedidos; }
            set { idPedidos = value; }
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

        private Int32? precioUnitario;

        public Int32? PrecioUnitario
        {
            get { return precioUnitario; }
            set { precioUnitario = value; }
        }

        #endregion
    }
}
