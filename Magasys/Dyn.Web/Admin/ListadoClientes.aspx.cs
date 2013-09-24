using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace Dyn.Web.Admin
{
    public partial class ListadoClientes : System.Web.UI.Page
    {
        private Dyn.Database.logic.Cliente lCliente;
        private int numeropaginas;
        private static List<Dyn.Database.entities.Cliente> listaClientes = new List<Database.entities.Cliente>();

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
                this.Master.TituloPagina = "Clientes";
                CargarCliente(null, null, null, null, null);

            }
            gvClientes.Visible = true;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre, apellido, alias;
            int? nroDoc, tipoDoc;
            if (txtNombre.Text == "")
            {
                nombre = null;
            }
            else
            {
                nombre = txtNombre.Text.Trim();
            }
            if (txtApellido.Text == "")
            { apellido = null; }
            else
            { apellido = txtApellido.Text.Trim(); }
            if (txtAlias.Text == "")
            { alias = null; }
            else
            { alias = txtAlias.Text.Trim(); }
            if (txtNroDocumento.Text == "")
            { nroDoc = null; }
            else 
            { nroDoc = Convert.ToInt32(txtNroDocumento.Text.Trim()); }
            tipoDoc = Convert.ToInt32(lstTipoDoc.SelectedValue.ToString());

            CargarCliente(nombre, apellido, alias, tipoDoc, nroDoc);

            if (txtNombre.Text == string.Empty)
            {
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
        public void CargarCliente(string nombre, string apellido, string alias, int? tipoDoc, int? nroDoc)
        {
            lCliente = new Dyn.Database.logic.Cliente();
            List<Dyn.Database.entities.Cliente> listaClientes = lCliente.SeleccionarClientePorNombrePaginadoAdmin(nombre, apellido, alias, nroDoc, tipoDoc, Pagina, ref numeropaginas);
            int[] array;
            array = new int[numeropaginas];
            gvClientes.DataSource = listaClientes;
            gvClientes.DataKeyNames = new String[] { "nroCliente" };
            gvClientes.DataBind();
        }

        protected void btnAdicionarCliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Admin/ABMClientes.aspx");
        }

        protected void lstTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void gvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/ABMClientes.aspx?Id=" + gvClientes.SelectedDataKey.Value);
        }


    }
}