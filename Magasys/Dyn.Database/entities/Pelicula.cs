using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.entities
{
    public class Pelicula : Producto
    {
        #region Constructores

        public Pelicula() : base() { }

        public Pelicula(Int32? idProd, DateTime? fechcreac, string nomb, string descrip, Int16? est, Int32? idProv, Int32? idGen,
            Double? prec, Int16? ani)
            : base(idProd, fechcreac, nomb, descrip, est, idProv)
        {
            idPelicula = base.IdProducto;
            idGenero = idGen;
            precio = prec;
            anio = ani;
        }

        public Pelicula(IDataRecord objp, IDataRecord objr)
            : base(objp)
        {
            idGenero = Convert.ToInt32(objr["idGenero"]);
            precio = Convert.ToDouble(objr["precio"]);
            anio = Convert.ToInt16(objr["anio"]);
        }

        #endregion

        #region Propiedades

        private Int32? idPelicula;

        public Int32? IdPelicula
        {
            get { return idPelicula; }
            set { idPelicula = value; }
        }

        private Int32? idGenero;

        public Int32? IdGenero
        {
            get { return idGenero; }
            set { idGenero = value; }
        }

        private Double? precio;

        public Double? Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        private Int16? anio;

        public Int16? Anio
        {
            get { return anio; }
            set { anio = value; }
        }

        #endregion
    }
}
