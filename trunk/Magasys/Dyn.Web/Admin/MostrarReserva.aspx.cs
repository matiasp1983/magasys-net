using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dyn.Web.Admin
{
    public partial class ModificarReserva : System.Web.UI.Page
    {
        private Dyn.Database.logic.Reserva lReserva;
        public Dyn.Database.entities.Reserva Entity;
        
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
            Dyn.Database.logic.Producto lProducto = new Database.logic.Producto();
            Dyn.Database.entities.Producto eProducto = new Database.entities.Producto();

            if (Request["Id"] != null)
            {
                this.Master.TituloPagina = "Visualizar Reserva";
                lReserva = new Dyn.Database.logic.Reserva();
                IdEntity = Convert.ToInt32(Request["Id"]);
                Entity = lReserva.Load_Reserva(IdEntity);
                eCliente = lCliente.Load((int)(Entity.NroCliente));
                lblNroClienteText.Text = eCliente.NroCliente.ToString();
                lblNombApellText.Text = eCliente.Nombre.ToString() + " " + eCliente.Apellido.ToString();
                eProducto = lProducto.Load((int)Entity.IdProducto);
                lblidProductoText.Text = eProducto.IdProducto.ToString();
                lblNombreProductoText.Text = eProducto.Nombre.ToString();
                lblFechaText.Text = string.Format("{0:dd/MM/yyyy}", Entity.FechaReserva);
            }
            DataBind();
        }

        protected void btnVolveraListadoReserva_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoReserva.aspx");
        }
    }
}