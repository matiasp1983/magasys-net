using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.logic;

namespace Dyn.Web.Admin
{
    public partial class Ingresos : System.Web.UI.Page
    {

        private Dyn.Database.logic.Producto lProducto;
        public Dyn.Database.entities.Producto newProducto;
        private Dyn.Database.logic.Ingreso lIngreso;
        public Dyn.Database.entities.IngresoProducto Entity;

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
                //CargarProducto("", "0");
                //LlenarProveedor();
                WUCBuscarProducto1.Visible = false;
                calFecha.SelectedDate = DateTime.Today;
                if (Request["Id"] == null)
                {
                    IdEntity = 0;
                    // Entity = new Dyn.Database.entities.Proveedor();
                    //DataSet ds = lProveedor.SeleccionarProveedorPorNombrePaginadoAdmin(criterio, Pagina, ref numeropaginas);
                    //int[] array;
                    //array = new int[numeropaginas];
                    //CollectionPager.DataSource = array;
                    //CollectionPager.DataBind();
                    repDetalle.DataSource = ds;
                    repDetalle.DataBind();
                }
                else
                    if (Request["Id"] != null)
                    {
                        IdEntity = Convert.ToInt32(Request["Id"]);
                        //Entity = lProveedor.Load(IdEntity);
                        //lstLocalidades.SelectedValue = Entity.IdLocalidad.ToString();
                    }
                DataBind();

            }
            else
            {   if (Request["IdProd"] != null && Convert.ToInt32(Request["IdProd"]) != IdEntity)
                {
                    int idProd = Convert.ToInt32(Request["Id"]);
                    newProducto = lProducto.Load(idProd);
                    // repDetalle
                }
                else
                    if (Request["Id"] != null)
                    {

                      //  Entity = lProveedor.Load(IdEntity);
                       // lstLocalidades.SelectedValue = Entity.IdLocalidad.ToString();
                    }
                DataBind();
            }
        }

        protected void btnMostrarProductos_Click(object sender, EventArgs e)
        {
            WUCBuscarProducto1.Visible = true;
        }

    }
}