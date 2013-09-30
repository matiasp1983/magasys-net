using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.entities
{
    public class Cobro
    {
        #region Constructores

        public Cobro() { }

        public Cobro(Int32? codCob, DateTime? fechaCob, Int32? nroCli, Double? total, Int16? idEst, Int32? idDetCob, Int32? codVen, Double? subtot)
        {
            codCobro = codCob;
            fechaCobro = fechaCob;
            nroCliente = nroCli;
            montoTotal = total;
            idEstado = idEst;
            idDetalleCobro = idDetCob;
            codVenta = codVen;
            subtotal = subtot;
        }

        public Cobro(IDataRecord obj)
        {
            codCobro = Convert.ToInt32(obj["codCobro"]);
            fechaCobro = Convert.ToDateTime(obj["fechaCobro"]);
            nroCliente = Convert.ToInt32(obj["nroCliente"]);
            montoTotal = Convert.ToDouble(obj["montoTotal"]);
            idEstado = Convert.ToInt16(obj["idEstado"]);
            idDetalleCobro = Convert.ToInt32(obj["idDetalleCobro"]);
            codVenta = Convert.ToInt32(obj["codVenta"]);
            subtotal = Convert.ToInt32(obj["subtotal"]);
        }

        #endregion

        #region Propiedades

        private Int32? codCobro;

        public Int32? CodCobro
        {
            get { return codCobro; }
            set { codCobro = value; }
        }

        private DateTime? fechaCobro;

        public DateTime? FechaCobro
        {
            get { return fechaCobro; }
            set { fechaCobro = value; }
        }

        private Int32? nroCliente;

        public Int32? NroCliente
        {
            get { return nroCliente; }
            set { nroCliente = value; }
        }

        private Double? montoTotal;

        public Double? MontoTotal
        {
            get { return montoTotal; }
            set { montoTotal = value; }
        }

        private Int16? idEstado;

        public Int16? IdEstado
        {
            get { return idEstado; }
            set { idEstado = value; }
        }

        private Int32? idDetalleCobro;

        public Int32? IdDetalleCobro
        {
            get { return idDetalleCobro; }
            set { idDetalleCobro = value; }
        }

        private Int32? codVenta;

        public Int32? CodVenta
        {
            get { return codVenta; }
            set { codVenta = value; }
        }

        private Double? subtotal;

        public Double? Subtotal
        {
            get { return subtotal; }
            set { subtotal = value; }
        }
        
        #endregion

    }
}
