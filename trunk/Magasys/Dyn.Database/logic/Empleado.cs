using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.logic
{
    public class Empleado : FactoryBase  
    {
        public Empleado () {}

        public Dyn.Database.entities.Empleado Load(int nroEmpleado)
        {
            Dyn.Database.entities.Empleado objEmpleado = new Dyn.Database.entities.Empleado();
            CreateCommand("ups_Empleados", true);
            AddCmdParameter("@nroEmpleado", nroEmpleado, ParameterDirection.Input);
            AddCmdParameter("@Action", 0, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                objEmpleado = new Dyn.Database.entities.Empleado(GetDataReader());
            }
            return objEmpleado;
        }
        public List<Dyn.Database.entities.Empleado> SeleccionarEmpleadoPorNombrePaginadoAdmin(int? tipoDoc, int? nroDoc, string apellido, string nombre, int paginaactual, ref int numeropagina)
        {
            List<Dyn.Database.entities.Empleado> Collection = new List<Dyn.Database.entities.Empleado>();
            Dyn.Database.logic.Estado lEstado = new Dyn.Database.logic.Estado();
            CreateCommand("ups_Empleados", true);
            AddCmdParameter("@tipoDocumento", tipoDoc, ParameterDirection.Input);
            AddCmdParameter("@nroDocumento", nroDoc, ParameterDirection.Input);
            AddCmdParameter("@apellido", apellido, ParameterDirection.Input);
            AddCmdParameter("@nombre", nombre, ParameterDirection.Input);
            AddCmdParameter("@Action", 5, ParameterDirection.Input);
            AddCmdParameter("@idEstado", lEstado.BuscarEstado ("Empleado", "Alta"), ParameterDirection.Input);

            ExecuteReader();
            while (Read())
            {
                Collection.Add(new Dyn.Database.entities.Empleado(GetDataReader()));
            }
            DataSet ds = GetDataSet();
            return Collection;
        }

        public List<Dyn.Database.entities.Empleado> SeleccionarEmpleado(int? tipoDoc, int? nroDoc, string apellido, string nombre)
        {
            List<Dyn.Database.entities.Empleado> Collection = new List<Dyn.Database.entities.Empleado>();
            Dyn.Database.logic.Estado lEstado = new Dyn.Database.logic.Estado();
            CreateCommand("ups_Empleados", true);
            AddCmdParameter("@tipoDocumento", tipoDoc, ParameterDirection.Input);
            if (nroDoc != 0)
            {
                AddCmdParameter("@nroDocumento", nroDoc, ParameterDirection.Input);
            }
            AddCmdParameter("@apellido", apellido, ParameterDirection.Input);
            AddCmdParameter("@nombre", nombre, ParameterDirection.Input);
            AddCmdParameter("@Action", 5, ParameterDirection.Input);
            AddCmdParameter("@idEstado", lEstado.BuscarEstado("Empleado", "Alta"), ParameterDirection.Input);
            
            ExecuteReader();
            while (Read())
            {
                Collection.Add(new Dyn.Database.entities.Empleado (GetDataReader()));
            }
            DataSet ds = GetDataSet();
            return Collection;
        }

        public void AddParameters(Dyn.Database.entities.Empleado objusuario)
        {
            CreateCommand("ups_Empleados", true);
            AddCmdParameter("nroEmpleado", objusuario.NroEmpleado, ParameterDirection.Input);
            AddCmdParameter("tipoDocumento", objusuario.TipoDocumento.IdTipoDocumento, ParameterDirection.Input);
            AddCmdParameter("nroDocumento", objusuario.NroDocumento, ParameterDirection.Input);
            AddCmdParameter("apellido", objusuario.Apellido, ParameterDirection.Input);
            AddCmdParameter("nombre", objusuario.Nombre, ParameterDirection.Input);
            AddCmdParameter("telefono", objusuario.Telefono, ParameterDirection.Input);
            AddCmdParameter("celular", objusuario.Celular, ParameterDirection.Input);
            AddCmdParameter("email", objusuario.Email, ParameterDirection.Input);
            AddCmdParameter("domBarrio", objusuario.Email, ParameterDirection.Input);
            AddCmdParameter("domCalle", objusuario.DomCalle, ParameterDirection.Input);
            AddCmdParameter("domNro", objusuario.DomNro, ParameterDirection.Input);
            AddCmdParameter("domPiso", objusuario.DomicilioPiso, ParameterDirection.Input);
            AddCmdParameter("domDpto", objusuario.DomicilioDpto, ParameterDirection.Input);
            AddCmdParameter("domCodigoPostal", objusuario.DomicilioCodPostal, ParameterDirection.Input);
            AddCmdParameter("domIdLocalidad", objusuario.IdLocalidad, ParameterDirection.Input);
            AddCmdParameter("fechaAlta", objusuario.FechaAlta, ParameterDirection.Input);
            AddCmdParameter("idEstado", objusuario.Estado.IdEstado, ParameterDirection.Input);
            AddCmdParameter("motivoBaja", objusuario.MotivoBaja, ParameterDirection.Input);
        }

        public object Insert(Dyn.Database.entities.Empleado objEmpleado)
        {
            object idEmpleado = null;
            AddParameters(objEmpleado);

            AddCmdParameter("fechaAlta", objEmpleado.FechaAlta, ParameterDirection.Input);
            AddCmdParameter("@Action", 2, ParameterDirection.Input);

            ExecuteReader();
            while (Read())
            {
                idEmpleado = GetValue(0);
            }
            return idEmpleado;
        }

        public void Update(Dyn.Database.entities.Empleado objEmpleado)
        {
            AddParameters(objEmpleado);
            AddCmdParameter("@Action", 2, ParameterDirection.Input);
            ExecuteNonQuery();
        }

        public void Delete(Dyn.Database.entities.Empleado objEmpleado)
        {
            CreateCommand("ups_Empleados", true);
            AddParameters(objEmpleado);
            AddCmdParameter("@Action", 3, ParameterDirection.Input);
            ExecuteNonQuery();
        }

        public DataSet BuscarCliente(int? tipoDoc, int? nroDoc, string apellido, string nombre)
        {
            CreateCommand("ups_Empleados", true);
            AddCmdParameter("tipoDocumento", tipoDoc, ParameterDirection.Input);
            if (nroDoc != 0)
            {
                AddCmdParameter("nroDocumento", nroDoc, ParameterDirection.Input);
            }
            AddCmdParameter("apellido", apellido, ParameterDirection.Input);
            AddCmdParameter("nombre", nombre, ParameterDirection.Input);
            AddCmdParameter("@Action", 4, ParameterDirection.Input);

            DataSet ds = GetDataSet();
            return ds;
        }
    }
}
