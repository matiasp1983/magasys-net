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

        public int VerificaRelacionGenero(int idGenero)
        {
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

        private void AddParameters(Dyn.Database.entities.Genero objgenero)
        {
            CreateCommand("usp_Genero", true);
            AddCmdParameter("@idGenero", objgenero.IdGenero, ParameterDirection.Input);
            AddCmdParameter("@nombre", objgenero.Nombre, ParameterDirection.Input);
            AddCmdParameter("@estado", objgenero.Estado, ParameterDirection.Input);
            AddCmdParameter("@descripcion", objgenero.Descripcion, ParameterDirection.Input);
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
