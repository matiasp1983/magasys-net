using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dyn.Database.entities
{
    class ProductoFoto
    {
        #region Constructores

        public ProductoFoto() { }

        public ProductoFoto(Int32? idProdFoto, Int32? idProd, string nombrearch)
        {
            idProductoFoto = idProdFoto;
            idProducto = idProd;
            nombrearchivo = nombrearch;
        }

        #endregion

        #region Propiedades

        private Int32? idProductoFoto;

        public Int32? IdProductoFoto
        {
            get { return idProductoFoto; }
            set { idProductoFoto = value; }
        }

        private Int32? idProducto;

        public Int32? IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }

        private string nombrearchivo;

        public string Nombrearchivo
        {
            get { return nombrearchivo; }
            set { nombrearchivo = value; }
        }

        #endregion
    }
}
