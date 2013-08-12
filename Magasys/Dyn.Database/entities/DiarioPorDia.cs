using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.entities
{
    public class DiarioPorDia
    {
        #region Constructores

        public DiarioPorDia() { }

        public DiarioPorDia(Int32? idDia, string dia, Double? prec)
        {
            idDiario = idDia;
            diaSemana = dia;
            precio = prec;
        }

        public DiarioPorDia(IDataRecord obj)
		{
            idDiario = Convert.ToInt32(obj["idDiario"]);
            diaSemana = obj["diaSemana"].ToString();
            precio = Convert.ToDouble(obj["precio"].ToString());
		}

        #endregion

        #region Propiedades

        private Int32? idDiario;
        public Int32? IdDiario
        {
            get { return idDiario; }
            set { idDiario = value; }
        }

        private string diaSemana;
        public string DiaSemana
        {
            get { return diaSemana; }
            set { diaSemana = value; }
        }

        private Double? precio;
        public Double? Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        

        #endregion
    }
}
