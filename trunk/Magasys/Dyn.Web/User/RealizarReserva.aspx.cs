using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dyn.Web.weblogic;

namespace Dyn.Web.User
{
    public partial class RealizarReserva : System.Web.UI.Page
    {
        private Dyn.Database.logic.Reserva lReserva;
        private Dyn.Database.logic.ReservaEdicion lReservaEdicion;
        public Dyn.Database.entities.Reserva EntityRes;
        public Dyn.Database.entities.ReservaEdicion EntityResEdic;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CurrentUser.RegresarHome();
                calFechaReserva.CalendarDate = DateTime.Now;
            }
        }

        protected void btnGuardarReserva_Click(object sender, EventArgs e)
        {
            object reservaCreada;

            if (ddlTipoReserva.SelectedValue == "Única" && calFechaFin.CalendarDateString == string.Empty)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Seleccione la fecha de Fin de reserva');", true);
                return;
            }

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

            if (rdbProducto.Checked == true && ucBuscarProducto.CodigoProducto == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Seleccione el producto');", true);
                return;
            }

            if (rdbEdicion.Checked == true && ucBuscarProductoEdicion.CodigoProducto == 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Seleccione el producto');", true);
                return;
            }

            if (int.Parse(txtCantidad.Text) <= 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Ingrese la cantidad de productos');", true);
                return;
            }

            reservaCreada = InsertarReserva();
            if (reservaCreada.ToString() != "0")
            {
                LimpiarControles();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Se guardaron los datos correctamente');", true);
            }
            else
            {
                LimpiarControles();
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('No se guardaron los datos correctamente');", true);
            }
        }

        private object InsertarReserva()
        {
            Dyn.Database.logic.Usuario lUsuario = new Dyn.Database.logic.Usuario();
            Dyn.Database.entities.Usuario eusuario = new Database.entities.Usuario();
            Dyn.Database.entities.ProductoEdicion productoEdicion = new Database.entities.ProductoEdicion();
            Dyn.Database.logic.ProductoEdicion lProdEdic = new Dyn.Database.logic.ProductoEdicion();
            Dyn.Database.logic.Estado lEstado = new Dyn.Database.logic.Estado();
            EntityRes = new Database.entities.Reserva();
            EntityResEdic = new Database.entities.ReservaEdicion();
            lReserva = new Database.logic.Reserva();
            lReservaEdicion = new Database.logic.ReservaEdicion();
            String nombreEstado = String.Empty;
            object idReserva = null;

            System.Security.Principal.IIdentity user = HttpContext.Current.User.Identity;

            eusuario = lUsuario.SeleccionarUsuarioPorLogin(user.Name);

            if (eusuario != null)
            {

                if (rdbProducto.Checked) // Insert de Reserva
                {
                    EntityRes.NroCliente = eusuario.Cliente.NroCliente;
                    EntityRes.FechaReserva = Convert.ToDateTime(calFechaReserva.CalendarDate);
                    EntityRes.FechaInicio = Convert.ToDateTime(calFechaInicio.CalendarDate);
                    EntityRes.FechaFin = Convert.ToDateTime(calFechaFin.CalendarDate);
                    EntityRes.TipoReserva = ddlTipoReserva.SelectedValue.ToString();
                    EntityRes.IdProducto = ucBuscarProducto.CodigoProducto;
                    EntityRes.Cantidad = Convert.ToInt16(txtCantidad.Text);
                    EntityRes.IdEstado = lEstado.BuscarEstado("Reservas", "Confirmado");

                    idReserva = lReserva.Insert(EntityRes);
                }
                else  // Insert Reserva Edicion
                {
                    EntityResEdic.IdProductoEdicion = ucBuscarProductoEdicion.IdEdicion;
                    EntityResEdic.NroCliente = eusuario.Cliente.NroCliente;
                    EntityResEdic.FechaReservaEdicion = Convert.ToDateTime(calFechaReserva.CalendarDate);
                    EntityResEdic.FechaInicio = Convert.ToDateTime(calFechaInicio.CalendarDate);
                    EntityResEdic.FechaFin = Convert.ToDateTime(calFechaFin.CalendarDate);
                    EntityResEdic.TipoReserva = ddlTipoReserva.SelectedValue.ToString();
                    EntityResEdic.Cantidad = Convert.ToInt16(txtCantidad.Text);
                    EntityResEdic.IdEstado = lEstado.BuscarEstado("ReservasEdicion", "Confirmado");

                    idReserva = lReservaEdicion.Insert(EntityResEdic);

                    if (idReserva.ToString() != "0")
                    {
                        // Solo en Reserva Edición se disminuye el sotck
                        productoEdicion = lProdEdic.Load((int)ucBuscarProductoEdicion.CodigoProducto, (int)ucBuscarProductoEdicion.IdEdicion);
                        productoEdicion.CantidadUnidades -= EntityResEdic.Cantidad;  // Actualizar stock
                        lProdEdic.Update(productoEdicion); // Se actualiza la tabla ProductoEdicion	 
                    }
                }
            }
            return idReserva;
        }

        private void LimpiarControles()
        {
            //calFechaReserva.CalendarDate = DateTime.Now;
            //ddlTipoReserva.SelectedValue = "Única";
            //rdbProducto.Checked = true;
            //rdbEdicion.Checked = false;
            //calFechaInicio.CalendarDateString = string.Empty;
            //calFechaFin.CalendarDateString = string.Empty;
            //ucBuscarProducto
            ////ucBuscarProductoEdicion
            //txtCantidad.Text = string.Empty;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Home.aspx");
        }

    }
}