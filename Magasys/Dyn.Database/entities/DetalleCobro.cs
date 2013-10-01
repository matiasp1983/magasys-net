using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.entities
{
    public class DetalleCobro
    {
        #region Constructores

        public DetalleCobro() { }

        public DetalleCobro(Int32? codCob, Int32? idDetCob, Int32? codVen, Double? subtot)
        {
            codCobro = codCob;
            idDetalleCobro = idDetCob;
            codVenta = codVen;
            subtotal = subtot;
        }

        public DetalleCobro(IDataRecord obj)
        {
            codCobro = Convert.ToInt32(obj["codCobro"]);
            idDetalleCobro = Convert.ToInt32(obj["idDetalleCobro"]);
            codVenta = Convert.ToInt32(obj["codVenta"]);
            subtotal = Convert.ToDouble(obj["subtotal"]);

            //if (obj["codCobro"] != DBNull.Value)
            //{
            //    codCobro = Convert.ToInt32(obj["codCobro"]);
            //}
            //else
            //{
            //    codCobro = null;
            //}

            //if (obj["idDetalleCobro"] != DBNull.Value)
            //{
            //    idDetalleCobro = Convert.ToInt32(obj["idDetalleCobro"]);
            //}
            //else
            //{
            //    idDetalleCobro = null;
            //}

            //if (obj["codVenta"] != DBNull.Value)
            //{
            //    codVenta = Convert.ToInt32(obj["codVenta"]);
            //}
            //else
            //{
            //    codVenta = null;
            //}

            //if (obj["subtotal"] != DBNull.Value)
            //{
            //    subtotal = Convert.ToDouble(obj["subtotal"]);
            //}
            //else
            //{
            //    subtotal = null;
            //}
        }

        #endregion

        #region Propiedades

        private Int32? codCobro;

        public Int32? CodCobro
        {
            get { return codCobro; }
            set { codCobro = value; }
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
