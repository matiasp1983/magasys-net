using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dyn.Database.entities
{
    public class Libro
    {
        #region Constructores

        public Libro() { }

        public Libro(Int32? idLib, DateTime? fechcreac, string nomb, string descrip, Int16? est,
            Int32? cantidad, Int32? idTiposProd, Int32? idGen, Int32? idProv, Double? prec, string aut, Int16? ani)
        {
            idLibro = idLib;
            fechacreacion = fechcreac;
            nombre = nomb;
            descripcion = descrip;
            estado = est;
            cantidaddisponible = cantidad;
            idTiposProducto = idTiposProd;
            idGenero = idGen;
            idProveedor = idProv;
            precio = prec;
            autor = aut;
            anio = ani;
        }

        #endregion

        #region Propiedades

        private Int32? idLibro;

        public Int32? IdLibro
        {
            get { return idLibro; }
            set { idLibro = value; }
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

        private Int16? estado = null;

        public enum GeneroEstado
        {
            Activo = 1,
            Inactivo = 0
        }

        public GeneroEstado Estado
        {
            get
            {
                return (GeneroEstado)estado;
            }
            set
            {
                estado = (Int16)value;
            }
        }

        private Int32? cantidaddisponible;

        public Int32? Cantidaddisponible
        {
            get { return cantidaddisponible; }
            set { cantidaddisponible = value; }
        }

        private Int32? idTiposProducto;

        public Int32? IdTiposProducto
        {
            get { return idTiposProducto; }
            set { idTiposProducto = value; }
        }

        private Int32? idGenero;

        public Int32? IdGenero
        {
            get { return idGenero; }
            set { idGenero = value; }
        }

        private Int32? idProveedor;

        public Int32? IdProveedor
        {
            get { return idProveedor; }
            set { idProveedor = value; }
        }

        private Double? precio;

        public Double? Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        private string autor;

        public string Autor
        {
            get { return autor; }
            set { autor = value; }
        }

        private Int16? anio;

        public Int16? Anio
        {
            get { return anio; }
            set { anio = value; }
        }

        #endregion
    }
}
