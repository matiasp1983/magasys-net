using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dyn.Web.controls
{
    public partial class WUCBuscarProducto_V2 : System.Web.UI.UserControl
    {
        public event EventHandler SeleccionoProducto;
        
        private Dyn.Database.logic.Producto lProducto = new Database.logic.Producto();
        private int numeropaginas;
        public Dyn.Database.entities.Producto Entity;
        private static int idProveedor;

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
        public int IdProveedor
        {
            get
            {
                return (int)ViewState["IdProveedor"];
            }
            set
            {
                ViewState["IdProveedor"] = value;
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
                
                   
                
            }

        }

        public void CargarProducto(string criterio)
        {
            int idProveedor = IdProveedor;
            List<Dyn.Database.entities.Producto> listaProductos = new List<Database.entities.Producto>();
            listaProductos = lProducto.SeleccionarProductoPorIdProveedor(criterio, idProveedor);
            gvProductos.DataSource = listaProductos;
            gvProductos.DataBind();

        }

        //protected void Button2_Click(object sender, EventArgs e)
        //{
        //    CargarProducto(txtNombreProducto.Text.Trim(), idProveedor);

        //    if (txtNombreProducto.Text == string.Empty)
        //    {
        //        string url = string.Empty;
        //        if (Request.Url.ToString().Contains("?Page="))
        //        {
        //            url = Request.Url.PathAndQuery;
        //            Response.Redirect(url.Substring(0, url.Length - 1).Replace("?Page=", ""));
        //        }
        //        else
        //        {
        //            Response.Redirect(url);
        //        }
        //    }
        //}
        //protected void hpNombre_Click(object sender, EventArgs e)
        //{
        //    System.Web.UI.WebControls.LinkButton link = (System.Web.UI.WebControls.LinkButton)sender;
        //    IdEntity = int.Parse(link.Text);
            
        //    if (SeleccionoProducto != null)
        //    {
        //        SeleccionoProducto(this, new EventArgs());
        //    }

        //}


    }
}