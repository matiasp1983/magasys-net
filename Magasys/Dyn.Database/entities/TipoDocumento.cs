using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.entities
{
    public class TipoDocumento
    {
        #region Constructores

        public TipoDocumento() { }

        public TipoDocumento(Int32? id, string nom, string desc)
        {
            idTipoDocumento = id;
            nombre = nom;
            descripcion = desc;
        }
        public TipoDocumento(IDataRecord obj)
        {
            try
            {
                idTipoDocumento = Convert.ToInt32(obj["idTipoDocumento"]);
            }
            catch (Exception)
            {
                idTipoDocumento = 0;
            }

            try
            {
                nombre = Convert.ToString(obj["nombre"]);
            }
            catch (Exception)
            {
                nombre = string.Empty;
            }

            try
            {
                descripcion = Convert.ToString(obj["descripcion"]);
            }
            catch (Exception)
            {
                descripcion = string.Empty;
            }
            
        }

        #endregion

        #region Propiedades

        private Int32? idTipoDocumento;
        public Int32? IdTipoDocumento
        {
            get { return idTipoDocumento; }
            set { idTipoDocumento = value; }
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
