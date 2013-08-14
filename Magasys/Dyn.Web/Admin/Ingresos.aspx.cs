using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dyn.Web.Admin
{
    public partial class Ingresos : System.Web.UI.Page
    {

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
                //CargarProducto("", "0");
                //LlenarProveedor();
                WUCBuscarProducto1.Visible = false;

            } 
        }

        protected void btnMostrarProductos_Click(object sender, EventArgs e)
        {
            WUCBuscarProducto1.Visible = true;
        }
    }
}