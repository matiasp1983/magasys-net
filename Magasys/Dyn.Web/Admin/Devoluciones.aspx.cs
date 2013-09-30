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
        public static List<Dyn.Database.entities.DetalleDevolucion> listaDevoluciones = new List<DetalleDevolucion>();
        public static List<Dyn.Database.entities.DetalleDevolucion> listaDevolucionesOK = new List<DetalleDevolucion>();
        public static List<Dyn.Database.entities.ReservaEdicion> listaReservas = new List<ReservaEdicion>();

        private int numeropaginas;
        public static int editDetalle;

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
            this.Master.TituloPagina = "Devoluciones";
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
            gvDetalles.Visible = true;

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
            btnSeleccionarProveedor.Enabled = false;
            int idProveedor = Convert.ToInt32(lstProveedor.SelectedValue);
            CargarDetalles(idProveedor);
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //    FALTA REVISAR SI EXISTEN RESERVAS
            
            //if (gvReservas.Visible == false)
            //{
            
            //    gvReservas.Visible = true;
            //    panBusqueda.Visible = false;
            //    panProductos.Visible = false;
            //    Dyn.Database.logic.Estado lEstado = Dyn.Database.logic.Estado();
            //    for (int i = 0; i < listaDevoluciones.Count; i++)
            //    { 
            //        if (listaDevoluciones[i].ProductoEdicion.Estado == lEstado.BuscarEstado("ReservaEdicion","
            //    }


            //}
            //else
            //{
                Database.logic.Devolucion lDevolucion = new Database.logic.Devolucion();
                List<Database.entities.DetalleDevolucion> detalle = Entity.ListaDetalles;
                for (int i = 0; i < detalle.Count; i++)
                {
                    detalle[i].Devolver();
                    detalle[i].IdDetalleIngresoProductos = detalle[i].ProductoEdicion.ObtenerIdDetalleIngreso();
                }
                Entity.Fecha = DateTime.Now;
                Entity.IdProveedor = Convert.ToInt32(lstProveedor.SelectedValue);
                Entity.Descripcion = "";


                lDevolucion.Insert(Entity);
                ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se guardaron los datos correctamente');location.href('/Admin/ListadoUsuario.aspx');", true);
                Response.Redirect("/Home.aspx");
            //}

        }
        //protected void btnCambiarCantidad_Click(object sender, EventArgs e)
        //{
        //    List<Database.entities.DetalleDevolucion> det = Entity.ListaDetalles;
        //    det[editDetalle].Cantidad = Convert.ToInt32(txtCantidad.Text);
        //    Entity.ListaDetalles = det;
        //    gvDetalles.DataSource = Entity.ListaDetalles;
        //    gvDetalles.DataKeyNames = new String[] { "IdDetalleDevolucion" };
        //    gvDetalles.DataBind();
        //}

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
                prod.IdProducto = Convert.ToInt32(listaProductos[i].IdProducto);
                det.Producto = prod;
                det.Cantidad = listaProductos[i].CantidadUnidades;
                Database.logic.DetalleIngreso lDetalleIngreso = new Database.logic.DetalleIngreso();
                Database.entities.DetalleIngresoProducto detIng = lDetalleIngreso.ObtenerDetallePorEdicion(Convert.ToInt32(listaProductos[i].IdProductoEdicion));
                det.IdDetalleIngresoProductos = detIng.IdDetalleIngresoProducto;
                listaDevoluciones.Add(det);
                //Entity.AgregarDetalle(det);
            }
            gvDetalles.DataSource = listaDevoluciones;
            gvDetalles.DataKeyNames = new String[] { "IdDetalleDevolucion" };
            gvDetalles.DataBind();

            
            

        }
        //protected void gvDetalles_RowDeleting(object sender, GridViewDeleteEventArgs e)
        //{
        //    int key = Convert.ToInt32(gvDetalles.DataKeys[e.RowIndex].Value);
        //    List<Database.entities.DetalleDevolucion> det = Entity.ListaDetalles;
        //    for (int i = 0; i < det.Count; i++)
        //    {
        //        if (i == key)
        //        {
        //            det.Remove(det[i]);
        //            // return;
        //        }
        //    }
        //    listaDevoluciones = det;
        //    gvDetalles.DataSource = listaDevoluciones;
        //    gvDetalles.DataKeyNames = new String[] { "IdDetalleDevolucion" };
        //    gvDetalles.DataBind();
           
        //}

        protected void gvDetalles_RowEditing(object sender, GridViewEditEventArgs e)
        {

            gvDetalles.EditIndex = e.NewEditIndex;

            // fetch and rebind the data.
            gvDetalles.DataSource = listaDevoluciones;
            gvDetalles.DataKeyNames = new String[] { "IdDetalleDevolucion" };
            gvDetalles.DataBind();
        }
        protected void gvDetalles_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvDetalles.EditIndex = -1;

            // fetch and rebind the data.
            gvDetalles.DataSource = listaDevoluciones;
            gvDetalles.DataKeyNames = new String[] { "IdDetalleDevolucion" };
            gvDetalles.DataBind();
        }
        protected void gvDetalles_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            List<Database.entities.DetalleDevolucion> det = Entity.ListaDetalles;
            int key = e.RowIndex;

            det[key].Cantidad = Convert.ToInt32(e.NewValues["Cantidad"]);
            listaDevoluciones = det;
            gvDetalles.DataSource = listaDevoluciones;
            gvDetalles.DataKeyNames = new String[] { "IdDetalleDevolucion" };
            gvDetalles.EditIndex = -1;
            gvDetalles.DataBind();
            
        }

        protected void gvDetalles_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Entity.AgregarDetalle(listaDevoluciones[e.NewSelectedIndex]);
            gvDevoluciones.DataSource = Entity.ListaDetalles;
            gvDevoluciones.Visible = true;
            gvDevoluciones.DataBind();

            listaDevoluciones.Remove(listaDevoluciones[e.NewSelectedIndex]);
            gvDetalles.DataSource = listaDevoluciones;
            gvDetalles.Visible = true;
            gvDetalles.DataBind();

            btnGuardar.Enabled = true;
        }

        protected void gvDevoluciones_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int key = Convert.ToInt32(gvDevoluciones.DataKeys[e.RowIndex].Value);
            List<Database.entities.DetalleDevolucion> det = Entity.ListaDetalles;
            for (int i = 0; i < det.Count; i++)
            {
                if (i == key)
                {
                    det.Remove(det[i]);
                    // return;
                }
            }
            Entity.ListaDetalles = det;
            gvDevoluciones.DataSource = Entity.ListaDetalles;
            gvDevoluciones.DataKeyNames = new String[] { "IdDetalleDevolucion" };
            gvDevoluciones.DataBind();

            if (Entity.ListaDetalles.Count == 0)
            { btnGuardar.Enabled = false; }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Home.aspx");
        }

        protected void gvReservas_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            //Entity.AgregarDetalle(listaReservas[e.NewSelectedIndex]);
            //gvDevoluciones.DataSource = Entity.ListaDetalles;
            //gvDevoluciones.Visible = true;
            //gvDevoluciones.DataBind();

            //listaReservas.Remove(listaDevoluciones[e.NewSelectedIndex]);
            //gvReservas.DataSource = listaDevoluciones;
            //gvReservas.Visible = true;
            //gvReservas.DataBind();

            //btnGuardar.Enabled = true;
        }
    }
}