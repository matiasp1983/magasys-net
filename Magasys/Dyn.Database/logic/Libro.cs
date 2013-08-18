using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.logic
{
    public class Libro : FactoryBase
    {
        public Libro() { }

        public DataSet SeleccionarLibrosPorNombrePaginadoAdmin(string nombre, int idProveedor, int paginaactual, ref int numeropaginas)
        {
            CreateCommand("usp_SeleccionarLibrosPorNombrePaginado", true);
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

        public Dyn.Database.entities.Libro BuscarProducto(int idLibro)
        {
            Dyn.Database.entities.Libro objLibro = new Dyn.Database.entities.Libro();
            CreateCommand("usp_Libro", true);
            AddCmdParameter("@idLibro", idLibro, ParameterDirection.Input);
            AddCmdParameter("@Action", 0, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                objLibro = new Dyn.Database.entities.Libro(GetDataReader(), GetDataReader());
            }
            return objLibro;
        }

        private void AddParameters(Dyn.Database.entities.Libro objLibro)
        {
            CreateCommand("usp_Libro", true);
            AddCmdParameter("@nombre", objLibro.Nombre, ParameterDirection.Input);
            AddCmdParameter("@descripcion", objLibro.Descripcion, ParameterDirection.Input);
            AddCmdParameter("@idProveedor", objLibro.IdProveedor, ParameterDirection.Input);
            AddCmdParameter("@idGenero", objLibro.IdGenero, ParameterDirection.Input);
            AddCmdParameter("@precio", objLibro.Precio, ParameterDirection.Input);
            AddCmdParameter("@autor", objLibro.Autor, ParameterDirection.Input);
            AddCmdParameter("@anio", objLibro.Anio, ParameterDirection.Input);
        }

        public object Insert(Dyn.Database.entities.Libro objLibro)
        {
            object IdLibro = null;
            objLibro.Estado = 1;
            AddParameters(objLibro);
            AddCmdParameter("@fechaCreacion", objLibro.Fechacreacion, ParameterDirection.Input);
            AddCmdParameter("@estado", objLibro.Estado, ParameterDirection.Input);
            AddCmdParameter("@Action", 2, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                IdLibro = GetValue(0);
            }
            return IdLibro;
        }

        public void Update(Dyn.Database.entities.Libro objLibro)
        {
            AddParameters(objLibro);
            AddCmdParameter("@idLibro", objLibro.IdLibro, ParameterDirection.Input);
            AddCmdParameter("@Action", 1, ParameterDirection.Input);
            ExecuteNonQuery();
        }

        public void Delete(int idLibro)
        {
            CreateCommand("usp_Libro", true);
            AddCmdParameter("@idLibro", idLibro, ParameterDirection.Input);
            AddCmdParameter("@estado", 0, ParameterDirection.Input);
            AddCmdParameter("@Action", 3, ParameterDirection.Input);
            ExecuteNonQuery();
        }
    }
}
