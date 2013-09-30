using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dyn.Database.logic;
using Dyn.Database.entities;
using System.Drawing;
using System.Data;

namespace Dyn.Web.Admin
{
    public partial class RegistrarCobro : System.Web.UI.Page
    {
        private Dyn.Database.logic.Venta lVenta;
        private Dyn.Database.logic.Cobro lCobro;
        public Dyn.Database.entities.Cobro Entity;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Master.TituloPagina = "Registrar Cobro";
                calFechaInicial.CalendarDate = DateTime.Now.AddDays(-2);
                calFechaFinal.CalendarDate = DateTime.Now.AddDays(2);
                Session["Total"] = null;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (ucBuscarClientes.NroCliente <= 0)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Seleccione el cliente');", true);
                return;
            }

            CargarVenta(ucBuscarClientes.NroCliente, Convert.ToDateTime(calFechaInicial.CalendarDate), Convert.ToDateTime(calFechaFinal.CalendarDate));
        }

        public void CargarVenta(int nroCliente, DateTime fechaInicio, DateTime fechaFin)
        {
            lVenta = new Dyn.Database.logic.Venta();
            List<Dyn.Database.entities.Venta> listaVentas = lVenta.BuscarVentasPorClienteCobro(nroCliente, fechaInicio, fechaFin);
            gridVentas.DataSource = listaVentas;
            Session["SourceVentas"] = listaVentas;
            gridVentas.DataKeyNames = new String[] { "idVenta", "montotal" };
            gridVentas.DataBind();
            if (gridVentas.Rows.Count > 0)
            {
                btnGragar.Visible = true;
                btnCancelar.Visible = true;
            }
        }

        protected void chkVenta_CheckedChanged(object sender, EventArgs e)
        {
            CalcularMontoTotal((CheckBox)sender);
        }

        private void CalcularMontoTotal(CheckBox seleccion)
        {
            GridViewRow footer = gridVentas.FooterRow;
            Label total = (Label)footer.FindControl("lblValorMontoTotal");

            foreach (GridViewRow row in gridVentas.Rows)
            {
                Label codigoVenta = (Label)row.FindControl("lblCodigoVenta");
                Label montoTotal = (Label)row.FindControl("lblMontoTotal");

                if (codigoVenta != null && montoTotal != null)
                {
                    if (codigoVenta.Text.Equals(seleccion.Text))
                    {
                        string cadena = montoTotal.Text.TrimStart('$');
                        if (seleccion.Checked == true)
                        {
                            total.Text = Convert.ToString(Convert.ToDecimal(total.Text) + Convert.ToDecimal(cadena));
                            total.BackColor = Color.FromName("#EFF3FB");
                            Session["Total"] = total;
                            break;
                        }
                        else
                        {
                            total.Text = Convert.ToString(Convert.ToDecimal(total.Text) - Convert.ToDecimal(cadena));
                            if (total.Text != "0,00")
                            {
                                total.BackColor = Color.FromName("#EFF3FB");
                            }
                            else
                            {
                                total.BackColor = Color.White;
                            }
                            Session["Total"] = total;
                            break;
                        }
                    }
                }
            }
        }

        protected void btnGragar_Click(object sender, EventArgs e)
        {
            lCobro = new Database.logic.Cobro();
            lVenta = new Database.logic.Venta();
            Entity = new Database.entities.Cobro();
            int codCobro = 0;

            if (Session["Total"] != null)
            {
                Label total = (Label)Session["Total"];

                Entity.NroCliente = ucBuscarClientes.NroCliente;
                Entity.MontoTotal = Convert.ToDouble(total.Text);

                // Insert de Cobro
                codCobro = int.Parse(lCobro.InsertCobro(Entity).ToString());

                if (codCobro > 0)
                {
                    Entity.CodCobro = codCobro;

                    // Insert de Detalle Cobro
                    foreach (GridViewRow row in gridVentas.Rows)
                    {
                        Label codigoVenta = (Label)row.FindControl("lblCodigoVenta");
                        Label montoTotal = (Label)row.FindControl("lblMontoTotal");
                        CheckBox check = row.FindControl("chkVenta") as CheckBox;

                        if (check.Checked) //obtiener la key de la row marcada
                        {   
                            Entity.CodVenta = Convert.ToInt32(codigoVenta.Text);
                            string cadena = montoTotal.Text.TrimStart('$');
                            Entity.Subtotal = Convert.ToDouble(cadena);
                            lCobro.InsertDetalleCobro(Entity);
                            // Actualizar el estado de la Venta a Entregado-Pagado
                            lVenta.cambiarEstadoEntregadoPagado((int)Entity.CodVenta);
                        }
                    }
                }

                gridVentas.DataSource = null;
                gridVentas.DataBind();
                Session["Total"] = null;
                btnGragar.Visible = false;
                btnCancelar.Visible = false;
                //-----------------------------------------------------
                calFechaInicial.CalendarDate = DateTime.Now.AddDays(-2);
                calFechaFinal.CalendarDate = DateTime.Now.AddDays(2);               
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Se guardaron los datos correctamente');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('No hay ventas asociadas al cobro');", true);
            }
        }
    }
}