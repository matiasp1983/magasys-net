using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dyn.Web.Admin
{
    public partial class ListadoColeccion : System.Web.UI.Page
    {
        private Dyn.Database.logic.Coleccion lColeccion;
        private int numeropaginas;
        private Dyn.Database.logic.Genero lGenero;
        public Dyn.Database.entities.Genero Entity;

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
                this.Master.TituloPagina = "Coleccion";
                CargarColeccion("");
            }
        }

        public void CargarColeccion(string criterio)
        {
            //lColeccion = new Dyn.Database.logic.Coleccion();
            //DataSet ds = lColeccion.SeleccionarColeccionPorNombrePaginadoAdmin(criterio, Pagina, ref numeropaginas);
            //int[] array;
            //array = new int[numeropaginas];
            //CollectionPager.DataSource = array;
            //CollectionPager.DataBind();
            //repColeccion.DataSource = ds;
            //repColeccion.DataBind();
        } 

        protected void btnAdicionarRevista_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/Coleccion.aspx");
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }
    }
}