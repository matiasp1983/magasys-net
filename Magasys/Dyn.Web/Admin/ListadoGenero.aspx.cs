using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Dyn.Web.weblogic;

namespace Dyn.Web.Admin
{
    public partial class ListadoGenero : System.Web.UI.Page
    {
        private Dyn.Database.logic.Genero lGenero;
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
                CurrentUser.Regresar();
                this.Master.TituloPagina = "G&eacute;nero";
                CargarGeneros("");
            }
        }

        public void CargarGeneros(string criterio)
        {
            lGenero = new Dyn.Database.logic.Genero();
            DataSet ds = lGenero.SeleccionarGenerosPorNombrePaginadoAdmin(criterio, Pagina, ref numeropaginas);
            int[] array;
            array = new int[numeropaginas];
            CollectionPager.DataSource = array;
            CollectionPager.DataBind();
            repGeneros.DataSource = ds;
            repGeneros.DataBind();
        }        

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarGeneros(txtNombreGenero.Text.Trim());

            if (txtNombreGenero.Text == string.Empty)
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

        protected void btnAdicionarGenero_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/Genero.aspx");
        }
    }
}