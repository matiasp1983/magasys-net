using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dyn.Web.Admin
{
    public partial class Proveedor : System.Web.UI.Page
    {
        private Dyn.Database.logic.Proveedor lProveedor;
        public Dyn.Database.entities.Proveedor Entity;

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
            btnEliminar.Attributes.Add("onclick", "return confirm_delete('Desea eliminar el Proveedor?');");
            if (!IsPostBack)
            {
                this.Master.TituloPagina = "Edici&oacute;n Proveedor";
                lProveedor = new Dyn.Database.logic.Proveedor();
                if (Request["Id"] == null)
                {
                    IdEntity = 0;
                    Entity = new Dyn.Database.entities.Proveedor();
                }
                else
                    if (Request["Id"] != null)
                    {
                        IdEntity = Convert.ToInt32(Request["Id"]);
                        Entity = lProveedor.Load(IdEntity);
                    }
                DataBind();
            }
        }

        public Dyn.Database.entities.Proveedor CargarDatosProveedor()
        {
            Entity = new Dyn.Database.entities.Proveedor();
            Entity.Cuit = txtCuit.Text.Trim();
            Entity.Detalle = txtDetalle.Text.Trim();
            return Entity;
        }

        public void Update()
        {
            lProveedor = new Dyn.Database.logic.Proveedor();
            Entity = new Dyn.Database.entities.Proveedor();
            if (IdEntity == 0)
            {
                Entity = CargarDatosProveedor();
                lProveedor.Insert(Entity);
                ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se guardaron los datos correctamente');location.href('/Admin/ListadoUsuario.aspx');", true);
            }
            else
                if (IdEntity > 0)
                {
                    Entity = CargarDatosProveedor();
                    Entity.IdProveedor = IdEntity;
                    lProveedor.Update(Entity);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se actualizaron los datos correctamente');", true);
                }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            //Dyn.Database.logic.Proveedor rev = new Dyn.Database.logic.Proveedor();
            //if (IdEntity != 0 && IdEntity != int.MinValue)
            //{
            //    lProveedor = new Dyn.Database.logic.Proveedor();
            //    if (rev.SeleccionarProveedorPorGenero(IdEntity) == 0)
            //    {
            //        lProveedor.Delete(IdEntity);
            //        ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se borró el género correctamente');document.location.href='/Admin/ListadoGenero.aspx';", true);
            //    }
            //    else
            //    {
            //        ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('No se puede eliminar el género, porque está asociado a un producto');", true);
            //    }
            //}
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Update();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoProveedor.aspx");
        }

    }
}