using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace Dyn.Web.controls
{
    public partial class BuscarClientes : System.Web.UI.UserControl
    {
        private Dyn.Database.logic.Cliente lCliente;
        private Dyn.Database.entities.Cliente Entity;
        private RadioButton rdbClienteSeccionado;
        private Label LabelNombre;
        private Label LabelApellido;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarTipoDocumento();
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            bool encontrado = false;
            foreach (RepeaterItem rptitem in rptClientes.Items)
            {
                rdbClienteSeccionado = rptitem.FindControl("rdbClienteSeccionado") as RadioButton;
                LabelNombre = rptitem.FindControl("lblNombre") as Label;
                LabelApellido = rptitem.FindControl("lblApellido") as Label;

                if (rdbClienteSeccionado.Checked)
                {
                    lblNroClienteText.Text = rdbClienteSeccionado.Text;
                    lblNombreApellidoText.Text = LabelNombre.Text + " " + LabelApellido.Text;
                    encontrado = true;
                    break;
                }
            }
            if (encontrado != true)
            {
                lblMensajeError.Text = "Debe seleccionar al menos un cliente.";
            }
            else
            {
                LimpiarControles();
                mpeClientes.Hide();
            }
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
            mpeClientes.Hide();
        }

        protected void btnBuscarClientes_Click(object sender, EventArgs e)
        {
            mpeClientes.Show();
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            Entity = new Dyn.Database.entities.Cliente();
            lCliente = new Database.logic.Cliente();
            int nroDoc = 0;

            if (txtNroDoc.Text != string.Empty)
            {
                nroDoc = int.Parse(txtNroDoc.Text);
            }

            DataSet ds = lCliente.BuscarClientes(txtAlias.Text, txtNombre.Text, txtApellido.Text, int.Parse(ddlTipoDoc.SelectedValue), nroDoc);
            if (ds.Tables[0].Rows.Count > 0)
            {
                rptClientes.DataSource = ds;
                rptClientes.DataBind();
                lblMensajeError.Text = string.Empty;
            }
            else
            {
                lblMensajeError.Text = "La búsqueda de clientes no arrojó resultados.";
            }
        }

        protected void rdbClienteSeccionado_OnCheckedChanged(object sender, EventArgs e)
        {
            foreach (RepeaterItem item in rptClientes.Items)
            {
                RadioButton rdbItem = item.FindControl("rdbClienteSeccionado") as RadioButton;
                rdbItem.Checked = false;
            }
            ((RadioButton)sender).Checked = true;
        }

        private void LimpiarControles()
        {
            lblMensajeError.Text = string.Empty;
            txtAlias.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtNroDoc.Text = string.Empty;
            rptClientes.DataSource = null;
            rptClientes.DataBind();
        }

        public void LlenarTipoDocumento()
        {
            Dyn.Database.logic.TipoDocumento lTipoDoc = new Dyn.Database.logic.TipoDocumento();
            List<Dyn.Database.entities.TipoDocumento> listaTipoDoc = lTipoDoc.SeleccionarTodosLosTiposDocumento();
            ListItem li;      
            for (int i = 0; i < listaTipoDoc.Count; i++)
            {
                li = new ListItem();
                li = new ListItem(listaTipoDoc[i].Nombre, listaTipoDoc[i].IdTipoDocumento.ToString());
                ddlTipoDoc.Items.Add(li);
            }
        }
    }
}