using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Dyn.Database.entities;
using System.Collections.Generic;

namespace Dyn.Web.weblogic
{
    public class CurrentUser
    {
        //Llave de acceso a sesion
        private static readonly string key = "SessionCurrentUser";
        public bool IsAuthenticated = false;
        private Usuario usuario;

        public Usuario Usuario
        {
            get
            {
                return usuario;
            }
            set
            {
                usuario = value;
                System.Web.HttpContext.Current.Session[key] = this;
            }
        }

        /// <summary>
        /// Elimina la instancia de usuario actual
        /// </summary>
        public static void ClearInstace()
        {
            if (System.Web.HttpContext.Current.Session[key] != null)
            {
                System.Web.HttpContext.Current.Session.Remove(key);
            }
        }
        /// <summary>
        /// Retorna una instancia con el context enviado
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static CurrentUser GetInstance(System.Web.HttpContext context)
        {
            CurrentUser current;
            ///Consulta la identidad actual para determinar si el usuario esta autenticado
            ///si la identidad determina que el usuario esta autenticado consulta la 
            ///informacion del usuario de la base de datos
            System.Security.Principal.IIdentity user =
                System.Web.HttpContext.Current.User.Identity;
            current = (CurrentUser)context.Session[key];
            if (!user.IsAuthenticated)
            {
                return new CurrentUser();
            }
            if (current == null)
            {
                current = new CurrentUser();
                Dyn.Database.logic.Usuario LUsuario = new Dyn.Database.logic.Usuario();
                Dyn.Database.entities.Usuario dbusuario = new Usuario();
                dbusuario = LUsuario.SeleccionarUsuarioPorLogin(user.Name);
                if (dbusuario != null)
                {
                    current.usuario = dbusuario;
                    current.IsAuthenticated = true;
                }
                else
                {
                    return current;
                }

                //current.roles = new UsuarioRol().Select(dbusuario);
                context.Session[key] = current;
            }
            return current;
        }

        /// <summary>
        /// Retorna una instancia con objeto de sesion actual
        /// </summary>
        /// <returns></returns>
        public static CurrentUser Instance
        {
            get
            {
                return GetInstance(System.Web.HttpContext.Current);
            }

        }

        public static void Regresar()
        {
            if (CurrentUser.Instance.Usuario.Rol == "EMPLEADO")
            {
                System.Web.HttpContext.Current.Response.Redirect("/Admin/HomeAdmin.aspx");
            }
        }

        public static void RegresarHome()
        {
            if (CurrentUser.Instance.Usuario == null)
            {
                System.Web.HttpContext.Current.Response.Redirect("/Home.aspx");
            }
            else
            {
                if (CurrentUser.Instance.Usuario.Rol != "CLIENTE")
                {
                    System.Web.HttpContext.Current.Response.Redirect("/Home.aspx");
                }
            }
        }

    }
}