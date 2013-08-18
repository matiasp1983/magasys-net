using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.logic
{
    public class Pelicula : FactoryBase
    {
        public Pelicula() { }

        public DataSet SeleccionarPeliculasPorNombrePaginadoAdmin(string nombre, int idProveedor, int paginaactual, ref int numeropaginas)
        {
            CreateCommand("usp_SeleccionarPeliculasPorNombrePaginado", true);
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

        public Dyn.Database.entities.Pelicula BuscarProducto(int idPelicula)
        {
            Dyn.Database.entities.Pelicula objPelicula = new Dyn.Database.entities.Pelicula();
            CreateCommand("usp_Pelicula", true);
            AddCmdParameter("@idPelicula", idPelicula, ParameterDirection.Input);
            AddCmdParameter("@Action", 0, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                objPelicula = new Dyn.Database.entities.Pelicula(GetDataReader(), GetDataReader());
            }
            return objPelicula;
        }

        private void AddParameters(Dyn.Database.entities.Pelicula objPelicula)
        {
            CreateCommand("usp_Pelicula", true);
            AddCmdParameter("@nombre", objPelicula.Nombre, ParameterDirection.Input);
            AddCmdParameter("@descripcion", objPelicula.Descripcion, ParameterDirection.Input);
            AddCmdParameter("@idProveedor", objPelicula.IdProveedor, ParameterDirection.Input);
            AddCmdParameter("@idGenero", objPelicula.IdGenero, ParameterDirection.Input);
            AddCmdParameter("@precio", objPelicula.Precio, ParameterDirection.Input);
            AddCmdParameter("@anio", objPelicula.Anio, ParameterDirection.Input);
        }

        public object Insert(Dyn.Database.entities.Pelicula objPelicula)
        {
            object IdPelicula = null;
            objPelicula.Estado = 1;
            AddParameters(objPelicula);
            AddCmdParameter("@fechaCreacion", objPelicula.Fechacreacion, ParameterDirection.Input);
            AddCmdParameter("@estado", objPelicula.Estado, ParameterDirection.Input);
            AddCmdParameter("@Action", 2, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                IdPelicula = GetValue(0);
            }
            return IdPelicula;
        }

        public void Update(Dyn.Database.entities.Pelicula objPelicula)
        {
            AddParameters(objPelicula);
            AddCmdParameter("@idPelicula", objPelicula.IdPelicula, ParameterDirection.Input);
            AddCmdParameter("@Action", 1, ParameterDirection.Input);
            ExecuteNonQuery();
        }

        public void Delete(int idPelicula)
        {
            CreateCommand("usp_Pelicula", true);
            AddCmdParameter("@idPelicula", idPelicula, ParameterDirection.Input);
            AddCmdParameter("@estado", 0, ParameterDirection.Input);
            AddCmdParameter("@Action", 3, ParameterDirection.Input);
            ExecuteNonQuery();
        }
    }
}
