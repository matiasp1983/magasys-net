using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.entities
{
    public class Revista : Producto
    {
        #region Constructores

        public Revista() : base() { }

        public Revista(Int32? idProd, DateTime? fechcreac, string nomb, string descrip, Int16? est, Int32? idProv,
            Int32? idGen, Int32? idPeriod, Double? prec, string dia)
            : base(idProd, fechcreac, nomb, descrip, est, idProv)
        {
            idRevista = base.IdProducto;
            idGenero = idGen;
            idPeriodicidad = idPeriod;
            precio = prec;
            diaSemana = dia;
        }

        public Revista(IDataRecord objp, IDataRecord objr)
            : base(objp)
        {
            idGenero = Convert.ToInt32(objr["idGenero"]);
            idPeriodicidad = Convert.ToInt32(objr["idPeriodicidad"]);
            precio = Convert.ToDouble(objr["precio"]);
            diaSemana = Convert.ToString(objr["diaSemana"]);
        }

        #endregion

        #region Propiedades

        private Int32? idRevista;

        public Int32? IdRevista
        {
            get { return idRevista; }
            set { idRevista = value; }
        }

        private Int32? idGenero;

        public Int32? IdGenero
        {
            get { return idGenero; }
            set { idGenero = value; }
        }

        private Int32? idPeriodicidad;

        public Int32? IdPeriodicidad
        {
            get { return idPeriodicidad; }
            set { idPeriodicidad = value; }
        }

        private Double? precio;

        public Double? Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        private string diaSemana;

        public string DiaSemana
        {
            get { return diaSemana; }
            set { diaSemana = value; }
        }

        #endregion
    }
}
