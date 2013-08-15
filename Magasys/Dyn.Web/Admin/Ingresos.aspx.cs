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
        private int numeropaginas;
        private Dyn.Database.logic.Producto lProducto;
        public Dyn.Database.entities.Producto newProducto;
        private Dyn.Database.logic.Ingreso lIngreso;
        public static Dyn.Database.entities.IngresoProducto Entity;
        public List<Dyn.Database.entities.DetalleIngresoProducto> listaDetalles;

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
                WUCBuscarProducto1.Visible = false;
                calFecha.SelectedDate = DateTime.Today;
                
                repDetalle.DataSource = listaDetalles;
                lProducto = new Database.logic.Producto();

                if (Request["Id"] == null)
                {
                    IdEntity = 0;
                    Entity = new Dyn.Database.entities.IngresoProducto();
                }

            }
            
            WUCBuscarProducto1.SeleccionoProducto += new EventHandler(WUCBuscarProducto_SeleccionoProducto);
        }

        protected void btnMostrarProductos_Click(object sender, EventArgs e)
        {
            WUCBuscarProducto1.Visible = true;
        }
        void WUCBuscarProducto_SeleccionoProducto(object sender, EventArgs e)
        {
            WUCBuscarProducto1.Visible = false;
            int prodSel = Convert.ToInt32(WUCBuscarProducto1.IdEntity);

            AgregarProducto(prodSel);

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
            detalle.Producto = newProducto;
                    
            
            Entity.AgregarDetalle(detalle);

            listaDetalles = Entity.ObtenerDetalles();
            //listaDetalles.Add(detalle);
            repDetalle.DataSource = listaDetalles;
            repDetalle.DataBind();


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
    }
}