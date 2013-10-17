using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using Entidades;
//using DAL;
using System.Web.Security;

namespace PaginaKiosko
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void BtnConectarse_Click(object sender, EventArgs e) { }
        //{
        //    Session["Usuario"] = DAOUsuarios.ValidarUsuario(TxtUsuario.Text, TxtContraseña.Text);
        //    Usuario user = (Usuario)Session["Usuario"];
        //    try
        //    {
        //        if (user != null)
        //        {
        //            String roles;
        //            switch (user.Rol)
        //            { 
        //                case 'A':
        //                    roles = "ADMIN";
        //                    break;
        //                case 'U':
        //                    roles = "USER";
        //                    break;
        //                case 'C':
        //                    roles = "CLIENT";
        //                    break;
        //                default:
        //                    roles = "ANONIMO";
        //                    break;
        //            }
        //            FormsAuthenticationTicket autTicket = new FormsAuthenticationTicket(1, user.Nombre, DateTime.Now, DateTime.Now.AddMinutes(60), false, roles);
        //            String encriptedTicket = FormsAuthentication.Encrypt(autTicket);
        //            HttpCookie autCookie = new HttpCookie(".Kiosko", encriptedTicket);
        //            Response.Cookies.Add(autCookie);
        //            // Response.Redirect(FormsAuthentication.GetRedirectUrl(TxtUsuario.Text, false));
        //            Response.Redirect("Default.aspx");
                    
        //        }
        //        else
        //        {
        //            LabInfo.Text = "USUARIO INEXISTENTE O CLAVE INCORRECTA";
        //            LabInfo.Visible = true;
                    
        //        }
        //    }
        //        catch (Exception ex)
        //        {   
        //            LabInfo.Text = "OCURRIO UN ERROR " + ex.Message;
        //            LabInfo.Visible = true;
        //        }
            
        //}   
    }
}