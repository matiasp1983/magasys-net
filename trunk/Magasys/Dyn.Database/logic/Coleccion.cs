using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.logic
{
    public class Coleccion : FactoryBase
    {
        public Coleccion() { }

        public Dyn.Database.entities.Coleccion Load(int idColeccion)
        {
            Dyn.Database.entities.Coleccion objColeccion = new Dyn.Database.entities.Coleccion();
            CreateCommand("usp_Coleccion", true);
            AddCmdParameter("@idColeccion", idColeccion, ParameterDirection.Input);
            AddCmdParameter("@Action", 0, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                objColeccion = new Dyn.Database.entities.Coleccion(GetDataReader());
            }
            return objColeccion;
        }

        public DataSet SeleccionarColeccionPorNombrePaginadoAdmin(string nombre, int paginaactual, ref int numeropaginas)
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

        private void AddParameters(Dyn.Database.entities.Coleccion objusuario)
        {
            CreateCommand("usp_Coleccion", true);
            AddCmdParameter("@idColeccion", objusuario.IdColeccion, ParameterDirection.Input);
            AddCmdParameter("@idGenero", objusuario.IdGenero, ParameterDirection.Input);
            AddCmdParameter("@idPeriodicidad", objusuario.IdPeriodicidad, ParameterDirection.Input);
            AddCmdParameter("@precio", objusuario.Precio, ParameterDirection.Input);
            AddCmdParameter("@cantidadEntregas", objusuario.CantidadEntregas, ParameterDirection.Input);

        }

        public object Insert(Dyn.Database.entities.Coleccion objColeccion)
        {
            object IdColeccion = null;
            objColeccion.Estado = 1;
            AddParameters(objColeccion);
            AddCmdParameter("@Action", 2, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                IdColeccion = GetValue(0);
            }
            return IdColeccion;
        }

        public void Update(Dyn.Database.entities.Coleccion objColeccion)
        {
            objColeccion.Estado = 1;
            AddParameters(objColeccion);
            AddCmdParameter("@Action", 1, ParameterDirection.Input);
            ExecuteNonQuery();
        }

        public void Delete(int idColeccion)
        {
        //    CreateCommand("usp_Coleccion", true);
        //    AddCmdParameter("@idColeccion", idColeccion, ParameterDirection.Input);
        //    AddCmdParameter("@idGenero", 0, ParameterDirection.Input);
        //    AddCmdParameter("@idPeriodicidad", 3, ParameterDirection.Input);

        //    ExecuteNonQuery();
        }

    }
}
