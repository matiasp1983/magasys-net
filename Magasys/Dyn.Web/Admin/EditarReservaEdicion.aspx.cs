using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dyn.Web.Admin
{
    public partial class EditarReservaEdicion : System.Web.UI.Page
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
                this.Master.TituloPagina = "Reservas por Edici&oacute;n";
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
                    Session["Cantidad"] = null;
                    Session["Cantidad"] = Entity.Cantidad.ToString();
                    lblFechaText.Text = string.Format("{0:dd/MM/yyyy}", Entity.FechaReservaEdicion);
                }
                DataBind();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (calFechaInicio.CalendarDateString == string.Empty)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Seleccione la fecha de Inicio de reserva');", true);
                return;
            }

            if (calFechaInicio.CalendarDate > calFechaFin.CalendarDate)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('La fecha de Inicio debe ser menor que la fecha Fin');", true);
                return;
            }

            if (int.Parse(txtCantidad.Text) <= 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Ingrese la cantidad de productos');", true);
                return;
            }

            EditarReservaProducto();
            ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Se guardaron los datos correctamente');", true);
        }

        private void EditarReservaProducto()
        {
            Dyn.Database.entities.ProductoEdicion productoEdicion = new Database.entities.ProductoEdicion();
            Dyn.Database.logic.ProductoEdicion lProdEdic = new Dyn.Database.logic.ProductoEdicion();
            Dyn.Database.logic.Estado lEstado = new Dyn.Database.logic.Estado();
            Entity = new Database.entities.ReservaEdicion();
            lReservaEdicion = new Database.logic.ReservaEdicion();
            String nombreEstado = String.Empty;
            int edicion = 0;
            int idProducto = 0;
            int cantidad = 0;

            Entity.CodReservaEdicion = IdEntity;
            Entity.FechaInicio = Convert.ToDateTime(calFechaInicio.CalendarDate);
            Entity.FechaFin = Convert.ToDateTime(calFechaFin.CalendarDate);
            Entity.IdEstado = lEstado.BuscarEstado("Reservas", "Confirmado");

            if (ucBuscarProductoEdicion.CodigoProducto > 0)
            {
                idProducto = ucBuscarProductoEdicion.CodigoProducto;
                edicion = ucBuscarProductoEdicion.IdEdicion;
                cantidad = int.Parse(txtCantidad.Text.Trim());
            }
            else
            {
                idProducto = int.Parse(lblidProductoText.Text.Trim());
                edicion = int.Parse(lblEdicionText.Text.Trim());

                cantidad = int.Parse(txtCantidad.Text.Trim()) - int.Parse(Session["Cantidad"].ToString());
            }

            Entity.IdProductoEdicion = edicion;
            Entity.Cantidad = Convert.ToInt16(txtCantidad.Text);
            lReservaEdicion.Update(Entity);

            productoEdicion = lProdEdic.Load(idProducto, edicion);
            productoEdicion.CantidadUnidades -= cantidad;  // Actualizar stock
            lProdEdic.Update(productoEdicion); // Se actualiza la tabla ProductoEdicion  
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeAdmin.aspx");
            // Response.Redirect("/Admin/ListadoReserva.aspx");
        }
    }
}