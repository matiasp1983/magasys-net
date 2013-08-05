using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.entities
{
    public class Genero
    {
        #region Constructores

        public Genero() { }

        public Genero(Int32? idGen, string nomb, Int16? est, string descrip)
        {
            idGenero = idGen;
            nombre = nomb;
            estado = est;
            descripcion = descrip;
        }

        public Genero(IDataRecord obj)
		{
            idGenero = Convert.ToInt32(obj["idGenero"]);
            nombre = Convert.ToString(obj["nombre"]);
            estado = Convert.ToInt16(obj["estado"]);
            descripcion = Convert.ToString(obj["descripcion"]);
		}

        #endregion

        #region Propiedades

        private Int32? idGenero;

        public Int32? IdGenero
        {
            get { return idGenero; }
            set { idGenero = value; }
        }

        private string nombre;

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        //private Int16? estado = null;

        //public enum GeneroEstado
        //{
        //    Activo = 1,
        //    Inactivo = 0
        //}

        //public GeneroEstado Estado
        //{
        //    get
        //    {
        //        return (GeneroEstado)estado;
        //    }
        //    set
        //    {
        //        estado = (Int16)value;
        //    }
        //}
        private Int16? estado;

        public Int16? Estado
        {
            get { return estado; }
            set { estado = value; }
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
