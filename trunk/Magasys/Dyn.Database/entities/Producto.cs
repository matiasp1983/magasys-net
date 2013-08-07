using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dyn.Database.entities
{
    class Producto
    {

        #region Constructores

        public Producto() { }

        public Producto(Int32? idProd, DateTime? fechcreac, string nomb, string descrip, Int16? est, Int32? idTiposProd, Int32? idProv)
        {
            idProducto = idProd;
            fechacreacion = fechcreac;
            nombre = nomb;
            descripcion = descrip;
            estado = est;
            idTiposProducto = idTiposProd;
            idProveedor = idProv;
        }

        #endregion

        #region Propiedades

        private Int32? idProducto;
        public Int32? IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }

        private DateTime? fechacreacion;
        public DateTime? Fechacreacion
        {
            get { return fechacreacion; }
            set { fechacreacion = value; }
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

        private Int16? estado;
        public Int16? Estado
        {
            get { return estado; }
            set { estado = value; }
        }

        private Int32? idTiposProducto;
        public Int32? IdTiposProducto
        {
            get { return idTiposProducto; }
            set { idTiposProducto = value; }
        }

        private Int32? idProveedor;
        public Int32? IdProveedor
        {
            get { return idProveedor; }
            set { idProveedor = value; }
        }


        #endregion

    }
}
