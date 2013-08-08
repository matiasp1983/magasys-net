using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace Dyn.Web.Admin
{
    public partial class ListadoProveedor : System.Web.UI.Page
    {

        private Dyn.Database.logic.Proveedor lProveedor;
        private int numeropaginas;

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
                this.Master.TituloPagina = "Proveedor";
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarGeneros(txtNombreProveedor.Text.Trim());

            if (txtNombreProveedor.Text == string.Empty)
            {
                string url = string.Empty;
                if (Request.Url.ToString().Contains("?Page="))
                {
                    url = Request.Url.PathAndQuery;
                    Response.Redirect(url.Substring(0, url.Length - 1).Replace("?Page=", ""));
                }
                else
                {
                    Response.Redirect(url);
                }
            }
        }
        public void CargarGeneros(string criterio)
        {
            lProveedor = new Dyn.Database.logic.Proveedor();
            DataSet ds = lProveedor.SeleccionarProveedorPorNombrePaginadoAdmin(criterio, Pagina, ref numeropaginas);
            int[] array;
            array = new int[numeropaginas];
            CollectionPager.DataSource = array;
            CollectionPager.DataBind();
            repGeneros.DataSource = ds;
            repGeneros.DataBind();
        }
        protected void btnAdicionarGenero_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/Proveedor.aspx");
        }
    }
}