using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.entities
{
    public class Provincia
    {
        #region Constructores

        public Provincia() { }

        public Provincia(Int32? idProv, string nomb)
        {
            idProvincia = idProv;
            nombre = nomb;
        }
        public Provincia(IDataRecord obj)
		{
            idProvincia = Convert.ToInt32(obj["idProvincia"]);
            nombre = Convert.ToString(obj["nombre"]);
		}

        #endregion

        #region Propiedades

        private Int32? idProvincia;

        public Int32? IdProvincia
        {
            get { return idProvincia; }
            set { idProvincia = value; }
        }
        
        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }
        
        #endregion
    }
}
