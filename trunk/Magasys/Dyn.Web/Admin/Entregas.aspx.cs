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

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Int32 nroCliente = ucBuscarClientes.NroCliente;
            Dyn.Database.logic.ReservaEdicion lReservas = new Database.logic.ReservaEdicion();
            listaReservas = lReservas.BuscarReservasPorCliente(nroCliente);
            gvReservas.DataSource = listaReservas;
            gvReservas.DataBind();

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }
    }
}