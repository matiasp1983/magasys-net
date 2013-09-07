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
            idTipoDocumento = Convert.ToInt32(obj["idTipoDocumento"]);
            nombre = Convert.ToString(obj["nombre"]);
            descripcion = nombre = Convert.ToString(obj["descripcion"]);
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
