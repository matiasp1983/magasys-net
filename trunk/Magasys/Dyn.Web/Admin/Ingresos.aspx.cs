using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dyn.Database.logic;
using Dyn.Database.entities;

namespace Dyn.Web.Admin
{
    public partial class Ingresos : System.Web.UI.Page
    {
        // private int numeropaginas;
        private Dyn.Database.logic.Producto lProducto;
        public Dyn.Database.entities.Producto newProducto;
        // private Dyn.Database.logic.Ingreso lIngreso;
        public static Dyn.Database.entities.IngresoProducto Entity;
        public List<Dyn.Database.entities.DetalleIngresoProducto> listaDetalles;
        public static List<Dyn.Database.entities.Producto> listaProductos = new List<Database.entities.Producto>();
        public static List<Dyn.Database.entities.Reserva> listaReservas = new List<Database.entities.Reserva>();
        public static List<Dyn.Database.entities.Reserva> listaReservasOK = new List<Database.entities.Reserva>();
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
                this.Master.TituloPagina = "Ingreso de productos";
                //WUCBuscarProducto1.Visible = false;
                calFecha.CalendarDate = DateTime.Today;
                panReservas.Visible = false;
                LlenarProveedor();

                listaProductos.Clear();
                listaReservasOK.Clear();
                listaReservas.Clear();

                
                //repDetalle.DataSource = listaDetalles;
                lProducto = new Database.logic.Producto();
                

                if (Request["Id"] == null)
                {
                    IdEntity = 0;
                    Entity = new Dyn.Database.entities.IngresoProducto();
                }

            }
            
