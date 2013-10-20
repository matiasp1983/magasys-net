using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using Dyn.Web.weblogic;

namespace Dyn.Web.controls
{
    public partial class SiteLogin : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (CurrentUser.Instance.IsAuthenticated)
            {
                DoAuthenticatedUser();
            }
            else
            {
                DoAnonymousUser();
            }
        }

        /// <summary>
        /// Muestra controles de usuario autenticado
        /// </summary>
        private void DoAuthenticatedUser()
        {
            AuthenticatedUser.Visible = true;
            AnonymousUser.Visible = false;
        }
        /// <summary>
        /// Muestra controles de usuario anonimo
        /// </summary>
        private void DoAnonymousUser()
        {
            AuthenticatedUser.Visible = false;
            AnonymousUser.Visible = true;
        }

        protected void SignOut_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            CurrentUser.ClearInstace();
            Response.Redirect("/Home.aspx");
        }

        protected void UserLogin_ServerClick(object sender, EventArgs e)
        {
            Dyn.Database.entities.Usuario usuario = new Dyn.Database.entities.Usuario();
            if (txtLogin.Text.Trim().Length == 0)
            {
                return;
            }
            Dyn.Database.logic.Usuario lUsuario = new Dyn.Database.logic.Usuario();
            Dyn.Database.entities.Usuario dbusuario = lUsuario.SeleccionarUsuarioPorLogin(txtLogin.Text);
            //usuario no encontrado
            if (dbusuario == null)
            {
                UserNotvalid.IsValid = false;
                return;
            }
            //password incorrecto
            if (dbusuario.Password != txtUserPassword.Text)
            {
                UserNotvalid.IsValid = false;
                return;
            }

            FormsAuthentication.SetAuthCookie(dbusuario.Login, true);
            CurrentUser.ClearInstace();

            if (dbusuario.Rol == "USUARIO")
            {
                System.Web.HttpContext.Current.Response.Redirect("Home.aspx");
            }
            else
            {
                Response.Redirect("/Admin/HomeAdmin.aspx");
            }
        }
    }
}