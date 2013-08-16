using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.logic
{
    public class Revista : FactoryBase
    {
        public Revista() { }

        public Dyn.Database.entities.Revista BuscarProducto(int idRevista)
        {
            Dyn.Database.entities.Revista objrevista = new Dyn.Database.entities.Revista();
            CreateCommand("usp_Revista", true);
            AddCmdParameter("@idRevista", idRevista, ParameterDirection.Input);
            AddCmdParameter("@Action", 0, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                objrevista = new Dyn.Database.entities.Revista(GetDataReader(), GetDataReader()); 
            }
            return objrevista;
        }

        public DataSet SeleccionarRevistasPorNombrePaginadoAdmin(string nombre, int paginaactual, ref int numeropaginas, int idProveedor)
        {            
            CreateCommand("usp_SeleccionarRevistasPorNombrePaginado", true);
            AddCmdParameter("@nombre", nombre, ParameterDirection.Input);
            if (idProveedor != 0)
            {
                AddCmdParameter("@idProveedor", idProveedor, ParameterDirection.Input);
            }
            AddCmdParameter("@CurrentPage", paginaactual, ParameterDirection.Input);
            AddCmdParameter("@PageSize", 100, ParameterDirection.Input);
            AddCmdParameter("@TotalRecords", ParameterDirection.Output);
            DataSet ds = GetDataSet();
            numeropaginas = (int)GetValueCmdParameter("@TotalRecords");
            return ds;
        }

        public int ExisteRelacionRevista(int idRevista)
        {
            CreateCommand("usp_ExisteRelacionRevista", true);
            AddCmdParameter("@idProducto", idRevista, ParameterDirection.Input);
            ExecuteReader();
            int i = 0;
            if (Read())
            {
                i++;
            }
            return i;
        }

        private void AddParameters(Dyn.Database.entities.Revista objRevista)
        {
            CreateCommand("usp_Revista", true);
            AddCmdParameter("@nombre", objRevista.Nombre, ParameterDirection.Input);
            AddCmdParameter("@descripcion", objRevista.Descripcion, ParameterDirection.Input);
            AddCmdParameter("@idProveedor", objRevista.IdProveedor, ParameterDirection.Input);
            AddCmdParameter("@idGenero", objRevista.IdGenero, ParameterDirection.Input);
            AddCmdParameter("@idPeriodicidad", objRevista.IdPeriodicidad, ParameterDirection.Input);
            AddCmdParameter("@precio", objRevista.Precio, ParameterDirection.Input);
            AddCmdParameter("@diaSemana", objRevista.DiaSemana, ParameterDirection.Input);
        }

        public object Insert(Dyn.Database.entities.Revista objRevista)
        {
            object IdRevista = null;
            objRevista.Estado = 1;
            AddParameters(objRevista);
            AddCmdParameter("@fechaCreacion", objRevista.Fechacreacion, ParameterDirection.Input);
            AddCmdParameter("@estado", objRevista.Estado, ParameterDirection.Input);
            AddCmdParameter("@Action", 2, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                IdRevista = GetValue(0);
            }
            return IdRevista;
        }

        public void Update(Dyn.Database.entities.Revista objRevista)
        {
            AddParameters(objRevista);
            AddCmdParameter("@idRevista", objRevista.IdRevista, ParameterDirection.Input);
            AddCmdParameter("@Action", 1, ParameterDirection.Input);
            ExecuteNonQuery();
        }

        public void Delete(int idRevista)
        {
            CreateCommand("usp_Revista", true);
            AddCmdParameter("@idRevista", idRevista, ParameterDirection.Input);
            AddCmdParameter("@estado", 0, ParameterDirection.Input);
            AddCmdParameter("@Action", 3, ParameterDirection.Input);
            ExecuteNonQuery();
        }
    }
}
