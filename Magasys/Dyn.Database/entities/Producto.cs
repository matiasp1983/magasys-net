using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.entities
{
    public class Producto
    {

        #region Constructores

        public Producto() { }

        public Producto(Int32? idProd, DateTime? fechcreac, string nomb, string descrip, Int16? est, Int32? idProv)
        {
            idProducto = idProd;
            fechacreacion = fechcreac;
            nombre = nomb;
            descripcion = descrip;
            estado = est;
            idProveedor = idProv;
        }

        public Producto(IDataRecord obj)
        {
            //idProducto = Convert.ToInt32(obj["idProducto"]);
            fechacreacion = Convert.ToDateTime(obj["fechaCreacion"]);
            nombre = Convert.ToString(obj["nombre"]);
            descripcion = Convert.ToString(obj["descripcion"]);
            estado = Convert.ToInt16(obj["estado"]);
            idProveedor = Convert.ToInt32(obj["idProveedor"]);
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

        private Int32? idProveedor;
        public Int32? IdProveedor
        {
            get { return idProveedor; }
            set { idProveedor = value; }
        }

        #endregion

    }
}
