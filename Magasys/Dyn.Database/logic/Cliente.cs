using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.logic
{
    public class Cliente : FactoryBase
    {

        public Cliente() { }

        public Dyn.Database.entities.Cliente Load(int nroCliente)
        {
            Dyn.Database.entities.Cliente objCliente = new Dyn.Database.entities.Cliente();
            CreateCommand("usp_Cliente", true);
            AddCmdParameter("@nroCliente", nroCliente, ParameterDirection.Input);
            AddCmdParameter("@Action", 0, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                objCliente = new Dyn.Database.entities.Cliente(GetDataReader());
            }
            return objCliente;
        }

        //public List<Dyn.Database.entities.Cliente> SeleccionarTodosLosProveedores()
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
        //public DataSet SeleccionarProveedorPorNombrePaginadoAdmin(string razonSocial, int paginaactual, ref int numeropaginas)
        //{
        //    CreateCommand("usp_SeleccionarProveedoresPorNombrePaginado", true);
        //    AddCmdParameter("@razonSocial", razonSocial, ParameterDirection.Input);
        //    AddCmdParameter("@CurrentPage", paginaactual, ParameterDirection.Input);
        //    AddCmdParameter("@PageSize", 100, ParameterDirection.Input);
        //    AddCmdParameter("@TotalRecords", ParameterDirection.Output);
        //    DataSet ds = GetDataSet();
        //    numeropaginas = (int)GetValueCmdParameter("@TotalRecords");
        //    return ds;
        //}
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

        private void AddParameters(Dyn.Database.entities.Cliente objusuario)
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

            AddCmdParameter("@telefono", objusuario.Telefono, ParameterDirection.Input);
            AddCmdParameter("@nombre", objusuario.Nombre, ParameterDirection.Input);
        }

        public object Insert(Dyn.Database.entities.Cliente objCliente)
        {
            object IdProveedor = null;
            objCliente.Estado = 1;
            AddParameters(objCliente);


            AddCmdParameter("@Action", 2, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                IdProveedor = GetValue(0);
            }
            return IdProveedor;
        }
        public void Update(Dyn.Database.entities.Cliente objCliente)
        {
            objCliente.Estado = 1;
            AddParameters(objCliente);
            AddCmdParameter("@Action", 1, ParameterDirection.Input);
            ExecuteNonQuery();
        }

        public void Delete(int idCliente)
        {
            CreateCommand("usp_Cliente", true);
            AddCmdParameter("@idCliente", idCliente, ParameterDirection.Input);
            AddCmdParameter("@estado", 0, ParameterDirection.Input);
            AddCmdParameter("@Action", 3, ParameterDirection.Input);
            ExecuteNonQuery();
        }
    }
}
