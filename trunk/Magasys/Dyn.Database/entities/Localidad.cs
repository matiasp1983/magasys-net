using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.entities
{
    public class Localidad
    {
        #region Constructores

        public Localidad() { }

        public Localidad(Int32? idLocal, string nom, Int32? idProv)
        {
            idLocalidad = idLocal;
            nombre = nom;
            idProvincia = idProv;
        }

        public Localidad(IDataRecord obj)
        {
            idLocalidad = Convert.ToInt32(obj["idLocalidad"]);
            nombre = Convert.ToString(obj["nombre"]);
            try
            {
                Provincia.Nombre = Convert.ToString(obj["provincia"]);
            }
            catch (Exception)
            {
                Provincia.Nombre = string.Empty;
            }
            try
            {
                idProvincia = Convert.ToInt32(obj["idProvincia"]);
            }
            catch (Exception)
            {
                idProvincia = 0;
            }
        }

        #endregion

        #region Propiedades

        private Int32? idLocalidad;

        public Int32? IdLocalidad
        {
            get { return idLocalidad; }
            set { idLocalidad = value; }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        private Int32? idProvincia;

        public Int32? IdProvincia
        {
            get { return idProvincia; }
            set { idProvincia = value; }
        }

        private Provincia provincia = new Provincia();

        public Provincia Provincia
        {
            get { return provincia; }
            set { provincia = value; }
        }

        #endregion
    }
}
