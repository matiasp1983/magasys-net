﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dyn.Database.logic;
using Dyn.Database.entities;

namespace Dyn.Web.Admin
{
    public partial class Venta : System.Web.UI.Page
    {
        private Dyn.Database.logic.Venta lVenta;
        public Dyn.Database.entities.Venta Entity;

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
                this.Master.TituloPagina = "Ventas";
                lVenta = new Dyn.Database.logic.Venta();
                /* Próximo idVenta */
                int i = lVenta.BuscarUltimoIdVenta() + 1;
                lblIdVenta.Text = i.ToString();
                calFechaVenta.CalendarDate = DateTime.Now;
            }           
        }       

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
        }
       
        protected void btnGuardarVenta_Click(object sender, EventArgs e)
        {
            if (ucVentas.GetrptItems.Items.Count > 0)
            {
                InsertarVenta();
                LimpiarControles();
                ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se guardaron los datos correctamente');", true);                
            }
            else
            {
                ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('No hay productos asociados a la venta');", true);
            }
        }

        private void LimpiarControles()
        {
            lblIdVenta.Text = Convert.ToString(lVenta.BuscarUltimoIdVenta() + 1);
            calFechaVenta.CalendarDate = DateTime.Now;
            ucVentas.GetrptItems.DataSource = null;
            ucVentas.GetrptItems.DataBind();
            ucVentas.SetddlProveedor = "0";
            ucVentas.SettxtProducto = string.Empty;
            ucVentas.SetlblTotal = "0";
        }

        private void InsertarVenta()
        {
            Dyn.Database.logic.DetalleVenta lDetalleVenta = new Dyn.Database.logic.DetalleVenta();
            Dyn.Database.entities.DetalleVenta eDetalleVenta = new Dyn.Database.entities.DetalleVenta();
            Dyn.Database.entities.ProductoEdicion productoEdicion = new Database.entities.ProductoEdicion();
            Dyn.Database.logic.ProductoEdicion lProdEdic = new Dyn.Database.logic.ProductoEdicion();
            Entity = new Database.entities.Venta();

            lVenta = new Database.logic.Venta();
            int idVenta;

            // Insert de Venta
            Entity.Fecha = Convert.ToDateTime(calFechaVenta.CalendarDate);
            Entity.MonTotal = ucVentas.ValorTotal;

            idVenta = Convert.ToInt32(lVenta.Insert(Entity).ToString());

            // Se recorre el detalle y se registran en la tabla DetalleVenta
            foreach (RepeaterItem rptitem in ucVentas.GetrptItems.Items)
            {
                Label LabelidProducto = rptitem.FindControl("lblidProducto") as Label;
                Label LabelValorUnitario = rptitem.FindControl("lblValorUnitario") as Label;
                Label LabelCantidad = rptitem.FindControl("lblCantidad") as Label;
                Label LabelValorTotal = rptitem.FindControl("lblValorTotal") as Label;

                eDetalleVenta.IdVenta = idVenta;
                eDetalleVenta.IdProducto = Convert.ToInt32(LabelidProducto.Text);
                eDetalleVenta.PrecioUnidad = Convert.ToDouble(LabelValorUnitario.Text);
                eDetalleVenta.Cantidad = Convert.ToInt32(LabelCantidad.Text);
                eDetalleVenta.SubTotal = Convert.ToDouble(LabelValorTotal.Text);

                lDetalleVenta.Insert(eDetalleVenta);

                productoEdicion = lProdEdic.Load((int)eDetalleVenta.IdProducto);
                productoEdicion.CantidadUnidades -= eDetalleVenta.Cantidad;  // Actualizar stock
                lProdEdic.Update(productoEdicion); // Se actualiza la tabla ProductoEdicion                
            }

        }


    }
}