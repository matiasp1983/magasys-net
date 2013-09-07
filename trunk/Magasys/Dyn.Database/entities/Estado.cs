using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.entities
{
    public class Estado
    {
            #region Constructores

            public Estado() { }

            public Estado(Int32? id, string amb, string nom, string desc)
            {
                idEstado = id;
                ambito = amb;
                nombre = nom;
                descripcion = desc;
            }
            public Estado(IDataRecord obj)
            {
                idEstado = Convert.ToInt32(obj["idTipoDocumento"]);
                ambito = Convert.ToString(obj["ambito"]);
                nombre = Convert.ToString(obj["nombre"]);
                descripcion = nombre = Convert.ToString(obj["descripcion"]);
            }

            #endregion

            #region Propiedades

            private Int32? idEstado;
            public Int32? IdEstado
            {
                get { return idEstado; }
                set { idEstado = value; }
            }

            private string ambito;
            public string Ambito
            {
                get { return  ambito; }
                set {  ambito = value; }
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
