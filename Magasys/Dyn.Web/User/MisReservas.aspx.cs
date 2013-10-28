using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dyn.Web.weblogic;

namespace Dyn.Web.User
{
    public partial class MisReservas : System.Web.UI.Page
    {
        private Dyn.Database.logic.Reserva lReserva;
        private Dyn.Database.logic.ReservaEdicion lReservaEdicion;

        protected void Page_Load(object sender, EventArgs e)
        {
            CurrentUser.RegresarHome();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            cargarGridReserva();
        }

        private void cargarGridReserva()
        {
            Dyn.Database.logic.Estado lEstado = new Database.logic.Estado();
            Dyn.Database.logic.Usuario lUsuario = new Dyn.Database.logic.Usuario();
            Dyn.Database.entities.Usuario eusuario = new Database.entities.Usuario();
            lReserva = new Dyn.Database.logic.Reserva();
            lReservaEdicion = new Database.logic.ReservaEdicion();
            DateTime fecha = new DateTime();
            string tipoReserva = string.Empty;
            gridReservas.DataSource = null;
            gridReservasEdicion.DataSource = null;
            int estado = lEstado.BuscarEstado("Reservas", "Confirmado");

            System.Security.Principal.IIdentity user = HttpContext.Current.User.Identity;

            eusuario = lUsuario.SeleccionarUsuarioPorLogin(user.Name);

            if (ddlTipoReserva.SelectedValue != "Seleccionar...")
            {
                tipoReserva = ddlTipoReserva.SelectedValue;
            }

            fecha = Convert.ToDateTime(calFechaReserva.CalendarDate);

            if (rdbReserva.Checked)
            {
                List<Dyn.Database.entities.Reserva> listaReservas = lReserva.BuscarReservasPorCliente(fecha,
                    tipoReserva, estado, (int)eusuario.Cliente.NroCliente);
                gridReservas.DataSource = listaReservas;
                gridReservas.DataKeyNames = new String[] { "codReserva" };
            }
            else
            {
                List<Dyn.Database.entities.ReservaEdicion> listaReservasEdicion = lReservaEdicion.BuscarReservasEdicionPorCliente(fecha,
                    tipoReserva, estado, (int)eusuario.Cliente.NroCliente);
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
                Response.Redirect("/User/MostrarReserva.aspx?Id=" + codReserva);
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
                    Response.Redirect("/User/EditarReserva.aspx?Id=" + codReserva);
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
                Response.Redirect("/User/MostrarReservaEdicion.aspx?Id=" + codReservaEdicion);
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
                    Response.Redirect("/User/EditarReservaEdicion.aspx?Id=" + codReservaEdicion);
                }
            }
        }
    }
}