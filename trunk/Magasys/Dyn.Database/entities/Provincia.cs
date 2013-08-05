using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dyn.Database.entities
{
    class Provincia
    {
        #region Constructores

        public Provincia() { }

        public Provincia(Int32? idProv, string nomb)
        {
            idProvincia = idProv;
            nombre = nomb;
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
