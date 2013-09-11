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
            CreateCommand("usp_Clientes", true);
            AddCmdParameter("@nroCliente", objusuario.NroCliente, ParameterDirection.Input);
            
            AddCmdParameter("@tipoDocumento", objusuario.TipoDocumento.IdTipoDocumento, ParameterDirection.Input);
            AddCmdParameter("@nroDocumento", objusuario.NroDocumento, ParameterDirection.Input);

            AddCmdParameter("@nombre", objusuario.Nombre, ParameterDirection.Input);
            AddCmdParameter("@apellido", objusuario.Apellido, ParameterDirection.Input);
            AddCmdParameter("@alias", objusuario.Alias, ParameterDirection.Input);

            AddCmdParameter("@telefono", objusuario.Telefono, ParameterDirection.Input);
            AddCmdParameter("@celular", objusuario.Celular, ParameterDirection.Input);
            AddCmdParameter("@eMail", objusuario.Email, ParameterDirection.Input);

            AddCmdParameter("@domBarrio", objusuario.DomicilioBarrio, ParameterDirection.Input);
            AddCmdParameter("@domCalle", objusuario.DomicilioCalle, ParameterDirection.Input);
            AddCmdParameter("@domNro", objusuario.DomicilioNro, ParameterDirection.Input);
            AddCmdParameter("@domPiso", objusuario.DomicilioPiso, ParameterDirection.Input);
            AddCmdParameter("@domDpto", objusuario.DomicilioDpto, ParameterDirection.Input);
            AddCmdParameter("@domCodigoPostal", objusuario.DomicilioCodPostal, ParameterDirection.Input);
            AddCmdParameter("@domIdLocalidad", objusuario.IdLocalidad, ParameterDirection.Input);

            AddCmdParameter("@fechaAlta", objusuario.FechaAlta, ParameterDirection.Input);
            AddCmdParameter("@idEstado", objusuario.Estado.IdEstado, ParameterDirection.Input);
            AddCmdParameter("@motivoBaja", objusuario.MotivoBaja, ParameterDirection.Input);      
            
        }

        public object Insert(Dyn.Database.entities.Cliente objCliente)
        {
            object IdProveedor = null;
            objCliente.Estado.IdEstado = 1;
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
            objCliente.Estado.IdEstado = 1;
            AddParameters(objCliente);
            AddCmdParameter("@Action", 1, ParameterDirection.Input);
            ExecuteNonQuery();
        }

        public void Delete(int idCliente)
        {
            CreateCommand("usp_Clientes", true);
            AddCmdParameter("@idCliente", idCliente, ParameterDirection.Input);
            AddCmdParameter("@estado", 0, ParameterDirection.Input);
            AddCmdParameter("@Action", 3, ParameterDirection.Input);
            ExecuteNonQuery();
        }
    }
}
