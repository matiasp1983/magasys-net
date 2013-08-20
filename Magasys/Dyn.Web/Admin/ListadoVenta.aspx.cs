using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dyn.Web.Admin
{
    public partial class ListadoVenta : System.Web.UI.Page
    {
        private Dyn.Database.logic.Venta lVenta;
        private int numeropaginas;

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
                this.Master.TituloPagina = "Listado de ventas";
                CargarVentas(DateTime.Now, DateTime.Now);
                calFechaInicial.CalendarDate = DateTime.Now.AddDays(-2);
                calFechaFinal.CalendarDate = DateTime.Now.AddDays(2); 
            }
        }

        public int CargarVentas(DateTime fechainicial, DateTime fechafinal)
        {
            lVenta = new Dyn.Database.logic.Venta();
            DataSet ds = lVenta.SeleccionarVentasPorNombrePaginadoAdmin(fechainicial, fechafinal, Pagina, ref numeropaginas);
            int[] array;
            array = new int[numeropaginas];
            CollectionPager.DataSource = array;
            CollectionPager.DataBind();
            rptVenta.DataSource = ds;
            rptVenta.DataBind();
            return numeropaginas;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            DateTime fechainicial = Convert.ToDateTime(calFechaInicial.CalendarDate);
            DateTime fechafinal = Convert.ToDateTime(calFechaFinal.CalendarDate);

            int i = CargarVentas(fechainicial, fechafinal);

            if (i  == 0)
            {   // Redireccionar a la primera página
                string url = string.Empty;
                if (Request.Url.ToString().Contains("?Page="))
                {
                    url = Request.Url.PathAndQuery;
                    Response.Redirect(url.Substring(0, url.Length - 1).Replace("?Page=", ""));
                }
                else
                {
                    Response.Redirect(url);
                }
            }
        }

    }
}