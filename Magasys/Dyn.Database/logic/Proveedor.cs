using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.logic
{
    public class Proveedor : FactoryBase
    {
        public Proveedor() { }

        public Dyn.Database.entities.Proveedor Load(int idProveedor)
        {
            Dyn.Database.entities.Proveedor objProveedor = new Dyn.Database.entities.Proveedor();
            CreateCommand("usp_Proveedor", true);
            AddCmdParameter("@Proveedor", idProveedor, ParameterDirection.Input);
            AddCmdParameter("@Action", 0, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                objProveedor = new Dyn.Database.entities.Proveedor(GetDataReader());
            }
            return objProveedor;
        }

        //public List<Dyn.Database.entities.Proveedor> SeleccionarTodosLosProveedores()
        //{
        //    List<Dyn.Database.entities.Proveedor> Collection = new List<Dyn.Database.entities.Proveedor>();
        //    CreateCommand("usp_SeleccionarTodosLosProveedores", true);
        //    ExecuteReader();
        //    while (Read())
        //    {                
        //        Collection.Add(new Dyn.Database.entities.Proveedor(GetDataReader()));
        //    }
        //    return Collection;
        //}
        public DataSet SeleccionarProveedorPorNombrePaginadoAdmin(string razonSocial, int paginaactual, ref int numeropaginas)
        {
            CreateCommand("usp_SeleccionarProveedoresPorNombrePaginado", true);
            AddCmdParameter("@razonSocial", razonSocial, ParameterDirection.Input);
            AddCmdParameter("@CurrentPage", paginaactual, ParameterDirection.Input);
            AddCmdParameter("@PageSize", 100, ParameterDirection.Input);
            AddCmdParameter("@TotalRecords", ParameterDirection.Output);
            DataSet ds = GetDataSet();
            numeropaginas = (int)GetValueCmdParameter("@TotalRecords");
            return ds;
        }
        //public List<Dyn.Database.entities.Genero> SeleccionarTodosLosGeneros()
        //{
        //    List<Dyn.Database.entities.Genero> Collection = new List<Dyn.Database.entities.Genero>();
        //    CreateCommand("usp_SeleccionarTodosLosGeneros", true);
        //    ExecuteReader();
        //    while (Read())
        //    {
        //        Collection.Add(new Dyn.Database.entities.Genero(GetDataReader()));
        //    }
        //    return Collection;
        //}

        private void AddParameters(Dyn.Database.entities.Proveedor objusuario)
        {
            CreateCommand("usp_Proveedor", true);
            AddCmdParameter("@idProveedor", objusuario.IdProveedor, ParameterDirection.Input);
            AddCmdParameter("@cuit", objusuario.Cuit, ParameterDirection.Input);
            AddCmdParameter("@detalle", objusuario.Detalle, ParameterDirection.Input);
            AddCmdParameter("@domicilioCalle", objusuario.DomicilioCalle, ParameterDirection.Input);
            AddCmdParameter("@domicilioNro", objusuario.DomicilioNro, ParameterDirection.Input);
            AddCmdParameter("@domicilioDpto", objusuario.DomicilioDpto, ParameterDirection.Input);
            AddCmdParameter("@domicilioPiso", objusuario.DomicilioPiso, ParameterDirection.Input);
            AddCmdParameter("@idLocalidad", objusuario.IdLocalidad, ParameterDirection.Input);
            AddCmdParameter("@email", objusuario.Email, ParameterDirection.Input);
            AddCmdParameter("@estado", objusuario.Estado, ParameterDirection.Input);
            AddCmdParameter("@razonSocial", objusuario.RazonSocial, ParameterDirection.Input);
            AddCmdParameter("@reponsableApellido", objusuario.ResponsableApellido, ParameterDirection.Input);
            AddCmdParameter("@reponsableNombre", objusuario.ResponsableNombre, ParameterDirection.Input);
            AddCmdParameter("@reponsableEmail", objusuario.ResponsableEmail, ParameterDirection.Input);
            AddCmdParameter("@telefono", objusuario.Telefono, ParameterDirection.Input);
            AddCmdParameter("@nombre", objusuario.Nombre, ParameterDirection.Input);
        }

        public object Insert(Dyn.Database.entities.Proveedor objProveedor)
        {
            object IdProveedor = null;
            objProveedor.Estado = 1;
            AddParameters(objProveedor);
            AddCmdParameter("@Action", 2, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                IdProveedor = GetValue(0);
            }
            return IdProveedor;
        }
        public void Update(Dyn.Database.entities.Proveedor objProveedor)
        {
            objProveedor.Estado = 1;
            AddParameters(objProveedor);
            AddCmdParameter("@Action", 1, ParameterDirection.Input);
            ExecuteNonQuery();
        }

        public void Delete(int idProveedor)
        {
            CreateCommand("usp_Proveedor", true);
            AddCmdParameter("@idProveedor", idProveedor, ParameterDirection.Input);
            AddCmdParameter("@estado", 0, ParameterDirection.Input);
            AddCmdParameter("@Action", 3, ParameterDirection.Input);
            ExecuteNonQuery();
        }

    }
}
