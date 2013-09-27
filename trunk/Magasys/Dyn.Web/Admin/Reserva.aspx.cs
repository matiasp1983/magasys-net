using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dyn.Web.Admin
{
    public partial class Reserva : System.Web.UI.Page
    {
        private Dyn.Database.logic.Reserva lReserva;
        private Dyn.Database.logic.ReservaEdicion lReservaEdicion;
        public Dyn.Database.entities.Reserva EntityRes;
        public Dyn.Database.entities.ReservaEdicion EntityResEdic;

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
                this.Master.TituloPagina = "Reservas";
                calFechaReserva.CalendarDate = DateTime.Now;
            }
        }

        protected void btnGuardarReserva_Click(object sender, EventArgs e)
        {
            object reservaCreada;

            if (ddlTipoReserva.SelectedValue == "Única" && calFechaFin.CalendarDateString == string.Empty)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Seleccione la fecha de Fin de reserva');", true);
                return;
            }

            if (calFechaInicio.CalendarDateString == string.Empty)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Seleccione la fecha de Inicio de reserva');", true);
                return;
            }

            if (ucBuscarClientes.NroCliente == 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Seleccione el cliente');", true);
                return;
            }

            if (ucBuscarProducto.CodigoProducto == 0 && ucBuscarProductoEdicion.CodigoProducto == 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Seleccione el producto');", true);
                return;
            }

            //if (ucBuscarProductoEdicion.CodigoProducto == 0)
            //{
            //    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Seleccione el producto');", true);
            //    return;
            //}

            if (int.Parse(txtCantidad.Text) <= 0)
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Ingrese la cantidad de productos');", true);
                return;
            }

            reservaCreada = InsertarReserva();
            if (reservaCreada.ToString() != "0")
            {
                LimpiarControles();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se guardaron los datos correctamente');", true);
            }
            else
            {
                LimpiarControles();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se actualizaron los datos correctamente');", true);
            }
            
        }

        private object InsertarReserva()
        {
            Dyn.Database.entities.ProductoEdicion productoEdicion = new Database.entities.ProductoEdicion();
            Dyn.Database.logic.ProductoEdicion lProdEdic = new Dyn.Database.logic.ProductoEdicion();
            Dyn.Database.logic.Estado lEstado = new Dyn.Database.logic.Estado();
            EntityRes = new Database.entities.Reserva();
            EntityResEdic = new Database.entities.ReservaEdicion();
            lReserva = new Database.logic.Reserva();
            lReservaEdicion = new Database.logic.ReservaEdicion();
            String nombreEstado = String.Empty;
            object idReserva = null;

            if (rdbProducto.Checked) // Insert de Reserva
            {
                EntityRes.NroCliente = ucBuscarClientes.NroCliente;
                EntityRes.FechaReserva = Convert.ToDateTime(calFechaReserva.CalendarDate);
                EntityRes.FechaInicio = Convert.ToDateTime(calFechaInicio.CalendarDate);
                EntityRes.FechaFin = Convert.ToDateTime(calFechaFin.CalendarDate);
                EntityRes.TipoReserva = ddlTipoReserva.SelectedValue.ToString();
                EntityRes.IdProducto = ucBuscarProducto.CodigoProducto;
                EntityRes.Cantidad = Convert.ToInt16(txtCantidad.Text);
                EntityRes.IdEstado = lEstado.BuscarEstado("Reserva", "Confirmado");

                idReserva = lReserva.Insert(EntityRes);
            }
            else  // Insert Reserva Edicion
            {
                EntityResEdic.IdProductoEdicion = ucBuscarProductoEdicion.IdEdicion;
                EntityResEdic.NroCliente = ucBuscarClientes.NroCliente;
                EntityResEdic.FechaReservaEdicion = Convert.ToDateTime(calFechaReserva.CalendarDate);
                EntityResEdic.FechaInicio = Convert.ToDateTime(calFechaInicio.CalendarDate);
                EntityResEdic.FechaFin = Convert.ToDateTime(calFechaFin.CalendarDate);
                EntityResEdic.TipoReserva = ddlTipoReserva.SelectedValue.ToString();
                EntityResEdic.Cantidad = Convert.ToInt16(txtCantidad.Text);
                EntityResEdic.IdEstado = lEstado.BuscarEstado("ReservaEdicion", "Confirmado");

                idReserva = lReservaEdicion.Insert(EntityResEdic);

                if (idReserva.ToString() != "0")
	            {
	                // Solo en Reserva Edición se disminuye el sotck
                    productoEdicion = lProdEdic.Load((int)ucBuscarProductoEdicion.CodigoProducto, (int)ucBuscarProductoEdicion.IdEdicion);
                productoEdicion.CantidadUnidades -= EntityResEdic.Cantidad;  // Actualizar stock
                lProdEdic.Update(productoEdicion); // Se actualiza la tabla ProductoEdicion	 
	            }
            }

            return idReserva;
        }

        private void LimpiarControles()
        {
            //calFechaReserva.CalendarDate = DateTime.MaxValue.Date;
            //ddlTipoReserva.SelectedValue = "Única";
            //calFechaInicio.CalendarDate = DateTime.MaxValue.Date;
            //calFechaFin.CalendarDate = DateTime.MaxValue.Date;
            //ucBuscarClientes. = string.Empty;

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }
    }
}