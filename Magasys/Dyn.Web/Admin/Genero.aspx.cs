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
    public partial class Genero : System.Web.UI.Page
    {
        private Dyn.Database.logic.Genero lGenero;
        public Dyn.Database.entities.Genero Entity;

        public int IdEntity
        {
            get
            {
                return (int)ViewState["IdEntity"];
            }
            set
            {
                ViewState["IdEntity"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CurrentUser.Regresar();
                this.Master.TituloPagina = "Edici&oacute;n G&eacute;nero";
                lGenero = new Dyn.Database.logic.Genero();
                if (Request["Id"] == null)
                {
                    IdEntity = 0;
                    Entity = new Dyn.Database.entities.Genero();
                    btnEliminar.Visible = false;
                    btnModificar.Visible = false;
                }
                else
                    if (Request["Id"] != null)
                    {
                        IdEntity = Convert.ToInt32(Request["Id"]);
                        Entity = lGenero.Load(IdEntity);
                        btnEliminar.Visible = true;
                        txtDescripcion.Enabled = false;
                        txtNombre.Enabled = false;
                        btnGuardar.Enabled = false;
                        btnModificar.Visible = true;
                    }
                DataBind();
            }
           
        }

        public Dyn.Database.entities.Genero CargarDatosGenero()
        {
            Entity = new Dyn.Database.entities.Genero();
            Entity.Nombre = txtNombre.Text.Trim();
            Entity.Descripcion = txtDescripcion.Text.Trim();
           
            return Entity;
        }

        public void Update()
        {
            lGenero = new Dyn.Database.logic.Genero();
            Entity = new Dyn.Database.entities.Genero();
            if (IdEntity == 0)
            {
                Entity = CargarDatosGenero();
                
                lGenero.Insert(Entity);
                ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se guardaron los datos correctamente');", true);
            }
            else
                if (IdEntity > 0)
                {
                    Entity = CargarDatosGenero();
                    Entity.IdGenero = IdEntity;
                    lGenero.Update(Entity);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se actualizaron los datos correctamente');", true);
                    Response.Redirect("ListadoGenero.aspx?IdMenuCategoria=27");
                }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Dyn.Database.logic.Genero gen = new Dyn.Database.logic.Genero();
            if (IdEntity != 0 && IdEntity != int.MinValue)
            {
                lGenero = new Dyn.Database.logic.Genero();
                if (gen.VerificaRelacionGenero(IdEntity) == 0)
                {
                    lGenero.Delete(IdEntity);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se borró el género correctamente');document.location.href='/Admin/ListadoGenero.aspx';", true);
                    Response.Redirect("ListadoGenero.aspx?IdMenuCategoria=27");
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('No se puede eliminar el género, porque está asociado a un producto');", true);
                }
            }
        }

        public void LimpiarCampos()
        {
            txtDescripcion.Text = string.Empty;
            txtNombre.Text = string.Empty;            
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Update();
            LimpiarCampos();
           // Response.Redirect("ListadoGenero.aspx?IdMenuCategoria=27");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeAdmin.aspx");
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            txtNombre.Enabled = true;
            txtDescripcion.Enabled = true;
            btnGuardar.Enabled = true;
            btnModificar.Enabled = false;
        }

    }
}