            //WUCBuscarProducto1.SeleccionoProducto += new EventHandler(WUCBuscarProducto_SeleccionoProducto);
        }

        void WUCBuscarProducto_SeleccionoProducto(object sender, EventArgs e)
        {
            //WUCBuscarProducto1.Visible = false;
            //int prodSel = Convert.ToInt32(WUCBuscarProducto1.IdEntity);

            //AgregarProducto(prodSel);

            //TxtIDRevista.Text = revista.IdRevista.ToString();
            //TxtNomRevista.Text = revista.Nombre;
            //WUCBuscarRevista1.Visible = false;
            //BtnRevista.Visible = true;
        }
        protected void AgregarProducto(int idProducto)
        {
            listaDetalles = new List<DetalleIngresoProducto>();    
             
            Dyn.Database.entities.DetalleIngresoProducto detalle = new DetalleIngresoProducto();
            lProducto = new Database.logic.Producto();
            newProducto = lProducto.Load(idProducto);
            newProducto.IdProducto = idProducto;
            detalle.Producto = newProducto;
            detalle.ProductoEdicion = new Database.entities.ProductoEdicion();
            detalle.ProductoEdicion.IdProducto = newProducto.IdProducto;
            detalle.CalcularDevolucion();
            
            Entity.AgregarDetalle(detalle);

            listaDetalles = Entity.ObtenerDetalles();
            
        }
        
        protected void btnQuitar_Click(object sender, EventArgs e)
        { 
        
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Database.logic.Ingreso lIngreso = new Database.logic.Ingreso();
            listaDetalles = new List<DetalleIngresoProducto>();
            listaDetalles = Entity.DetalleIngreso;

            Entity.Fecha = DateTime.Now;
            Entity.DetalleIngreso = listaDetalles;
            Entity.IdProveedor = Convert.ToInt32(lstProveedor.SelectedValue);

            if (panBusquedaProductos.Visible == true)
            {
                ValidarReservas();
                panBusquedaProductos.Visible = false;
                panDetalleIngreso.Visible = false;
                gvReservasOk.DataSource = null;
            }
            else
            {
                Dyn.Database.logic.Estado lEstado = new Database.logic.Estado();
                
                int idIngreso = Convert.ToInt32(lIngreso.Insert(Entity));
                Dyn.Database.entities.IngresoProducto ingreso = lIngreso.Load(idIngreso);
                Dyn.Database.logic.ReservaEdicion lReservaEdicion = new Dyn.Database.logic.ReservaEdicion();

                List<Dyn.Database.entities.ReservaEdicion> nuevasReservas = new List<Database.entities.ReservaEdicion>();
                for (int i = 0; i < listaReservasOK.Count; i++)
                {
                    Dyn.Database.entities.ReservaEdicion nueva = new Dyn.Database.entities.ReservaEdicion();
                    for (int j = 0; j < ingreso.DetalleIngreso.Count; j++)
                    { 
                        if (ingreso.DetalleIngreso[j].Producto.IdProducto == listaReservasOK[i].IdProducto)
                        {
                           nueva.ProductoEdicion = ingreso.DetalleIngreso[j].ProductoEdicion;
                           nueva.FechaFin = Convert.ToDateTime(ingreso.DetalleIngreso[j].FechaDevolucion);
                        }
                    }
                    nueva.Reserva = listaReservasOK[i];
                    //Cambiar despues que se cargue la lista de estados
                    nueva.IdEstado = lEstado.BuscarEstado("ReservasEdicion", "Confirmado");
                    nueva.CargarDatosDeReserva();
                    nueva.CodReserva = nueva.Reserva.CodReserva;

                    //nueva.Estado.IdEstado = lEstado.("Ingresos","Registrado");
                    lReservaEdicion.Insert(nueva);
                }
                ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se guardaron los datos correctamente');location.href('/Admin/ListadoUsuario.aspx');", true);
                Response.Redirect("/Home.aspx");
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
            Dyn.Database.logic.Producto lProducto = new Database.logic.Producto();
            listaProductos = lProducto.SeleccionarProductoPorIdProveedor(txtNombreProd.Text, Convert.ToInt32(lstProveedor.SelectedValue));
            lstProveedor.Enabled = false;
            gvProductos.DataSource = listaProductos;
            gvProductos.DataKeyNames = new String[] { "idProducto" };
            gvProductos.Visible = true;
            gvProductos.DataBind();
        }

        protected void gvProductos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            //int idProducto = Convert.ToInt32(gvProductos.DataKeys[e.NewSelectedIndex].Value.ToString());
            //GridViewRow row = gvProductos.Rows[e.NewSelectedIndex];

            int idProducto = Convert.ToInt32(listaProductos[e.NewSelectedIndex].IdProducto);
            AgregarProducto(idProducto);
            gvDetalle.DataSource = Entity.DetalleIngreso;
            gvDetalle.Visible = true;
            gvDetalle.DataBind();
            gvProductos.Visible = false;
            gvProductos.DataSource = null;
            labAyuda.Text = "Indique Cantidad, Precio y Descripcion para los Productos";
            labAyuda.ForeColor = System.Drawing.Color.Black;
        }

        protected void gvDetalle_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvDetalle.EditIndex = e.NewEditIndex;

            // fetch and rebind the data.
            gvDetalle.DataSource = Entity.DetalleIngreso;
            gvDetalle.DataKeyNames = new String[] { "IdDetalleIngresoProducto" };
            gvDetalle.DataBind();
        }

        protected void gvDetalle_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvDetalle.EditIndex = -1;

            // fetch and rebind the data.
            gvDetalle.DataSource = Entity.DetalleIngreso;
            gvDetalle.DataKeyNames = new String[] { "IdDetalleIngresoProducto" };
            gvDetalle.DataBind();
            
        }

        protected void gvDetalle_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //int key = Convert.ToInt32(gvDetalle.DataKeys[e.RowIndex].Value);
            int key = e.RowIndex;
            List<Database.entities.DetalleIngresoProducto> det = Entity.DetalleIngreso;
            for (int i = 0; i < det.Count; i++)
            {
                if (i == key)
                {
                    det.Remove(det[i]);
                    // return;
                }
            }
            Entity.DetalleIngreso = det;
            gvDetalle.DataSource = Entity.DetalleIngreso;
            gvDetalle.DataKeyNames = new String[] { "IdDetalleIngresoProducto" };
            gvDetalle.DataBind();
        }

        protected void gvDetalle_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            List<Database.entities.DetalleIngresoProducto> det = Entity.DetalleIngreso;
            int key = e.RowIndex;

            det[key].CantidadUnidades = Convert.ToInt32(e.NewValues["CantidadUnidades"]);
            det[key].ProductoEdicion.CantidadUnidades = det[key].CantidadUnidades;
            det[key].ProductoEdicion.Precio = Convert.ToInt32(e.NewValues["ProductoEdicion.Precio"]);
            det[key].ProductoEdicion.Descripcion = Convert.ToString(e.NewValues["ProductoEdicion.Descripcion"]);
            Entity.DetalleIngreso = det;
            gvDetalle.DataSource = Entity.DetalleIngreso;
            gvDetalle.DataKeyNames = new String[] { "IdDetalleIngresoProducto" };
            gvDetalle.EditIndex = -1;
            gvDetalle.DataBind();
            btnGuardar.Enabled = true;
            labAyuda.Text = "Seleccione los Productos que desea ingresar";
            labAyuda.ForeColor = System.Drawing.Color.Black;
        }
        public void ValidarReservas()
        {
            Dyn.Database.logic.Reserva lReserva = new Dyn.Database.logic.Reserva();
            List<Dyn.Database.entities.Producto> listaProductos = new List<Dyn.Database.entities.Producto>();
            for (int i = 0; i < Entity.DetalleIngreso.Count; i++)
            { 
                Dyn.Database.entities.DetalleIngresoProducto detalle = Entity.DetalleIngreso[i];
                listaProductos.Add(detalle.Producto);
            }
            listaReservas = lReserva.BuscarReservasPorProductos(listaProductos);
            gvReservas.DataSource = listaReservas;
            gvReservas.DataBind();
            panReservas.Visible = true;
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

        protected void gvReservas_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            listaReservasOK.Add(listaReservas[e.NewSelectedIndex]);
            listaReservas.Remove(listaReservas[e.NewSelectedIndex]);
            gvReservasOk.DataSource = listaReservasOK;
            gvReservasOk.Visible = true;
            gvReservasOk.DataBind();
            gvReservas.DataSource = listaReservas;
            gvReservas.Visible = true;
            gvReservas.DataBind();
            if (listaReservas.Count == 0)
            {
                lblMensaje.Text = "No hay Reservas sin Confirmar";
                lblMensaje.ForeColor = System.Drawing.Color.Black;
            }

        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/HomeAdmin.aspx");
        }

        protected void gvReservasOk_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //int key = Convert.ToInt32(gvDetalle.DataKeys[e.RowIndex].Value);
            int key = e.RowIndex;
            //List<Database.entities.ReservaEdicion> det = Entity.DetalleIngreso;
            for (int i = 0; i < listaReservasOK.Count; i++)
            {
                if (i == key)
                {
                    listaReservasOK.Remove(listaReservasOK[i]);
                    // return;
                }
            }
           
            gvReservasOk.DataSource = listaReservasOK;
            //gvReservasOk.DataKeyNames = new String[] { "IdDetalleIngresoProducto" };
            gvReservasOk.DataBind();
        }

        protected void btnConfirmarTodos_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listaReservas.Count; i++)
            {
                listaReservasOK.Add(listaReservas[i]);
                
            }
            listaReservas.Clear();
            gvReservasOk.DataSource = listaReservasOK;
            gvReservasOk.Visible = true;
            gvReservasOk.DataBind();
            gvReservas.DataSource = listaReservas;
            gvReservas.Visible = true;
            gvReservas.DataBind();
            if (listaReservas.Count == 0)
            {
                lblMensaje.Text = "No hay Reservas sin Confirmar";
                lblMensaje.ForeColor = System.Drawing.Color.Black;
            }
        }





    }
}