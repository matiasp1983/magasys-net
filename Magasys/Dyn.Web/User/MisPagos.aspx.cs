using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dyn.Web.weblogic;

namespace Dyn.Web.User
{
    public partial class MisPagos : System.Web.UI.Page
    {
        private Dyn.Database.logic.Cobro lCobro;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CurrentUser.RegresarHome();
                calFechaInicial.CalendarDate = DateTime.Now.AddDays(-2);
                calFechaFinal.CalendarDate = DateTime.Now.AddDays(2);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Dyn.Database.logic.Usuario lUsuario = new Dyn.Database.logic.Usuario();
            Dyn.Database.entities.Usuario eusuario = new Database.entities.Usuario();

            System.Security.Principal.IIdentity user = HttpContext.Current.User.Identity;

            eusuario = lUsuario.SeleccionarUsuarioPorLogin(user.Name);

            if (eusuario != null)
            {
                CargarCobro((int)eusuario.Cliente.NroCliente, Convert.ToDateTime(calFechaInicial.CalendarDate), Convert.ToDateTime(calFechaFinal.CalendarDate));
            }
        }

        private void CargarCobro(int nroCliente, DateTime fechaInicio, DateTime fechaFin)
        {
            Dyn.Database.logic.Estado lEstado = lEstado = new Database.logic.Estado();
            lCobro = new Dyn.Database.logic.Cobro();
            int estado = lEstado.BuscarEstado("Cobros", "Cobrada");
            List<Dyn.Database.entities.Cobro> listaCobros = lCobro.BuscarCobro(nroCliente, fechaInicio, fechaFin, estado);
            gridCobros.DataSource = listaCobros;
            gridCobros.DataKeyNames = new String[] { "codCobro" };
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