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
                panSeleccion.Visible = false;
                //this.Master.TituloPagina = "Ingreso de productos";
                //WUCBuscarProducto1.Visible = false;
                calFecha.SelectedDate = DateTime.Today;


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
        //    listaDetalles = new List<DetalleIngresoProducto>();

        //    Dyn.Database.entities.DetalleIngresoProducto detalle = new DetalleIngresoProducto();
        //    lProducto = new Database.logic.Producto();
        //    newProducto = lProducto.Load(idProducto);
        //    newProducto.IdProducto = idProducto;
        //    detalle.Producto = newProducto;
        //    detalle.ProductoEdicion = new Database.entities.ProductoEdicion();
        //    detalle.ProductoEdicion.IdProducto = newProducto.IdProducto;
        //    detalle.CalcularDevolucion();


        //    Entity.AgregarDetalle(detalle);

        //    listaDetalles = Entity.ObtenerDetalles();
        //    //listaDetalles.Add(detalle);
        //    //repDetalle.DataSource = listaDetalles;
        //    //repDetalle.DataBind();


        }

        //protected Database.entities.IngresoProducto CargarIngreso()
        //{
        //    //Entity = new Database.entities.IngresoProducto();
        //    //listaDetalles = new List<DetalleIngresoProducto>();

        //    //if (repDetalle.Items.Count == 0)
        //    //{
        //    //    listaDetalles = new List<DetalleIngresoProducto>();
        //    //    Entity = new Database.entities.IngresoProducto();
        //    //}
        //    //else
        //    //{
        //    //    // listaDetalles = (List<Dyn.Database.entities.DetalleIngresoProducto>)repDetalle.DataSource;
        //    //    DataSet ds = (DataSet)repDetalle.DataSource;
        //    //    for (int i = 0; i < listaDetalles.Count; i++)
        //    //    {
        //    //        Entity.AgregarDetalle(listaDetalles[i]);
        //    //    }
        //    //}
        //    //return Entity;

        //}
        protected void btnQuitar_Click(object sender, EventArgs e)
        {

        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            //Database.logic.Ingreso lIngreso = new Database.logic.Ingreso();
            //listaDetalles = new List<DetalleIngresoProducto>();
            //listaDetalles = Entity.DetalleIngreso;

            //Entity.Fecha = DateTime.Now;
            //Entity.DetalleIngreso = listaDetalles;
            //Entity.IdProveedor = Convert.ToInt32(lstProveedores.SelectedValue);

            //lIngreso.Insert(Entity);
            //ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se guardaron los datos correctamente');location.href('/Admin/ListadoUsuario.aspx');", true);
            //Response.Redirect("/Home.aspx");
        }

        protected void lstProveedores_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbNombre.Visible = true;
            txtNombreProd.Visible = true;
            btnBuscar.Visible = true;

        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            //Dyn.Database.logic.Producto lProducto = new Database.logic.Producto();
            //listaProductos = lProducto.SeleccionarProductoPorIdProveedor(txtNombreProd.Text, Convert.ToInt32(lstProveedores.SelectedValue));
            //lstProveedores.Enabled = false;
            //gvProductos.DataSource = listaProductos;
            //gvProductos.DataKeyNames = new String[] { "idProducto" };
            //gvProductos.Visible = true;
            //gvProductos.DataBind();
        }

        protected void gvProductos_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {

            int idProducto = Convert.ToInt32(listaProductos[e.NewSelectedIndex].IdProducto);
            AgregarProducto(idProducto);
            gvBusqueda.DataSource = Entity.DetalleIngreso;
            gvBusqueda.Visible = true;
            gvBusqueda.DataBind();
            //gvProductos.Visible = true;
            gvProductos.DataSource = null;
        }

        protected void gvDetalle_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //gvDetalle.EditIndex = e.NewEditIndex;

            //// fetch and rebind the data.
            //gvDetalle.DataSource = Entity.DetalleIngreso;
            //gvDetalle.DataKeyNames = new String[] { "IdDetalleIngresoProducto" };
            //gvDetalle.DataBind();
        }

        protected void gvDetalle_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            //gvDetalle.EditIndex = -1;

            //// fetch and rebind the data.
            //gvDetalle.DataSource = Entity.DetalleIngreso;
            //gvDetalle.DataKeyNames = new String[] { "IdDetalleIngresoProducto" };
            //gvDetalle.DataBind();

        }

        protected void gvDetalle_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            ////int key = Convert.ToInt32(gvDetalle.DataKeys[e.RowIndex].Value);
            //int key = e.RowIndex;
            //List<Database.entities.DetalleIngresoProducto> det = Entity.DetalleIngreso;
            //for (int i = 0; i < det.Count; i++)
            //{
            //    if (i == key)
            //    {
            //        det.Remove(det[i]);
            //        // return;
            //    }
            //}
            //Entity.DetalleIngreso = det;
            //gvDetalle.DataSource = Entity.DetalleIngreso;
            //gvDetalle.DataKeyNames = new String[] { "IdDetalleIngresoProducto" };
            //gvDetalle.DataBind();
        }

        protected void gvDetalle_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //List<Database.entities.DetalleIngresoProducto> det = Entity.DetalleIngreso;
            //int key = e.RowIndex;

            //det[key].CantidadUnidades = Convert.ToInt32(e.NewValues["CantidadUnidades"]);
            //det[key].ProductoEdicion.CantidadUnidades = det[key].CantidadUnidades;
            //det[key].ProductoEdicion.Precio = Convert.ToInt32(e.NewValues["ProductoEdicion.Precio"]);
            //det[key].ProductoEdicion.Descripcion = Convert.ToString(e.NewValues["ProductoEdicion.Descripcion"]);
            //Entity.DetalleIngreso = det;
            //gvDetalle.DataSource = Entity.DetalleIngreso;
            //gvDetalle.DataKeyNames = new String[] { "IdDetalleIngresoProducto" };
            //gvDetalle.EditIndex = -1;
            //gvDetalle.DataBind();
            //btnGuardar.Enabled = true;
        }






    }
}