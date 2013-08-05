using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.logic
{
    public class Genero : FactoryBase
    {
        public Genero() { }

        public Dyn.Database.entities.Genero Load(int idGenero)
        {
            Dyn.Database.entities.Genero objGenero = new Dyn.Database.entities.Genero();
            CreateCommand("usp_Genero", true);
            AddCmdParameter("@idGenero", idGenero, ParameterDirection.Input);
            AddCmdParameter("@Action", 0, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                objGenero = new Dyn.Database.entities.Genero(GetDataReader());
            }
            return objGenero;
        }

        public DataSet SeleccionarGenerosPorNombrePaginadoAdmin(string nombre, int paginaactual, ref int numeropaginas)
        {
            CreateCommand("usp_SeleccionarGenerosPorNombrePaginado", true);
            AddCmdParameter("@nombre", nombre, ParameterDirection.Input);
            AddCmdParameter("@CurrentPage", paginaactual, ParameterDirection.Input);
            AddCmdParameter("@PageSize",100, ParameterDirection.Input);
            AddCmdParameter("@TotalRecords", ParameterDirection.Output);
            DataSet ds = GetDataSet();
            numeropaginas = (int)GetValueCmdParameter("@TotalRecords");
            return ds;
        }

        private void AddParameters(Dyn.Database.entities.Genero objusuario)
        {
            CreateCommand("usp_Genero", true);
            AddCmdParameter("@idGenero", objusuario.IdGenero, ParameterDirection.Input);
            AddCmdParameter("@nombre", objusuario.Nombre, ParameterDirection.Input);
            AddCmdParameter("@estado", objusuario.Estado, ParameterDirection.Input);
            AddCmdParameter("@descripcion", objusuario.Descripcion, ParameterDirection.Input);
        }

        public object Insert(Dyn.Database.entities.Genero objGenero)
        {
            object IdGenero = null;
            objGenero.Estado = 1;
            AddParameters(objGenero);
            AddCmdParameter("@Action", 2, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                IdGenero = GetValue(0);
            }
            return IdGenero;
        }

        public void Update(Dyn.Database.entities.Genero objGenero)
        {
            objGenero.Estado = 1;
            AddParameters(objGenero);
            AddCmdParameter("@Action", 1, ParameterDirection.Input);
            ExecuteNonQuery();
        }

        public void Delete(int idGenero)
        {
            CreateCommand("usp_Genero", true);
            AddCmdParameter("@idGenero", idGenero, ParameterDirection.Input);
            AddCmdParameter("@estado", 0, ParameterDirection.Input);
            AddCmdParameter("@Action", 3, ParameterDirection.Input);
            ExecuteNonQuery();
        }
    }
}
