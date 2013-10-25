using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dyn.Database.logic;
using Dyn.Database.entities;

namespace Dyn.Web.Admin
{
    public partial class MostrarVenta : System.Web.UI.Page
    {
        private Dyn.Database.logic.Venta lVenta;
        public Dyn.Database.entities.Venta Entity;

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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Master.TituloPagina = "Visualizar Venta";
                ValorTotal = 0;
                lVenta = new Dyn.Database.logic.Venta();
                IdEntity = Convert.ToInt32(Request["Id"]);
                Entity = lVenta.Load(IdEntity);
                lblIdVenta.Text = Entity.IdVenta.ToString();
                lblFechaModificacion.Text = string.Format("{0:dd/MM/yyyy}", Entity.Fecha);
                LlenarItemsVenta();
            }
        }

        public void LlenarItemsVenta()
        {
            Dyn.Database.logic.DetalleVenta lDetalleVenta = new Database.logic.DetalleVenta();
            rptItems.DataSource = lDetalleVenta.SeleccionarProductosVenta((int)Entity.IdVenta);
            rptItems.DataBind();
        }

        protected void rpItems_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                ValorTotal += Convert.ToDouble(((Label)e.Item.FindControl("lblValorTotal")).Text);
                lblTotal.Text = ValorTotal.ToString();
            }
        }

        protected void btnVolveralistadoventa_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoVenta.aspx?IdMenuCategoria=6");
        }
    }
}