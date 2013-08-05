using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dyn.Database.entities
{
    class Devolucion
    {
        #region Constructores

        public Devolucion() { }

        public Devolucion(Int32? idDevoluc, DateTime? fech, Int16? est, Int32? idProv, string descripc)
        {
            idDevolucion = idDevoluc;
            fecha = fech;
            estado = est;
            idProveedor = idProv;
            descripcion = descripc;
        }

        #endregion

        #region Propiedades

        private Int32? idDevolucion;

        public Int32? IdDevolucion
        {
            get { return idDevolucion; }
            set { idDevolucion = value; }
        }
        
        private DateTime? fecha;

        public DateTime? Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        private Int16? estado;

	    public Int16? Estado
	    {
		    get { return estado;}
		    set { estado = value;}
	    }
	
        private Int32? idProveedor;

	    public Int32? IdProveedor
	    {
		    get { return idProveedor;}
		    set { idProveedor = value;}
	    }
	
        private string descripcion;

	    public string Descripcion
	    {
		    get { return descripcion;}
		    set { descripcion = value;}
	    }
	
        #endregion
    }
}
