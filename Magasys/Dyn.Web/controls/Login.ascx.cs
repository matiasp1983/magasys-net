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
    public partial class Login : System.Web.UI.UserControl
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
        }
        /// <summary>
        /// Muestra controles de usuario anonimo
        /// </summary>
        private void DoAnonymousUser()
        {
            AuthenticatedUser.Visible = false;
        }

        protected void SignOut_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            CurrentUser.ClearInstace();
            Response.Redirect("/Home.aspx");
        }             
    }
}