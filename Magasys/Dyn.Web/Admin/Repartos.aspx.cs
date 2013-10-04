using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dyn.Web.Admin
{
    public partial class Repartos : System.Web.UI.Page
    {
        // private int numeropaginas;
        private Dyn.Database.logic.Producto lProducto;
        public Dyn.Database.entities.Producto newProducto;
        // private Dyn.Database.logic.Ingreso lIngreso;
        public static Dyn.Database.entities.IngresoProducto Entity;
        public List<Dyn.Database.entities.DetalleIngresoProducto> listaDetalles;
        public static List<Dyn.Database.entities.Producto> listaProductos = new List<Database.entities.Producto>();
        public static List<Dyn.Database.entities.Producto> listaProductosOK = new List<Database.entities.Producto>();
        public static List<Dyn.Database.entities.ReservaEdicion> listaReservas = new List<Database.entities.ReservaEdicion>();
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
                calFecha.CalendarDate = DateTime.Today;
                LlenarProveedor();
                listaProductosOK.Clear();

                lProducto = new Database.logic.Producto();

                if (Request["Id"] == null)
                {
                    IdEntity = 0;
                    Entity = new Dyn.Database.entities.IngresoProducto();
                }

            }

        }


        protected void lstProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbNombre.Visible = true;
            txtNombreProd.Visible = true;
            btnBuscar.Visible = true;

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            panProductos.Visible = true;
            Dyn.Database.logic.Producto lProducto = new Database.logic.Producto();
            listaProductos = lProducto.SeleccionarProductoPorIdProveedor(txtNombreProd.Text, Convert.ToInt32(lstProveedores.SelectedValue));
            gvProductos.DataSource = listaProductos;
            gvProductos.DataKeyNames = new String[] { "idProducto" };
            gvProductos.Visible = true;
            gvProductos.DataBind();
        }

        protected void gvProductos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            listaProductosOK.Add(listaProductos[e.NewSelectedIndex]);
            gvBusqueda.DataSource = listaProductosOK;
            gvBusqueda.Visible = true;
            gvBusqueda.DataBind();
            listaProductos.Remove(listaProductos[e.NewSelectedIndex]);
            gvProductos.DataSource = listaProductos;
            gvProductos.DataBind();
            panProductos.Visible = true;
        }

        public void LlenarProveedor()
        {
            Dyn.Database.logic.Proveedor lProveedor = new Dyn.Database.logic.Proveedor();
            List<Dyn.Database.entities.Proveedor> listaproveedor = lProveedor.SeleccionarTodosLosProveedores();
            ListItem li;
            for (int i = 0; i < listaproveedor.Count; i++)
            {
                li = new ListItem();
                li = new ListItem(listaproveedor[i].RazonSocial, listaproveedor[i].IdProveedor.ToString());
                lstProveedores.Items.Add(li);
            }
        }

        protected void btnBuscarRepartos_Click(object sender, EventArgs e)
        {
            panSeleccion.Visible = false;
            panListadoRepartos.Visible = true;
            Dyn.Database.logic.ReservaEdicion lReserva = new Database.logic.ReservaEdicion();
            listaReservas = lReserva.BuscarReservasPorProductos(listaProductosOK);
            gvRepartos.DataSource = listaReservas;
            gvRepartos.DataBind();

        }

        protected void btnImprimir_Click(object sender, EventArgs e)
        {
            Dyn.Database.logic.Reparto lReparto = new Database.logic.Reparto();
            lReparto.Delete();
            lReparto.Insert(listaReservas);
            ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se guardaron los datos correctamente');location.href('/Admin/ListadoUsuario.aspx');", true);
            Response.Redirect("/Home.aspx");
            
        }








    }
}