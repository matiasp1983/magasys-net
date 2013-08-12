using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.entities
{
    public class Suplemento : Producto
    {
        #region Constructores

        public Suplemento() { }

        public Suplemento(Int32? idSup, Int32? idDia, Double? prec, string dia, Int32? idGen, Int32? idPeriod)
        {
            idSuplemento = idSup;
            idDiario = idDia;
            precio = prec;
            diaSemana = dia;
            idGenero = idGen;
            idPeriodicidad = idPeriod;
        }

        public Suplemento(IDataRecord obj)
		{
            idSuplemento = Convert.ToInt32(obj["idSuplemento"]);
            idDiario = Convert.ToInt32(obj["idDiario"]);
            precio = Convert.ToDouble(obj["precio"]);
            diaSemana = obj["diaSemana"].ToString();
            idGenero = Convert.ToInt32(obj["idGenero"]);
            idPeriodicidad = Convert.ToInt32(obj["idPeriodicidad"]);

            Nombre = obj["nombre"].ToString();
            Descripcion = obj["descripcion"].ToString();
            IdProveedor = Convert.ToInt16(obj["idProveedor"].ToString());

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

        private Double? precio;
        public Double? Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        private string diaSemana;
        public string DiaSemana
        {
            get { return diaSemana; }
            set { diaSemana = value; }
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

        #endregion
    }
}
