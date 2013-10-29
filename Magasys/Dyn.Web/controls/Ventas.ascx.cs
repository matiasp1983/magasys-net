using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dyn.Web.controls
{
    public partial class Ventas : System.Web.UI.UserControl
    {
        private Dyn.Database.logic.ProductoEdicion lProductoEdicion;
        private Dyn.Database.entities.ProductoEdicion Entity;
        private CheckBox CheckBoxInRepeater;
        private Label LabelidProducto;
        private Label LabelNombre;
        private Label LabelEdicion;
        private Label LabelPrecioUnitario;
        private Label LabelStock;
        private TextBox TextBoxCantidad;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LlenarProveedor();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Entity = new Dyn.Database.entities.ProductoEdicion();
            lProductoEdicion = new Database.logic.ProductoEdicion();
            DataSet ds = lProductoEdicion.BuscarProductoEdicion(int.Parse(ddlProveedor.SelectedValue), txtProducto.Text, 0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                rptProductos.DataSource = ds;
                rptProductos.DataBind();
                /*Inicio Pintar elemento seleccionado*/
                PintarSeleccion(rptItems.Items, rptProductos.Items);
                /*Inicio Pintar elemento seleccionado*/
                mpeProductos.Show();
            }
            else
            {
                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('La búsqueda de productos no arrojó resultados.');", true);
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            /*Valida que alguno este checkeado*/
            if (ValidarCheckeado())
            {
                /*Valida que el campo cantidad sea de tipo número*/
                if (ValidarCantidad())
                {
                    /*Valida que el producto seleccionado tenga stock suficiente*/
                    if (ValidarStock())
                    {
                        if (rptItems.Visible == false)
                        {
                            rptItems.Visible = true;
                        }

                        DataTable dt = null;

                        if (rptItems.Items.Count <= 0)
                        {
                            dt = ArmarDataTable();
                            Session["SessionProductos"] = LoadDataTable(dt);
                            rptItems.DataSource = (DataTable)Session["SessionProductos"];
                        }
                        else
                        {
                            dt = (DataTable)Session["SessionProductos"];
                            bool encontrado = false;

                            foreach (RepeaterItem rptitem in rptProductos.Items)
                            {
                                encontrado = false;
                                CheckBoxInRepeater = rptitem.FindControl("chkProductoSeleccionado") as CheckBox;

                                if (CheckBoxInRepeater.Checked == true)
                                {
                                    foreach (DataRow rows in dt.Rows)
                                    {
                                        if (CheckBoxInRepeater.Text == rows.ItemArray[2].ToString())
                                        {
                                            encontrado = true;
                                            rptItems.DataSource = dt;
                                            break;
                                        }
                                    }
                                    if (encontrado != true)
                                    {
                                        rptItems.DataSource = LoadDataTableItem((DataTable)Session["SessionProductos"], rptitem);
                                    }
                                }
                            }

                        }
                        lblMensajeError.Text = string.Empty;
                        rptItems.DataBind();
                        /*Inicio Pintar elemento seleccionado*/
                        PintarSeleccion(rptItems.Items, rptProductos.Items);
                        /*Fin Pintar elemento seleccionado*/

                        /*Calcular el valor total*/
                        lblTotal.Text = GetCalcularValorTotal(rptProductos.Items).ToString();
                        mpeProductos.Hide();
                    }
                    else
                    {
                        lblMensajeError.Text = "El producto seleccionado no tiene stock suficiente.";
                    }
                }
                else
                {
                    lblMensajeError.Text = "El valor del campo cantidad debe ser mayo a 0.";
                }
            }
            else
            {
                lblMensajeError.Text = "Debe seleccionar al menos un producto.";
            }
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            lblMensajeError.Text = string.Empty;
            LimpiarCheckBox();
            mpeProductos.Hide();
        }

        private bool ValidarCheckeado()
        {
            foreach (RepeaterItem rptitem in rptProductos.Items)
            {
                CheckBoxInRepeater = rptitem.FindControl("chkProductoSeleccionado") as CheckBox;
                if (CheckBoxInRepeater.Checked && CheckBoxInRepeater.Enabled == true)
                {
                    return true;
                }
            }
            return false;
        }

        protected bool ValidarCantidad()
        {
            bool estado = true;
            foreach (RepeaterItem rptitem in rptProductos.Items)
            {
                CheckBoxInRepeater = rptitem.FindControl("chkProductoSeleccionado") as CheckBox;
                LabelStock = rptitem.FindControl("lblStock") as Label;
                TextBoxCantidad = rptitem.FindControl("txtCantidad") as TextBox;
                int i = 0;
                if (CheckBoxInRepeater.Checked)
                {
                    if (!int.TryParse(TextBoxCantidad.Text, out i) || int.Parse(TextBoxCantidad.Text) <= 0)
                    {
                        TextBoxCantidad.Focus();
                        estado = false;
                    }
                }
            }
            return estado;
        }

        private bool ValidarStock()
        {
            bool estado = true;
            foreach (RepeaterItem rptitem in rptProductos.Items)
            {
                CheckBoxInRepeater = rptitem.FindControl("chkProductoSeleccionado") as CheckBox;
                LabelStock = rptitem.FindControl("lblStock") as Label;
                TextBoxCantidad = rptitem.FindControl("txtCantidad") as TextBox;
                if (CheckBoxInRepeater.Checked && CheckBoxInRepeater.Enabled == true)
                {
                    if (int.Parse(TextBoxCantidad.Text) > int.Parse(LabelStock.Text))
                    {
                        TextBoxCantidad.Focus();
                        estado = false;
                    }
                }
            }
            return estado;
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

        private void PintarSeleccion(RepeaterItemCollection rptItems, RepeaterItemCollection rptproductos)
        {
            foreach (RepeaterItem rptitem in rptItems)
            {
                //LabelidProducto = rptitem.FindControl("lblidProducto") as Label;
                LabelEdicion = rptitem.FindControl("lblEdicion") as Label;
                string edicion = LabelEdicion.Text;

                foreach (RepeaterItem rptitemProductos in rptproductos)
                {
                    CheckBoxInRepeater = rptitemProductos.FindControl("chkProductoSeleccionado") as CheckBox;
                    LabelNombre = rptitemProductos.FindControl("lblNombre") as Label;
                    //LabelEdicion = rptitemProductos.FindControl("lblEdicion") as Label;
                    LabelPrecioUnitario = rptitemProductos.FindControl("lblPrecioUnitario") as Label;
                    LabelStock = rptitemProductos.FindControl("lblStock") as Label;
                    TextBoxCantidad = rptitemProductos.FindControl("txtCantidad") as TextBox;

                    if (edicion == CheckBoxInRepeater.Text)
                    {
                        LabelEdicion = rptitemProductos.FindControl("lblEdicion") as Label;
                        //Desabilita el item del control rptProductos                               
                        CheckBoxInRepeater.Enabled = false;
                        CheckBoxInRepeater.Checked = true;
                        TextBoxCantidad.Enabled = false;
                        CheckBoxInRepeater.BackColor = System.Drawing.Color.LightGray;
                        LabelNombre.BackColor = System.Drawing.Color.LightGray;
                        LabelEdicion.BackColor = System.Drawing.Color.LightGray;
                        LabelPrecioUnitario.BackColor = System.Drawing.Color.LightGray;
                        LabelStock.BackColor = System.Drawing.Color.LightGray;
                        /*Carga cantidad*/
                        TextBoxCantidad.Text = GetCantidad(rptItems, LabelEdicion.Text);
                        /*Cargar stock y lo resta*/
                        LabelStock.Text = Convert.ToString(int.Parse(LabelStock.Text) - int.Parse(TextBoxCantidad.Text));
                        TextBoxCantidad.BackColor = System.Drawing.Color.LightGray;
                    }
                }
            }
        }

        private DataTable ArmarDataTable()
        {
            DataTable dt = new DataTable();
            DataColumn dcProductoID = new DataColumn("idProducto", typeof(string));
            DataColumn dcProducto = new DataColumn("nombre", typeof(string));
            DataColumn dcEdicion = new DataColumn("idProductoEdicion", typeof(string));
            DataColumn dcUnitPrice = new DataColumn("precioUnidad", typeof(double));
            DataColumn dcCantidad = new DataColumn("cantidad", typeof(int));
            DataColumn dcSubtotal = new DataColumn("subTotal", typeof(double));
            dt.Columns.Add(dcProductoID);
            dt.Columns.Add(dcProducto);
            dt.Columns.Add(dcEdicion);
            dt.Columns.Add(dcUnitPrice);
            dt.Columns.Add(dcCantidad);
            dt.Columns.Add(dcSubtotal);
            return dt;
        }

        private DataTable LoadDataTable(DataTable dt)
        {
            foreach (RepeaterItem rptitem in rptProductos.Items)
            {
                CheckBoxInRepeater = rptitem.FindControl("chkProductoSeleccionado") as CheckBox;
                LabelidProducto = rptitem.FindControl("lblIdProducto") as Label;
                LabelNombre = rptitem.FindControl("lblNombre") as Label;
                LabelEdicion = rptitem.FindControl("lblEdicion") as Label;
                LabelPrecioUnitario = rptitem.FindControl("lblPrecioUnitario") as Label;
                TextBoxCantidad = rptitem.FindControl("txtCantidad") as TextBox;

                if (CheckBoxInRepeater.Checked)
                {
                    DataRow dr = dt.NewRow();
                    dr["idProducto"] = LabelidProducto.Text;
                    dr["nombre"] = LabelNombre.Text;
                    dr["idProductoEdicion"] = LabelEdicion.Text;
                    dr["precioUnidad"] = LabelPrecioUnitario.Text;
                    dr["cantidad"] = TextBoxCantidad.Text;
                    dr["subTotal"] = Convert.ToString(Convert.ToInt32(TextBoxCantidad.Text) * double.Parse(LabelPrecioUnitario.Text));
                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }

        private DataTable LoadDataTableItem(DataTable dt, RepeaterItem rptitem)
        {
            //CheckBoxInRepeater = rptitem.FindControl("chkProductoSeleccionado") as CheckBox;
            LabelidProducto = rptitem.FindControl("lblIdProducto") as Label;
            LabelNombre = rptitem.FindControl("lblNombre") as Label;
            LabelEdicion = rptitem.FindControl("lblEdicion") as Label;
            LabelPrecioUnitario = rptitem.FindControl("lblPrecioUnitario") as Label;
            TextBoxCantidad = rptitem.FindControl("txtCantidad") as TextBox;
            DataRow dr = dt.NewRow();
            dr["idProducto"] = LabelidProducto.Text;
            dr["nombre"] = LabelNombre.Text;
            dr["idProductoEdicion"] = LabelEdicion.Text;
            dr["precioUnidad"] = LabelPrecioUnitario.Text;
            dr["cantidad"] = TextBoxCantidad.Text;
            dr["subTotal"] = Convert.ToString(Convert.ToInt32(TextBoxCantidad.Text) * double.Parse(LabelPrecioUnitario.Text));
            dt.Rows.Add(dr);
            return dt;
        }

        private string GetCantidad(RepeaterItemCollection rptItems, string productoEdicion)
        {
            int contador = -1;
            foreach (RepeaterItem rptitem in rptItems)
            {
                LabelEdicion = rptitem.FindControl("lblEdicion") as Label;
                contador++;
                if (LabelEdicion.Text == productoEdicion)
                {
                    break;
                }
            }
            return ((DataTable)Session["SessionProductos"]).Rows[contador].ItemArray[4].ToString();
        }

        private void LimpiarCheckBox()
        {
            foreach (RepeaterItem rptitem in rptProductos.Items)
            {
                CheckBoxInRepeater = rptitem.FindControl("chkProductoSeleccionado") as CheckBox;
                TextBoxCantidad = rptitem.FindControl("txtCantidad") as TextBox;

                if (CheckBoxInRepeater.Checked)
                {
                    CheckBoxInRepeater.Checked = false;
                }
            }
        }

        protected void rptItems_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "Detete")
            {
                DataTable dt = (DataTable)Session["SessionProductos"];
                int id = Convert.ToInt32(e.CommandArgument);

                foreach (DataRow item in dt.Rows)
                {
                    if (item["idProducto"].ToString() == id.ToString())
                    {
                        item.Delete();
                        ValorTotal -= Convert.ToDouble(((Label)e.Item.FindControl("lblValorTotal")).Text);
                        lblTotal.Text = ValorTotal.ToString();
                        break;
                    }
                }

                Session["SessionProductos"] = dt;
                rptItems.DataSource = dt;
                rptItems.DataBind();

                if (dt.Rows.Count == 0)
                {
                    rptItems.Visible = false;
                }
            }
        }

        private Double GetCalcularValorTotal(RepeaterItemCollection rptItems)
        {
            ValorTotal = 0;
            foreach (RepeaterItem rptitem in rptItems)
            {
                CheckBoxInRepeater = rptitem.FindControl("chkProductoSeleccionado") as CheckBox;
                TextBoxCantidad = rptitem.FindControl("txtCantidad") as TextBox;
                LabelPrecioUnitario = rptitem.FindControl("lblPrecioUnitario") as Label;

                if (CheckBoxInRepeater.Checked)
                {
                    ValorTotal += Convert.ToInt32(TextBoxCantidad.Text) * Convert.ToDouble(LabelPrecioUnitario.Text);
                }
            }
            return ValorTotal;
        }

        public double ValorTotal
        {
            get
            {
                return Convert.ToDouble(ViewState["ValorTotal"]);
            }
            set
            {
                ViewState["ValorTotal"] = value;
            }
        }

        public Repeater GetrptItems
        {
            get
            {
                return rptItems;
            }
        }

        public string SetlblTotal
        {
            set
            {
                lblTotal.Text = value;
            }
        }

        public string SetddlProveedor
        {
            set
            {
                ddlProveedor.SelectedValue = value;
            }
        }

        public string SettxtProducto
        {
            set
            {
                txtProducto.Text = value;
            }
        }
    }
}