using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.logic
{
    public class Usuario : FactoryBase
    {
        public Usuario() {}

        public List<Dyn.Database.entities.Usuario> BuscarUsuarios(string nombre, string apellido, int tipoDoc, int nroDoc)
        {
            List<Dyn.Database.entities.Usuario> Collection = new List<Dyn.Database.entities.Usuario>();
            CreateCommand("usp_Usuario", true);
            AddCmdParameter("@nombre", nombre, ParameterDirection.Input);
            AddCmdParameter("@apellido", apellido, ParameterDirection.Input);
            AddCmdParameter("@tipoDocumento", tipoDoc, ParameterDirection.Input);
            if (nroDoc != 0)
            {
                AddCmdParameter("@nroDocumento", nroDoc, ParameterDirection.Input);
            }
            AddCmdParameter("@Action", 0, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                Collection.Add(new Dyn.Database.entities.Usuario(GetDataReader()));
            }
            return Collection;
        }

        public Dyn.Database.entities.Usuario SeleccionarUsuarioPorLogin(string login)
        {
            Dyn.Database.entities.Usuario objusuario = new Dyn.Database.entities.Usuario();
            CreateCommand("usp_Usuario", true);
            AddCmdParameter("@login", login, ParameterDirection.Input);
            AddCmdParameter("@Action", 4, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                objusuario = new Dyn.Database.entities.Usuario(GetDataReader());
            }
            return objusuario;
        }

        public int VerificaNombreUsuario(string login)
        {
            CreateCommand("usp_Usuario", true);
            AddCmdParameter("@login", login, ParameterDirection.Input);
            AddCmdParameter("@Action", 5, ParameterDirection.Input);
            ExecuteReader();
            int i = 0;
            if (Read())
            {
                i++;
            }
            return i;
        }

        private void AddParameters(Dyn.Database.entities.Usuario objUsuario)
        {
            CreateCommand("usp_Usuario", true);
            if (objUsuario.Cliente.NroCliente > 0)
            {
                AddCmdParameter("@nroCliente", objUsuario.Cliente.NroCliente, ParameterDirection.Input);
            }
            if (objUsuario.LegajoEmpleado > 0)
            {
                AddCmdParameter("@legajo", objUsuario.LegajoEmpleado, ParameterDirection.Input);
            }
            AddCmdParameter("@nombreUsuario", objUsuario.NombreUsuario, ParameterDirection.Input);
            AddCmdParameter("@login", objUsuario.Login, ParameterDirection.Input);
            AddCmdParameter("@password", objUsuario.Password, ParameterDirection.Input);
            AddCmdParameter("@rol", objUsuario.Rol, ParameterDirection.Input);
            AddCmdParameter("@idEstado", objUsuario.IdEstado, ParameterDirection.Input);
        }

        public object Insert(Dyn.Database.entities.Usuario objUsuario)
        {
            object IdUsuario = null;
            AddParameters(objUsuario);
            AddCmdParameter("@Action", 2, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                IdUsuario = GetValue(0);
            }
            return IdUsuario;
        }
    }
}
