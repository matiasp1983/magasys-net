using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dyn.Web.Admin
{
    public partial class MostrarReservaEdicion : System.Web.UI.Page
    {
        private Dyn.Database.logic.ReservaEdicion lReservaEdicion;
        public Dyn.Database.entities.ReservaEdicion Entity;

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
            Dyn.Database.logic.Cliente lCliente = new Database.logic.Cliente();
            Dyn.Database.entities.Cliente eCliente = new Database.entities.Cliente();
            Dyn.Database.logic.ProductoEdicion lProductoEdicion = new Database.logic.ProductoEdicion();
            Dyn.Database.entities.ProductoEdicion eProductoEdicion = new Database.entities.ProductoEdicion();
            Dyn.Database.logic.Producto lProducto = new Database.logic.Producto();
            Dyn.Database.entities.Producto eProducto = new Database.entities.Producto();

            if (!IsPostBack)
            {
                this.Master.TituloPagina = "Visualizar Reservas por Edici&oacute;n";
                lReservaEdicion = new Dyn.Database.logic.ReservaEdicion();
                if (Request["Id"] != null)
                {
                    IdEntity = Convert.ToInt32(Request["Id"]);
                    Entity = lReservaEdicion.Load(IdEntity);
                    eCliente = lCliente.Load((int)(Entity.NroCliente));
                    lblNroClienteText.Text = eCliente.NroCliente.ToString();
                    lblNombApellText.Text = eCliente.Nombre.ToString() + " " + eCliente.Apellido.ToString();
                    eProductoEdicion = lProductoEdicion.Load(0, (int)Entity.IdProductoEdicion);
                    eProducto = lProducto.Load((int)eProductoEdicion.IdProducto);
                    lblidProductoText.Text = eProducto.IdProducto.ToString();
                    lblNombreProductoText.Text = eProducto.Nombre.ToString();
                    lblEdicionText.Text = eProductoEdicion.IdProductoEdicion.ToString();
                }
                DataBind();
            }
        }

        protected void btnVolveraListadoReserva_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoReserva.aspx");
        }
    }
}