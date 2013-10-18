using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dyn.WebKiosco.mi_kiosco
{
    public partial class MiCuenta : System.Web.UI.Page
    {
        private Dyn.Database.logic.Venta lVenta;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //this.Master.TituloPagina = "Listado de deudas";
                calFechaInicial.CalendarDate = DateTime.Now.AddDays(-2);
                calFechaFinal.CalendarDate = DateTime.Now.AddDays(2);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarVentas(Convert.ToDateTime(calFechaInicial.CalendarDate), Convert.ToDateTime(calFechaFinal.CalendarDate));
        }

        private void CargarVentas(DateTime fechaInicio, DateTime fechaFin)
        {
            Dyn.Database.logic.Estado lEstado = lEstado = new Database.logic.Estado();
            lVenta = new Dyn.Database.logic.Venta();
            int estado = lEstado.BuscarEstado("Ventas", "Entregado-No Pagado");
            List<Dyn.Database.entities.Venta> listaCobros = lVenta.BuscarDeudas(fechaInicio, fechaFin, estado);
            gridVentas.DataSource = listaCobros;
            gridVentas.DataKeyNames = new String[] { "idVenta" };
            gridVentas.DataBind();
        }

        protected void gridVentas_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                SqlDataSource ctrl = e.Row.FindControl("sqlDsDetalleVenta") as SqlDataSource;
                if (ctrl != null && e.Row.DataItem != null)
                {
                    ctrl.SelectParameters["idVenta"].DefaultValue = ((Dyn.Database.entities.Venta)(e.Row.DataItem)).IdVenta.Value.ToString();
                }
            }
        }
    }
}