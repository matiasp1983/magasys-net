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

        public Venta(Int32? idVen, DateTime? fech, Int16? est, Double? montot, string nomCli)
        {
            idVenta = idVen;
            fecha = fech;
            estado = est;
            montotal = montot;
            nombreCliente = nomCli;
        }

        public Venta(IDataRecord obj)
		{
            idVenta = Convert.ToInt32(obj["idVenta"]);
            fecha = Convert.ToDateTime(obj["fecha"]);
            estado = Convert.ToInt16(obj["estado"]);
            montotal = Convert.ToDouble(obj["total"]);
            nombreCliente = Convert.ToString(obj["nombreCliente"]);
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

        private Int16? estado = null;

        public enum VentaEstado
        {
            Confirmado = 1,
            Elimado = 0,
            Cancelado = 2
        }

        public VentaEstado Estado
        {
            get
            {
                return (VentaEstado)estado;
            }
            set
            {
                estado = (Int16)value;
            }
        }

        private Double? montotal;

        public Double? MonTotal
        {
            get { return montotal; }
            set { montotal = value; }
        }

        private string nombreCliente;

        public string NombreCliente
        {
            get { return nombreCliente; }
            set { nombreCliente = value; }
        }

        #endregion
    }
}
