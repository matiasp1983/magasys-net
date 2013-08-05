using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dyn.Database.entities
{
    public class Suplemento
    {
        #region Constructores

        public Suplemento() { }

        public Suplemento(Int32? idSup, Int32? idDia, DateTime? fechcreac, string nomb, string descrip, Int16? est,
            Int32? cantidad, Int32? idTiposProd, Int32? idGen, Int32? idProv, Int32? idPeriod, Double? prec, Int16? nroEdic)
        {
            idSuplemento = idSup;
            idDiario = idDia;
            fechacreacion = fechcreac;
            nombre = nomb;
            descripcion = descrip;
            estado = est;
            cantidaddisponible = cantidad;
            idTiposProducto = idTiposProd;
            idGenero = idGen;
        }

        #endregion

        #region Propiedades

        private Int32? idSuplemento;

        public Int32? IdSuplemento
        {
            get { return idSuplemento; }
            set { idSuplemento = value; }
        }

        private Int32? idDiario;

        public Int32? IdDiario
        {
            get { return idDiario; }
            set { idDiario = value; }
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

        #endregion
    }
}
