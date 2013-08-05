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

        public Producto(Int32? idProd, DateTime? fechcreac, string nomb, string descrip, Int16? est, Double? prec,
            Int32? cantidad, Int32? idTiposProd, Int32? idGen, Int32? idPeriod, Int32? idProv,
            string llegaDiaSem, string aut, string ani)
        {
            idProducto = idProd;
            fechacreacion = fechcreac;
            nombre = nomb;
            descripcion = descrip;
            estado = est;
            precio = prec;
            cantidaddisponible = cantidad;
            idTiposProducto = idTiposProd;
            idGenero = idGen;
            idPeriodicidad = idPeriod;
            idProveedor = idProv;
            llegaDiaSemana = llegaDiaSem;
            autor = aut;
            anio = ani;
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

        private Double? precio;

        public Double? Precio
        {
            get { return precio; }
            set { precio = value; }
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

        private Int32? idPeriodicidad;

        public Int32? IdPeriodicidad
        {
            get { return idPeriodicidad; }
            set { idPeriodicidad = value; }
        }

        private Int32? idProveedor;

        public Int32? IdProveedor
        {
            get { return idProveedor; }
            set { idProveedor = value; }
        }

        private string llegaDiaSemana;

        public string LlegaDiaSemana
        {
            get { return llegaDiaSemana; }
            set { llegaDiaSemana = value; }
        }

        private string autor;

        public string Autor
        {
            get { return autor; }
            set { autor = value; }
        }

        private string anio;

        public string Anio
        {
            get { return anio; }
            set { anio = value; }
        }

        #endregion

    }
}
