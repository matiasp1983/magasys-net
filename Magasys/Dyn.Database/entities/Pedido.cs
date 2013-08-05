using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dyn.Database.entities
{
    class Pedido
    {
        #region Constructores

        public Pedido() { }

        public Pedido(Int32? idPed, DateTime fech, Int32? idProv, Double? montoTot)
        {
            idPedido = idPed;
            fecha = fech;
            idProveedor = idProv;
            montoTotal = montoTot;
        }

        #endregion

        #region Propiedades

        private Int32? idPedido;

        public Int32? IdPedido
        {
            get { return idPedido; }
            set { idPedido = value; }
        }

        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        private Int32? idProveedor;

        public Int32? IdProveedor
        {
            get { return idProveedor; }
            set { idProveedor = value; }
        }

        private Double? montoTotal;

        public Double? MontoTotal
        {
            get { return montoTotal; }
            set { montoTotal = value; }
        }

        #endregion
    }
}
