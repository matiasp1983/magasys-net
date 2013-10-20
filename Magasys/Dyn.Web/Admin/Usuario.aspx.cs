using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dyn.Database.logic;
using Dyn.Database.entities;
using Dyn.Web.weblogic;

namespace Dyn.Web.Admin
{
    public partial class Usuario : System.Web.UI.Page
    {
        public Dyn.Database.entities.Usuario Entity;
        private Dyn.Database.logic.Usuario lUsuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CurrentUser.Regresar();
                this.Master.TituloPagina = "Edici&oacute;n Usuario";
            }
        }

        protected void Aceptar_Click(object sender, EventArgs e)
        {
            Update();
            LimpiarCampos();
        }

        public Dyn.Database.entities.Usuario CargarDatosUsuario()
        {
            Dyn.Database.logic.Estado lEstado = new Dyn.Database.logic.Estado();
            Entity = new Dyn.Database.entities.Usuario();
            Entity.IdEstado = lEstado.BuscarEstado("Usuarios", "Alta");
            Entity.NombreUsuario = txtNombreUsuario.Text.Trim();
            Entity.Login = txtLogin.Text.Trim();
            Entity.Rol = ddlRol.SelectedValue;
            Entity.Password = txtPassword.Text.Trim();
            return Entity;
        }

        public void Update()
        {
            lUsuario = new Dyn.Database.logic.Usuario();
            Entity = new Dyn.Database.entities.Usuario();
            if (lUsuario.VerificaNombreUsuario(txtLogin.Text.Trim()) == 0)
            {
                Entity = CargarDatosUsuario();
                lUsuario.Insert(Entity);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Se guardaron los datos correctamente.');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Ya existe ese nombre de usuario.');", true);
            }

            //if (IdEntity == 0)
            //{
            //Entity = CargarDatosUsuario();
            //lUsuario.Insert(Entity);
            //ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se guardaron los datos correctamente');", true);
            //}
            //else
            //    if (IdEntity > 0)
            //    {
            //        Entity = CargarDatosGenero();
            //        Entity.IdGenero = IdEntity;
            //        lGenero.Update(Entity);
            //        ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se actualizaron los datos correctamente');", true);
            //    }
        }

        public void LimpiarCampos()
        {
            txtNombreUsuario.Text = string.Empty;
            txtLogin.Text = string.Empty;
            ddlRol.SelectedValue = "ADMINISTRADOR";
            txtPassword.Text = string.Empty;
            txtRepetirPassword.Text = string.Empty;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/HomeAdmin.aspx");
        }
    }
}