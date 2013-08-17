using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Dyn.Database.entities;

namespace Dyn.Web.Admin
{
    public partial class Devoluciones : System.Web.UI.Page
    {
        public static Dyn.Database.entities.Devolucion Entity;
        private int numeropaginas;
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
            this.Master.TituloPagina = "Realizar Devolucion";
            LlenarProveedor();
            if (!IsPostBack)
            {
                calFecha.SelectedDate = DateTime.Today;

                if (Request["Id"] == null)
                {
                    IdEntity = 0;
                    Entity = new Dyn.Database.entities.Devolucion();
                }

            }
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
                lstProveedor.Items.Add(li);
            }
        }

        protected void btnSeleccionarProveedor_Click(object sender, EventArgs e)
        {
            lstProveedor.Enabled = false;
            int idProveedor = Convert.ToInt32(lstProveedor.SelectedValue);
            CargarDetalles(idProveedor);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

        }
        protected void CargarDetalles(int idProveedor)
        {
            Database.logic.ProductoEdicion2 lProductoEdicion = new Database.logic.ProductoEdicion2();
            List<Dyn.Database.entities.ProductoEdicion> listaProductos = lProductoEdicion.SeleccionarProductoPorProveedor(idProveedor);
            for (int i = 0; i < listaProductos.Count; i++)
            {
                Database.entities.DetalleDevolucion det = new Database.entities.DetalleDevolucion();
                det.ProductoEdicion = listaProductos[i];
                Database.entities.Producto prod = new Database.entities.Producto();
                Database.logic.Producto lProducto = new Database.logic.Producto();
                prod = lProducto.Load(Convert.ToInt32(listaProductos[i].IdProducto));
                det.Producto = prod;
                det.Cantidad = listaProductos[i].CantidadUnidades;
                Database.logic.DetalleIngreso lDetalleIngreso = new Database.logic.DetalleIngreso();
                Database.entities.DetalleIngresoProducto detIng = lDetalleIngreso.ObtenerDetallePorEdicion(Convert.ToInt32(listaProductos[i].IdProductoEdicion));
                det.IdDetalleIngresoProductos = detIng.IdDetalleIngresoProducto;
                Entity.AgregarDetalle(det);
            }
            gvDetalles.DataSource = Entity.ListaDetalles;
            gvDetalles.DataBind();

            
            

        }



    }
}