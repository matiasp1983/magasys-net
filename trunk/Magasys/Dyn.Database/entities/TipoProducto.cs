using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dyn.Database.entities
{
    class TipoProducto
    {
        #region Constructores

        public TipoProducto() { }

        public TipoProducto(Int32? idTipoProd, string nomb, string descrip)
        {
            idTipoProducto = idTipoProd;
            nombre = nomb;
            descripcion = descrip;
        }

        #endregion

        #region Propiedades

        private Int32? idTipoProducto;

        public Int32? IdTipoProducto
        {
            get { return idTipoProducto; }
            set { idTipoProducto = value; }
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
