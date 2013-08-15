using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dyn.Web.controls
{
    public partial class WUCBuscarProducto : System.Web.UI.UserControl
    {
        public event EventHandler SeleccionoProducto;
        
        private Dyn.Database.logic.Producto lProducto;
        private int numeropaginas;
        public Dyn.Database.entities.Producto Entity;

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
                CargarProducto("", "0");
                LlenarProveedor();
                
                
            }

        }
        public void LlenarProveedor()
        {
            Dyn.Database.logic.Proveedor lProveedor = new Dyn.Database.logic.Proveedor();
            List<Dyn.Database.entities.Proveedor> listaproveedor = lProveedor.SeleccionarTodosLosProveedores();
            ListItem li;
            li = new ListItem();
            li = new ListItem("<< TODOS >>", "0");
            lstProveedor.Items.Add(li);
            for (int i = 0; i < listaproveedor.Count; i++)
            {
                li = new ListItem();
                li = new ListItem(listaproveedor[i].RazonSocial, listaproveedor[i].IdProveedor.ToString());
                lstProveedor.Items.Add(li);
            }
        }
        public void CargarProducto(string criterio, string idProveedor)
        {
            lProducto = new Dyn.Database.logic.Producto();

            if (lstProveedor.SelectedValue == "0")
            {
                DataSet ds = lProducto.SeleccionarProductoPorNombrePaginado(criterio, Pagina, ref numeropaginas, 3);
                int[] array;
                array = new int[numeropaginas];
                CollectionPager.DataSource = array;
                CollectionPager.DataBind();
                repProducto.DataSource = ds;
            }

            else
            {
                DataSet ds = lProducto.SeleccionarProductoPorNombreProveedorPaginado(criterio, idProveedor, Pagina, ref numeropaginas, 3);
                int[] array;
                array = new int[numeropaginas];
                CollectionPager.DataSource = array;
                CollectionPager.DataBind();
                repProducto.DataSource = ds;
            }

            repProducto.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            CargarProducto(txtNombreProducto.Text.Trim(), lstProveedor.SelectedValue);

            if (txtNombreProducto.Text == string.Empty)
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
        protected void hpNombre_Click(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.LinkButton link = (System.Web.UI.WebControls.LinkButton)sender;
            IdEntity = int.Parse(link.Text);
            
            if (SeleccionoProducto != null)
            {
                SeleccionoProducto(this, new EventArgs());
            }

        }


    }
}