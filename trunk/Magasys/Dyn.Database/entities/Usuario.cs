using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.entities
{
    public class Usuario
    {
        #region Constructores

        public Usuario() { }

        public Usuario(Int32? idUsu, Int32? legajo, string log, string pass, string rl)
        {
            idUsuario = idUsu;
            legajoEmpleado = legajo;
            login = log;
            password = pass;
            rol = rl;
        }

        public Usuario(IDataRecord obj)
        {
            idUsuario = Convert.ToInt32(obj["idUsuario"]);
            Cliente.NroCliente = Convert.ToInt32(obj["nroCliente"]);
            legajoEmpleado = Convert.ToInt32(obj["legajoEmpleado"]);
            Cliente.NroDocumento = Convert.ToInt32(obj["nroDocumento"]);
            Cliente.TipoDocumento.IdTipoDocumento = Convert.ToInt32(obj["tipoDocumento"]);
            Cliente.Nombre = Convert.ToString(obj["nombre"]);
            Cliente.Apellido = Convert.ToString(obj["apellido"]);
            login = Convert.ToString(obj["login"]);
            password = Convert.ToString(obj["password"]);
            rol = Convert.ToString(obj["rol"]);
        }

        #endregion

        #region Propiedades

        private Int32? idUsuario;

        public Int32? IdUsuario
        {
            get { return idUsuario; }
            set { idUsuario = value; }
        }

        private Cliente cliente = new Cliente();

        public Cliente Cliente
        {
            get { return cliente; }
            set { cliente = value; }
        }

        private Int32? legajoEmpleado;

        public Int32? LegajoEmpleado
        {
            get { return legajoEmpleado; }
            set { legajoEmpleado = value; }
        }

        private string login;

        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        private string rol;

        public string Rol
        {
            get { return rol; }
            set { rol = value; }
        }

        private Int16? idEstado;

        public Int16? IdEstado
        {
            get { return idEstado; }
            set { idEstado = value; }
        }
        
        #endregion
    }
}
