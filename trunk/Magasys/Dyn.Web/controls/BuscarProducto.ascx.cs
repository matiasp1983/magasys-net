using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dyn.Web.controls
{
    public partial class BuscarProducto : System.Web.UI.UserControl
    {
        private Dyn.Database.logic.ProductoEdicion lProductoEdicion;
        private Dyn.Database.entities.ProductoEdicion Entity;
        private RadioButton rdbProductoSeccionado;
        private Label LabelNombreProducto;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LlenarProveedor();
            }
        }

        protected void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            mpeProducto.Show();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Entity = new Dyn.Database.entities.ProductoEdicion();
            lProductoEdicion = new Database.logic.ProductoEdicion();
            DataSet ds = lProductoEdicion.BuscarProductoEdicion(int.Parse(ddlProveedor.SelectedValue), txtNombreProd.Text, 0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                rptProductos.DataSource = ds;
                rptProductos.DataBind();
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('La búsqueda de productos no arrojó resultados.');", true);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            bool encontrado = false;
            foreach (RepeaterItem rptitem in rptProductos.Items)
            {
                rdbProductoSeccionado = rptitem.FindControl("rdbProductoSeccionado") as RadioButton;
                LabelNombreProducto = rptitem.FindControl("lblNombre") as Label;

                if (rdbProductoSeccionado.Checked)
                {
                    lblidProductoText.Text = rdbProductoSeccionado.Text;
                    CodigoProducto = Convert.ToInt32(rdbProductoSeccionado.Text);
                    lblNombreText.Text = LabelNombreProducto.Text;
                    encontrado = true;
                    break;
                }
            }
            if (encontrado != true)
            {
                lblMensajeError.Text = "Debe seleccionar al menos un producto.";
            }
            else
            {
                LimpiarControles();
                mpeProducto.Hide();
            }
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            mpeProducto.Hide();
        }

        public Int32 CodigoProducto
        {
            get
            {
                return Convert.ToInt32(ViewState["CodigoProducto"]);
            }
            set
            {
                ViewState["CodigoProducto"] = value;
            }
        }

        protected void rdbProductoSeccionado_OnCheckedChanged(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in rptProductos.Items)
            {
                RadioButton rdbItem = item.FindControl("rdbProductoSeccionado") as RadioButton;
                rdbItem.Checked = false;
            }
            ((RadioButton)sender).Checked = true;
        }

        public void LlenarProveedor()
        {
            Dyn.Database.logic.Proveedor lProveedor = new Dyn.Database.logic.Proveedor();
            List<Dyn.Database.entities.Proveedor> listaproveedor = lProveedor.SeleccionarTodosLosProveedores();
            ListItem li;
            li = new ListItem();
            li = new ListItem("Seleccionar...", "0");
            ddlProveedor.Items.Add(li);
            for (int i = 0; i < listaproveedor.Count; i++)
            {
                li = new ListItem();
                li = new ListItem(listaproveedor[i].Nombre, listaproveedor[i].IdProveedor.ToString());
                ddlProveedor.Items.Add(li);
            }
        }

        private void LimpiarControles()
        {
            lblMensajeError.Text = string.Empty;
            txtNombreProd.Text = string.Empty;
            rptProductos.DataSource = null;
            rptProductos.DataBind();
        }

    }
}