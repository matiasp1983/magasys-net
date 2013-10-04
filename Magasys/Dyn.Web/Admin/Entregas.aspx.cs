using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dyn.Web.Admin
{
    public partial class Entregas : System.Web.UI.Page
    {
        public static List<Dyn.Database.entities.ReservaEdicion> listaReservas = new List<Database.entities.ReservaEdicion>();
        public static List<Dyn.Database.entities.Entrega> listaEntregas = new List<Database.entities.Entrega>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                listaReservas.Clear();
                listaEntregas.Clear();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Int32 nroCliente = ucBuscarClientes.NroCliente;
            Dyn.Database.logic.ReservaEdicion lReservas = new Database.logic.ReservaEdicion();
            listaReservas = lReservas.BuscarReservasPorCliente(nroCliente);
            btnGuardar.Enabled = false;
            panBusqueda.Visible = false;
            panResultados.Visible = true;
            gvReservas.DataSource = listaReservas;
            gvReservas.DataBind();

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Dyn.Database.entities.Venta newVenta = new Database.entities.Venta();
            Dyn.Database.logic.Venta lVenta = new Database.logic.Venta();
            Dyn.Database.logic.Estado lEstado = new Database.logic.Estado();
            Dyn.Database.logic.Entrega lEntrega = new Database.logic.Entrega();
            Dyn.Database.logic.ProductoEdicion2 lProdEdi = new Database.logic.ProductoEdicion2();
            Dyn.Database.logic.ReservaEdicion lReservaEdicion = new Database.logic.ReservaEdicion();
            for (int i = 0; i < listaEntregas.Count; i++)
            {
                // Datos Venta 
                newVenta.Fecha = DateTime.Now;
                newVenta.FormaPago = "Cuenta corriente";
                newVenta.IdEstado = lEstado.BuscarEstado("Ventas","Entregado-Pagado");
                newVenta.MonTotal = (listaEntregas[i].ReservaEdicion.Cantidad)*(listaEntregas[i].ReservaEdicion.ProductoEdicion.Precio);
                newVenta.NroCliente = listaEntregas[i].ReservaEdicion.Cliente.NroCliente;
                int idVenta = Convert.ToInt32(lVenta.Insert(newVenta));

                // Actualizar Reserva
                listaEntregas[i].ReservaEdicion.IdEstado = lEstado.BuscarEstado("ReservasEdicion","Entregado");

                lReservaEdicion.Update(listaEntregas[i].ReservaEdicion);

                // Crear Entrega
                lEntrega.Insert(listaEntregas[i]);

                // Actualizo Stock
                listaEntregas[i].ReservaEdicion.ProductoEdicion.CantidadUnidades -= listaEntregas[i].ReservaEdicion.Cantidad;
                lProdEdi.Update(listaEntregas[i].ReservaEdicion.ProductoEdicion);

                
            }
            Response.Redirect("/Home.aspx");

        }

        protected void gvReservas_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Dyn.Database.entities.Entrega newEntrega = new Dyn.Database.entities.Entrega();
            newEntrega.ReservaEdicion = listaReservas[e.NewSelectedIndex];
            listaReservas.Remove(listaReservas[e.NewSelectedIndex]);
            newEntrega.Fecha = DateTime.Now;
            listaEntregas.Add(newEntrega);
            gvReservas.DataSource = listaReservas;
            gvReservas.DataBind();
            gvEntregas.DataSource = listaEntregas;
            gvEntregas.Visible = true;
            gvEntregas.DataBind();
            btnGuardar.Enabled = true;
            panEntregas.Visible = true;
        }

        protected void gvEntregas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int key = e.RowIndex;
            for (int i = 0; i < listaEntregas.Count; i++)
            {
                if (i == key)
                {
                    listaEntregas.Remove(listaEntregas[i]);
                    // return;
                }
            }
            gvEntregas.DataSource = listaEntregas;
            gvEntregas.DataBind();
            if (listaEntregas.Count == 0)
            { btnGuardar.Enabled = false; }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Home.aspx");
        }

        protected void btnUltimoReparto_Click(object sender, EventArgs e)
        {
            Dyn.Database.logic.Reparto lReparto = new Database.logic.Reparto();
            listaReservas = lReparto.BuscarUltimoReparto();
            gvReservas.DataSource = listaReservas;
            gvReservas.DataBind();
            gvEntregas.DataSource = listaEntregas;
            gvEntregas.Visible = true;
            gvEntregas.DataBind();
            btnGuardar.Enabled = false;
            panBusqueda.Visible = false;
            panResultados.Visible = true;
        }
    }
}