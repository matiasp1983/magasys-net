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
            
            try
            {
                idEstado = Convert.ToInt32(obj["idEstado"]);
            }
            catch (Exception)
            {
                idEstado = 0;    
            }
            
            try
            {
                montotal = Convert.ToDouble(obj["total"]);
            }
            catch (Exception)
            {
                montotal = 0;                
            }

            try
            {
                formaPago = Convert.ToString(obj["formaDePago"]);
            }
            catch (Exception)
            {                
                formaPago = string.Empty;
            }

            try
            {
                nroCliente = Convert.ToInt32(obj["nroCliente"]);
            }
            catch (Exception)
            {
                
                nroCliente = 0;
            }

            try
            {
                cliente.Apellido = obj["apellido"].ToString();
            }
            catch (Exception)
            {
                
                cliente.Apellido = string.Empty;
            }

            try
            {
                cliente.Nombre = obj["nombre"].ToString();
            }
            catch (Exception)
            {
                
                cliente.Nombre = string.Empty;
            }
            
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

        private Cliente cliente = new Cliente();
        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }
        #endregion
    }
}
