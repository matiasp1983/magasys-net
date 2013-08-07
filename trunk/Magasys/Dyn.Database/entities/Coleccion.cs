using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.entities
{
    public class Coleccion : Producto
    {
        #region Constructores

        public Coleccion() { }

        public Coleccion(Int32? idGen, Int32? idPeriod, Double? prec, Int16? cantEnt)
        {
            idColeccion = base.IdProducto;
            idGenero = idGen;
            idPeriodicidad = idPeriod;
            precio = prec;
            cantidadEntregas = cantEnt;
        }

        public Coleccion(IDataRecord obj)
		{
            idColeccion = Convert.ToInt32(obj["idColeccion"]);
            idGenero = Convert.ToInt32(obj["idGenero"]);
            idPeriodicidad = Convert.ToInt32(obj["idPeriodicidad"]);
            precio = Convert.ToDouble(obj["precio"]);
            cantidadEntregas = Convert.ToInt16(obj["cantidadEntrega"]);
		}
        #endregion

        #region Propiedades

        private Int32? idColeccion;
        public Int32? IdColeccion
        {
            get { return idColeccion; }
            set { idColeccion = value; }
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

        private Int16? cantidadEntregas;
        public Int16? CantidadEntregas
        {
            get { return cantidadEntregas; }
            set { cantidadEntregas = value; }
        }

        #endregion
    }
}
