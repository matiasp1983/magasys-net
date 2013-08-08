using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dyn.Database.entities
{
    public class Revista : Producto
    {
        #region Constructores

        public Revista() { }

        public Revista(Int32? idRev, Int32? idGen, Int32? idPeriod, Double? prec, string dia)
        {
            idRevista = base.IdProducto;
            idGenero = idGen;
            idPeriodicidad = idPeriod;
            precio = prec;
            diaSemana = dia;
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
