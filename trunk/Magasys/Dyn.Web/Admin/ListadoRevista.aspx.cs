using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dyn.Web.Admin
{
    public partial class ListadoRevista : System.Web.UI.Page
    {
        private Dyn.Database.logic.Revista lRevista;
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
                this.Master.TituloPagina = "Revista";
                CargarRevistas("");
            }
        }

        public void CargarRevistas(string criterio)
        {
            lRevista = new Dyn.Database.logic.Revista();
            DataSet ds = lRevista.SeleccionarRevistasPorNombrePaginadoAdmin(criterio, Pagina, ref numeropaginas);
            int[] array;
            array = new int[numeropaginas];
            CollectionPager.DataSource = array;
            CollectionPager.DataBind();
            repRevistas.DataSource = ds;
            repRevistas.DataBind();
        }        

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarRevistas(txtNombreRevista.Text.Trim());

            if (txtNombreRevista.Text == string.Empty)
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

        protected void btnAdicionarRevista_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/Revista.aspx");
        }
    }
}