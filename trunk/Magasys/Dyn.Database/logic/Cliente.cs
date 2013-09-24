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
            CreateCommand("usp_Clientes", true);
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
        public List<Dyn.Database.entities.Cliente> SeleccionarClientePorNombrePaginadoAdmin(string nombre, string apellido, string alias, int? nroDoc, int? tipoDoc, int paginaactual, ref int numeropaginas)
        {
            List<Dyn.Database.entities.Cliente> Collection = new List<Dyn.Database.entities.Cliente>();
            Dyn.Database.logic.Estado lEstado = new Dyn.Database.logic.Estado();
            CreateCommand("usp_Clientes", true);
            AddCmdParameter("@nombre", nombre, ParameterDirection.Input);
            AddCmdParameter("@apellido", apellido, ParameterDirection.Input);
            AddCmdParameter("@alias", alias, ParameterDirection.Input);
            AddCmdParameter("@nroDocumento", nroDoc, ParameterDirection.Input);
            AddCmdParameter("@tipoDocumento", tipoDoc, ParameterDirection.Input);
            AddCmdParameter("@Action", 4, ParameterDirection.Input);
            AddCmdParameter("@idEstado", lEstado.BuscarEstado("Clientes", "Alta"), ParameterDirection.Input);

            ExecuteReader();
            while (Read())
            {
                Collection.Add(new Dyn.Database.entities.Cliente(GetDataReader()));
            }
            DataSet ds = GetDataSet();
            //numeropaginas = (int)GetValueCmdParameter("@TotalRecords");
            return Collection;
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
            AddParameters(objCliente);
            AddCmdParameter("@Action", 1, ParameterDirection.Input);
            ExecuteNonQuery();
        }

        public void Delete(Dyn.Database.entities.Cliente objCliente)
        {
            CreateCommand("usp_Clientes", true);
            AddParameters(objCliente);
            AddCmdParameter("@Action", 3, ParameterDirection.Input);
            ExecuteNonQuery();
        }

        public DataSet BuscarClientes(string alias, string nombre, string apellido, int tipoDoc, int nroDoc)
        {
            CreateCommand("usp_Clientes", true);
            AddCmdParameter("@alias", alias, ParameterDirection.Input);
            AddCmdParameter("@nombre", nombre, ParameterDirection.Input);
            AddCmdParameter("@apellido", apellido, ParameterDirection.Input);
            AddCmdParameter("@tipoDocumento", tipoDoc, ParameterDirection.Input);
            if (nroDoc != 0)
            {
                AddCmdParameter("@nroDocumento", nroDoc, ParameterDirection.Input);
            }
            AddCmdParameter("@Action", 4, ParameterDirection.Input);
            DataSet ds = GetDataSet();
            return ds;
        }
    }
}
