using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dyn.Database.logic;
using Dyn.Database.entities;

namespace Dyn.Web.Admin
{
    public partial class Ingresos : System.Web.UI.Page
    {
        private int numeropaginas;
        private Dyn.Database.logic.Producto lProducto;
        public Dyn.Database.entities.Producto newProducto;
        private Dyn.Database.logic.Ingreso lIngreso;
        public Dyn.Database.entities.IngresoProducto Entity;

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
        public int Pagina
        {
            get
            {
                int result;
                int.TryParse(Request.QueryString["page"], out result);
                return result == 0 ? 1 : result;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                WUCBuscarProducto1.Visible = false;
                calFecha.SelectedDate = DateTime.Today;

            }
        }

        protected void btnMostrarProductos_Click(object sender, EventArgs e)
        {
            WUCBuscarProducto1.Visible = true;
        }

    }
}