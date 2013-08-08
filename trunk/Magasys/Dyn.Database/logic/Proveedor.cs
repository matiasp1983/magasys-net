using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.logic
{
    public class Proveedor : FactoryBase
    {
        public Proveedor() { }

        public List<Dyn.Database.entities.Proveedor> SeleccionarTodosLosProveedores()
        {
            List<Dyn.Database.entities.Proveedor> Collection = new List<Dyn.Database.entities.Proveedor>();
            CreateCommand("usp_SeleccionarTodosLosProveedores", true);
            ExecuteReader();
            while (Read())
            {                
                Collection.Add(new Dyn.Database.entities.Proveedor(GetDataReader()));
            }
            return Collection;
        }
        public DataSet SeleccionarProveedorPorNombrePaginadoAdmin(string nombre, int paginaactual, ref int numeropaginas)
        {
            CreateCommand("usp_SeleccionarGenerosPorNombrePaginado", true);
            AddCmdParameter("@nombre", nombre, ParameterDirection.Input);
            AddCmdParameter("@CurrentPage", paginaactual, ParameterDirection.Input);
            AddCmdParameter("@PageSize", 100, ParameterDirection.Input);
            AddCmdParameter("@TotalRecords", ParameterDirection.Output);
            DataSet ds = GetDataSet();
            numeropaginas = (int)GetValueCmdParameter("@TotalRecords");
            return ds;
        }
        public List<Dyn.Database.entities.Genero> SeleccionarTodosLosGeneros()
        {
            List<Dyn.Database.entities.Genero> Collection = new List<Dyn.Database.entities.Genero>();
            CreateCommand("usp_SeleccionarTodosLosGeneros", true);
            ExecuteReader();
            while (Read())
            {
                Collection.Add(new Dyn.Database.entities.Genero(GetDataReader()));
            }
            return Collection;
        }

    }
}
