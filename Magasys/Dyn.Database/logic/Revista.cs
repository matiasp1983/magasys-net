using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.logic
{
    public class Revista : FactoryBase
    {
        public Revista() { }

        public int SeleccionarRevistaPorGenero(int idGenero)
        {
            List<Dyn.Database.entities.Revista> Collection = new List<Dyn.Database.entities.Revista>();
            CreateCommand("usp_SeleccionarRevistaConIdGenero", true);
            AddCmdParameter("@idGenero", idGenero, ParameterDirection.Input);
            ExecuteReader();
            int i = 0;
            if (Read())
            {
                i++;
            }
            return i;
        }

        public DataSet SeleccionarRevistasPorNombrePaginadoAdmin(string nombre, int paginaactual, ref int numeropaginas)
        {            
            CreateCommand("usp_SeleccionarRevistasPorNombrePaginado", true);
            AddCmdParameter("@nombre", nombre, ParameterDirection.Input);
            AddCmdParameter("@CurrentPage", paginaactual, ParameterDirection.Input);
            AddCmdParameter("@PageSize", 100, ParameterDirection.Input);
            AddCmdParameter("@TotalRecords", ParameterDirection.Output);
            DataSet ds = GetDataSet();
            numeropaginas = (int)GetValueCmdParameter("@TotalRecords");
            return ds;
        }
    }
}
