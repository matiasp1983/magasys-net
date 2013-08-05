using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dyn.Database.entities
{
    class Periodicidad
    {
        #region Constructores

        public Periodicidad() { }

        public Periodicidad(Int32? idPeriodic, string nomb, string descrip)
        {
            idPeriodicidad = idPeriodic;
            nombre = nomb;
            descripcion = descrip;
        }

        #endregion

        #region Propiedades

        private Int32? idPeriodicidad;

        public Int32? IdPeriodicidad
        {
            get { return idPeriodicidad; }
            set { idPeriodicidad = value; }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private string descripcion;

        public string Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }

        #endregion
    }
}
