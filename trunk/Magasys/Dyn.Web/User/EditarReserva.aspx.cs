using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dyn.Web.User
{
    public partial class EditarReserva : System.Web.UI.Page
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
            Dyn.Database.logic.Producto lProducto = new Database.logic.Producto();
            Dyn.Database.entities.Producto eProducto = new Database.entities.Producto();

            if (!IsPostBack)
            {
                lReserva = new Dyn.Database.logic.Reserva();
                if (Request["Id"] != null)
                {
                    IdEntity = Convert.ToInt32(Request["Id"]);
                    Entity = lReserva.Load_Reserva(IdEntity);
                    ddlTipoReserva.SelectedValue = Entity.TipoReserva;
                    ucBuscarProducto.CodigoProducto = Convert.ToInt32(Entity.IdProducto);
                    eProducto = lProducto.Load((int)Entity.IdProducto);
                    lblidProductoText.Text = eProducto.IdProducto.ToString();
                    lblNombreProductoText.Text = eProducto.Nombre.ToString();
                    lblFechaText.Text = string.Format("{0:dd/MM/yyyy}", Entity.FechaReserva);
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
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Mensaje", "alert(\'Se guardaron los datos correctamente');location.href='MisReservas.aspx';", true);
        }

        private void EditarReservaProducto()
        {
            Dyn.Database.logic.Estado lEstado = new Dyn.Database.logic.Estado();
            Entity = new Database.entities.Reserva();
            lReserva = new Database.logic.Reserva();
            String nombreEstado = String.Empty;

            Entity.CodReserva = IdEntity;
            Entity.FechaInicio = Convert.ToDateTime(calFechaInicio.CalendarDate);
            Entity.FechaFin = Convert.ToDateTime(calFechaFin.CalendarDate);
            Entity.TipoReserva = ddlTipoReserva.SelectedValue.ToString();
            Entity.IdProducto = ucBuscarProducto.CodigoProducto;
            Entity.Cantidad = Convert.ToInt16(txtCantidad.Text);
            Entity.IdEstado = lEstado.BuscarEstado("Reservas", "Confirmado");

            lReserva.Update(Entity);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("MisReservas.aspx");
        }
    }
}