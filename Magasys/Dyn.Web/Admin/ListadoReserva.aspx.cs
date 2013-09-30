using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dyn.Web.Admin
{
    public partial class ListadoReserva : System.Web.UI.Page
    {
        private Dyn.Database.logic.Reserva lReserva;
        private Dyn.Database.logic.ReservaEdicion lReservaEdicion;
        //private static List<Dyn.Database.entities.Reserva> listaClientes = new List<Database.entities.Reserva>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Master.TituloPagina = "Reservas";
                LlenarEstado();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            cargarGridReserva();
        }

        private void LlenarEstado()
        {
            Dyn.Database.logic.Estado lEstado = new Dyn.Database.logic.Estado();
            List<Dyn.Database.entities.Estado> listaEstado = lEstado.BuscarEstadoPorAmbito("Reservas");
            ListItem li;
            for (int i = 0; i < listaEstado.Count; i++)
            {
                li = new ListItem();
                li = new ListItem(listaEstado[i].Nombre, listaEstado[i].IdEstado.ToString());
                ddlEstado.Items.Add(li);
            }
        }

        private void cargarGridReserva()
        {
            lReserva = new Dyn.Database.logic.Reserva();
            lReservaEdicion = new Database.logic.ReservaEdicion();
            DateTime fecha = new DateTime();
            string tipoReserva = string.Empty;
            gridReservas.DataSource = null;
            gridReservasEdicion.DataSource = null;
            if (ddlTipoReserva.SelectedValue != "Seleccionar...")
            {
                tipoReserva = ddlTipoReserva.SelectedValue;
            }

            fecha = Convert.ToDateTime(calFechaReserva.CalendarDate);

            if (rdbReserva.Checked)
            {
                List<Dyn.Database.entities.Reserva> listaReservas = lReserva.BuscarReservas(fecha,
                    tipoReserva, txtAlias.Text, txtNombre.Text, txtApellido.Text, Convert.ToInt32(ddlEstado.SelectedValue));
                gridReservas.DataSource = listaReservas;
                gridReservas.DataKeyNames = new String[] { "codReserva" };
            }
            else
            {
                List<Dyn.Database.entities.ReservaEdicion> listaReservasEdicion = lReservaEdicion.BuscarReservasEdicion(fecha,
                    tipoReserva, txtAlias.Text, txtNombre.Text, txtApellido.Text, Convert.ToInt32(ddlEstado.SelectedValue));
                gridReservasEdicion.DataSource = listaReservasEdicion;
                gridReservasEdicion.DataKeyNames = new String[] { "codReservaEdicion" };
            }

            gridReservas.DataBind();
            gridReservasEdicion.DataBind();
        }

        protected void gridReservas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Dyn.Database.logic.Estado lEstado = new Dyn.Database.logic.Estado();
            int estado = lEstado.BuscarEstado("Reservas", "Anulada");
            int index = Convert.ToInt32(e.CommandArgument);
            string codReserva = gridReservas.DataKeys[index].Value.ToString();

            if (e.CommandName == "ShowRow")
            {
                Response.Redirect("/Admin/MostrarReserva.aspx?Id=" + codReserva);
            }

            else
            {
                if (ddlEstado.SelectedValue == estado.ToString())
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('La reserva Anulada no se puede editar');", true);
                    return;
                }

                else
                {

                    if (e.CommandName == "DeleteRow")
                    {
                        lReserva = new Database.logic.Reserva();
                        lReserva.Delete(Convert.ToInt32(codReserva), estado);
                        cargarGridReserva();
                    }
                    if (e.CommandName == "EditRow")
                    {
                        Response.Redirect("/Admin/EditarReserva.aspx?Id=" + codReserva);
                    }
                }
            }
        }

        protected void gridReservasEdicion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            Dyn.Database.logic.Estado lEstado = new Dyn.Database.logic.Estado();
            int estado = lEstado.BuscarEstado("Reservas", "Anulada");
            int index = Convert.ToInt32(e.CommandArgument);
            string codReservaEdicion = gridReservasEdicion.DataKeys[index].Value.ToString();

            if (e.CommandName == "ShowRow")
            {
                Response.Redirect("/Admin/MostrarReservaEdicion.aspx?Id=" + codReservaEdicion);
            }

            else
            {
                if (ddlEstado.SelectedValue == estado.ToString())
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('La reserva Anulada no se puede editar');", true);
                    return;
                }

                else
                {

                    if (e.CommandName == "DeleteRow")
                    {
                        lReservaEdicion = new Database.logic.ReservaEdicion();
                        lReservaEdicion.Delete(Convert.ToInt32(codReservaEdicion), estado);
                        cargarGridReserva();
                    }
                    if (e.CommandName == "EditRow")
                    {
                        Response.Redirect("/Admin/EditarReservaEdicion.aspx?Id=" + codReservaEdicion);
                    }
                }
            }
        }
    }
}