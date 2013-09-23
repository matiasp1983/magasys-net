using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.entities
{
    public class Venta
    {
        #region Constructores

        public Venta() { }

        public Venta(Int32? idVen, DateTime? fech, string forPag, Int32? est, Double? montot, Int32? nroCli)
        {
            idVenta = idVen;
            fecha = fech;
            idEstado = est;
            montotal = montot;
            formaPago = forPag;
            nroCliente = nroCli;
        }

        public Venta(IDataRecord obj)
        {
            idVenta = Convert.ToInt32(obj["idVenta"]);
            fecha = Convert.ToDateTime(obj["fecha"]);
            idEstado = Convert.ToInt32(obj["idEstado"]);
            montotal = Convert.ToDouble(obj["total"]);
            formaPago = Convert.ToString(obj["formaDePago"]);
            nroCliente = Convert.ToInt32(obj["nroCliente"]);
        }

        #endregion

        #region Propiedades

        private Int32? idVenta;

        public Int32? IdVenta
        {
            get { return idVenta; }
            set { idVenta = value; }
        }

        private DateTime? fecha;

        public DateTime? Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        private Int32? idEstado;

        public Int32? IdEstado
        {
            get { return idEstado; }
            set { idEstado = value; }
        }

        private Double? montotal;

        public Double? MonTotal
        {
            get { return montotal; }
            set { montotal = value; }
        }

        private string formaPago;

        public string FormaPago
        {
            get { return formaPago; }
            set { formaPago = value; }
        }

        private Int32? nroCliente;

        public Int32? NroCliente
        {
            get { return nroCliente; }
            set { nroCliente = value; }
        }

        #endregion
    }
}
