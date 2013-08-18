using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.entities
{
    public class Libro : Producto
    {
        #region Constructores

        public Libro() : base() { }

        public Libro(Int32? idProd, DateTime? fechcreac, string nomb, string descrip, Int16? est, Int32? idProv, Double? prec,
            string aut, Int16? ani, Int32? idGen)
            : base(idProd, fechcreac, nomb, descrip, est, idProv)
        {
            idLibro = base.IdProducto;
            precio = prec;
            autor = aut;
            anio = ani;
            idGenero = idGen;
        }

        public Libro(IDataRecord objp, IDataRecord objr)
            : base(objp)
        {
            idLibro = Convert.ToInt32(objr["idLibro"]);
            precio = Convert.ToDouble(objr["precio"]);
            autor = Convert.ToString(objr["autor"]);
            anio = Convert.ToInt16(objr["anio"]);
            idGenero = Convert.ToInt32(objr["idGenero"]);
        }

        #endregion

        #region Propiedades

        private Int32? idLibro;

        public Int32? IdLibro
        {
            get { return idLibro; }
            set { idLibro = value; }
        }

        private Double? precio;

        public Double? Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        private Int32? idGenero;

        public Int32? IdGenero
        {
            get { return idGenero; }
            set { idGenero = value; }
        }

        private string autor;

        public string Autor
        {
            get { return autor; }
            set { autor = value; }
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
