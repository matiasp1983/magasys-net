using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.entities
{
    public class Diario : Producto 
    {
        #region Constructores

        public Diario() { }

        public Diario(Int32? idDia)
        {
            idDiario = idDia;
        }


        public Diario(IDataRecord obj)
		{
            idDiario = Convert.ToInt32(obj["idDiario"]);
            Nombre = obj["nombre"].ToString();
            Descripcion = obj["descripcion"].ToString();
            IdProveedor = Convert.ToInt16(obj["idProveedor"].ToString());
		}

        #endregion

        #region Propiedades

        private Int32? idDiario;
        public Int32? IdDiario
        {
            get { return idDiario; }
            set { idDiario = value; }
        }

        #endregion
    }
}
