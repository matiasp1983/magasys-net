using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.entities
{
    public class Periodicidad
    {
        #region Constructores

        public Periodicidad() { }

        public Periodicidad(Int32? idPeriodic, string nomb, string descrip)
        {
            idPeriodicidad = idPeriodic;
            nombre = nomb;
            descripcion = descrip;
        }

        public Periodicidad(IDataRecord obj)
		{
            idPeriodicidad = Convert.ToInt32(obj["idPeriodicidad"]);
            nombre = Convert.ToString(obj["nombre"]);
            if (obj["descripcion"] != DBNull.Value)
            {
                descripcion = Convert.ToString(obj["descripcion"]);
            }
            else
            {
                descripcion = null;
            }          
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
