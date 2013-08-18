using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dyn.Web.Admin
{
    public partial class ListadoPelicula : System.Web.UI.Page
    {
        private Dyn.Database.logic.Pelicula lPelicula;
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
                LlenarProveedor();
                this.Master.TituloPagina = "Pel&iacute;cula";
                CargarPeliculas("", 0);
            }
        }

        public void CargarPeliculas(string criterio, int idProveedor)
        {
            lPelicula = new Dyn.Database.logic.Pelicula();
            DataSet ds = lPelicula.SeleccionarPeliculasPorNombrePaginadoAdmin(criterio, idProveedor, Pagina, ref numeropaginas);
            int[] array;
            array = new int[numeropaginas];
            CollectionPager.DataSource = array;
            CollectionPager.DataBind();
            repPeliculas.DataSource = ds;
            repPeliculas.DataBind();
        }

        public void LlenarProveedor()
        {
            Dyn.Database.logic.Proveedor lProveedor = new Dyn.Database.logic.Proveedor();
            List<Dyn.Database.entities.Proveedor> listaproveedor = lProveedor.SeleccionarTodosLosProveedores();
            ListItem li;
            li = new ListItem();
            li = new ListItem("<< TODOS >>", "0");
            ddlProveedor.Items.Add(li);
            for (int i = 0; i < listaproveedor.Count; i++)
            {
                li = new ListItem();
                li = new ListItem(listaproveedor[i].Nombre, listaproveedor[i].IdProveedor.ToString());
                ddlProveedor.Items.Add(li);
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarPeliculas(txtNombrePelicula.Text.Trim(), int.Parse(ddlProveedor.SelectedValue));

            if (txtNombrePelicula.Text == string.Empty && int.Parse(ddlProveedor.SelectedValue) == 0)
            {   // Redireccionar a la primera página
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

        protected void btnAdicionarPelicula_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/Pelicula.aspx");
        }
    }
}