using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.entities
{
    public class MenuCategoria
    {
        #region Constructores
        public MenuCategoria() { }

        public MenuCategoria(Int32? numidmenucategoria, Int32? numrelacionadaidmenucategoria, string strnombre, Boolean? numestado,string strpagina)
		{
            idmenucategoria = numidmenucategoria;
            relacionadaidmenucategoria = numrelacionadaidmenucategoria;
			mstrnombre = strnombre;
			mnumestado = numestado;
            mstrpagina = strpagina;
		
		}

        public MenuCategoria(IDataRecord obj)
		{
            idmenucategoria = Convert.ToInt32(obj["idMenuCategoria"]);
            if (obj["relacionadaIdMenuCategoria"] != DBNull.Value)
			{
                relacionadaidmenucategoria = Convert.ToInt32(obj["relacionadaIdMenuCategoria"]);
			}
			mstrnombre = Convert.ToString(obj["nombre"]);
			mnumestado = Convert.ToBoolean(obj["estado"]);
            mstrpagina = Convert.ToString(obj["pagina"]);
		}

        public MenuCategoria(DataRow obj)
		{
            idmenucategoria = Convert.ToInt32(obj["idMenuCategoria"]);
            if (obj["relacionadaIdMenuCategoria"] != DBNull.Value)
			{
                relacionadaidmenucategoria = Convert.ToInt32(obj["relacionadaIdMenuCategoria"]);
			}
			mstrnombre = Convert.ToString(obj["nombre"]);
			mnumestado = Convert.ToBoolean(obj["estado"]);
            mstrpagina = Convert.ToString(obj["pagina"]);
		}
        #endregion

        #region Propiedades
        Int32? idmenucategoria = null;
        public Int32? IdMenuCategoria
        {
            get { return idmenucategoria; }
            set { idmenucategoria = value; }
        }

        Int32? relacionadaidmenucategoria = null;
        public Int32? RelacionadaIdMenuCategoria
        {
            get { return relacionadaidmenucategoria; }
            set { relacionadaidmenucategoria = value; }
        }

        string mstrnombre = null;
        public string Nombre
        {
            get { return mstrnombre; }
            set { mstrnombre = value; }
        }

        Boolean? mnumestado = null;
        public Boolean? Estado
        {
            get { return mnumestado; }
            set { mnumestado = value; }
        }

        string mstrpagina = null;
        public string Pagina
        {
            get { return mstrpagina; }
            set { mstrpagina = value; }
        }

        #endregion
    }
}
