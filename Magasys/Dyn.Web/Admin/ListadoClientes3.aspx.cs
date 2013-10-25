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
                this.Master.TituloPagina = "Listado de clientes";
                //CargarCliente(null, null, null, null, null);
                LlenarTipoDocumento();
                listaClientes.Clear();
            }
            gvClientes.Visible = true;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombre, apellido, alias;
            int? nroDoc, tipoDoc;
            if (txtNroDocumento.Text == "")
            { nroDoc = null; }
            else
            { nroDoc = Convert.ToInt32(txtNroDocumento.Text.Trim()); }
            tipoDoc = Convert.ToInt32(lstTipoDoc.SelectedValue.ToString());
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
            

            CargarCliente(tipoDoc, nroDoc, nombre, apellido, alias);

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
        public void CargarCliente(int? tipoDoc, int? nroDoc, string nombre, string apellido, string alias)
        {
            lCliente = new Dyn.Database.logic.Cliente();
            listaClientes = lCliente.SeleccionarClientePorNombrePaginadoAdmin(tipoDoc, nroDoc, nombre, apellido, alias, Pagina, ref numeropaginas);
      
            int[] array;
            array = new int[numeropaginas];
            gvClientes.DataSource = listaClientes;
            gvClientes.DataKeyNames = new String[] {"nroDocumento"};
            gvClientes.DataBind();
        }

        protected void btnAdicionarCliente_Click(object sender, EventArgs e)
        {
           // Response.Redirect("/Admin/ABMClientes.aspx");
           // Admin/ABMClientes.aspx?IdMenuCategoria=2
            Response.Redirect("ABMClientes.aspx?IdMenuCategoria=2");
        }

        protected void lstTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        //Response.Redirect("~/Admin/ABMClientes.aspx?Id=" + listaClientes[e.NewSelectedIndex].NroCliente);
        public void LlenarTipoDocumento()
        {
            Dyn.Database.logic.TipoDocumento lTipoDoc = new Dyn.Database.logic.TipoDocumento();
            List<Dyn.Database.entities.TipoDocumento> listaTipoDoc = lTipoDoc.SeleccionarTodosLosTiposDocumento();
            ListItem li;
            lstTipoDoc.Items.Clear();

            for (int i = 0; i < listaTipoDoc.Count; i++)
            {
                li = new ListItem();
                li = new ListItem(listaTipoDoc[i].Nombre, listaTipoDoc[i].IdTipoDocumento.ToString());
                lstTipoDoc.Items.Add(li);
            }



        }

        protected void gvClientes_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            Response.Redirect("~/Admin/ABMClientes.aspx?Id=" + listaClientes[e.NewSelectedIndex].NroCliente);
        }

    }
}