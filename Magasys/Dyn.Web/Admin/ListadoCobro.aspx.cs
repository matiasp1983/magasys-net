using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dyn.Web.Admin
{
    public partial class ListadoCobro : System.Web.UI.Page
    {
        private Dyn.Database.logic.Cobro lCobro;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Master.TituloPagina = "Listado de cobros";
                calFechaInicial.CalendarDate = DateTime.Now.AddDays(-2);
                calFechaFinal.CalendarDate = DateTime.Now.AddDays(2);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarCobro(ucBuscarClientes.NroCliente, Convert.ToDateTime(calFechaInicial.CalendarDate), Convert.ToDateTime(calFechaFinal.CalendarDate));
            //int.Parse(lblNroClienteText.Text)
        }

        private void CargarCobro(int nroCliente, DateTime fechaInicio, DateTime fechaFin)
        {
            Dyn.Database.logic.Estado lEstado = lEstado = new Database.logic.Estado();
            lCobro = new Dyn.Database.logic.Cobro();
            int estado = lEstado.BuscarEstado("Cobros", "Cobrada");
            List<Dyn.Database.entities.Cobro> listaCobros = lCobro.BuscarCobro(nroCliente, fechaInicio, fechaFin, estado);
            gridCobros.DataSource = listaCobros;            
            gridCobros.DataKeyNames = new String[] {"codCobro"};
            gridCobros.DataBind();
        }

        protected void gridCobros_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                SqlDataSource ctrl = e.Row.FindControl("sqlDsVentas") as SqlDataSource;
                if (ctrl != null && e.Row.DataItem != null)
                {
                    ctrl.SelectParameters["CodCobro"].DefaultValue = ((Dyn.Database.entities.Cobro)(e.Row.DataItem)).CodCobro.Value.ToString();
                }
            }
        }
    }
}