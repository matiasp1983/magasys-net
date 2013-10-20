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

        public Usuario(Int32? idUsu, string nombre, Int32? legajo, string log, string pass, string rl, Int32? est)
        {
            idUsuario = idUsu;
            nombreUsuario = nombre;
            legajoEmpleado = legajo;
            login = log;
            password = pass;
            rol = rl;
            idEstado = est;
        }

        public Usuario(IDataRecord obj)
        {
            idUsuario = Convert.ToInt32(obj["idUsuario"]);
            try
            {
                NombreUsuario = Convert.ToString(obj["nombre"]);
            }
            catch (Exception)
            {
                NombreUsuario = string.Empty;
            }
            try
            {
                Cliente.NroCliente = Convert.ToInt32(obj["nroCliente"]);
            }
            catch (Exception)
            {
                Cliente.NroCliente = 0;
            }
            try
            {
                legajoEmpleado = Convert.ToInt32(obj["legajoEmpleado"]);
            }
            catch (Exception)
            {
                legajoEmpleado = 0;
            }
            try
            {
                Cliente.NroDocumento = Convert.ToInt32(obj["nroDocumento"]);
            }
            catch (Exception)
            {
                Cliente.NroDocumento = 0;
            }
            try
            {
                Cliente.TipoDocumento.IdTipoDocumento = Convert.ToInt32(obj["tipoDocumento"]);
            }
            catch (Exception)
            {
                Cliente.TipoDocumento.IdTipoDocumento = 0;
            }
            try
            {
                Cliente.Nombre = Convert.ToString(obj["nombre"]);
            }
            catch (Exception)
            {
                Cliente.Nombre = string.Empty;
            }
            try
            {
                Cliente.Apellido = Convert.ToString(obj["apellido"]);
            }
            catch (Exception)
            {
                Cliente.Apellido = string.Empty;
            }
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

        private string nombreUsuario;

        public string NombreUsuario
        {
            get { return nombreUsuario; }
            set { nombreUsuario = value; }
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

        private Int32? idEstado;

        public Int32? IdEstado
        {
            get { return idEstado; }
            set { idEstado = value; }
        }
        
        #endregion
    }
}
