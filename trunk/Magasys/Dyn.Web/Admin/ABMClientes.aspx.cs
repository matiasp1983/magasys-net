using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dyn.Web.Admin
{
    public partial class ABMClientes : System.Web.UI.Page
    {
        private Dyn.Database.logic.Cliente lCliente;
        public Dyn.Database.entities.Cliente Entity;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            btnEliminar.Attributes.Add("onclick", "return confirm_delete('Desea eliminar el Proveedor?');");
            if (!IsPostBack)
            {
                this.Master.TituloPagina = "Edici&oacute;n Cliente";
                lCliente = new Dyn.Database.logic.Cliente();
                LlenarTipoDocumento();
                LlenarProvincias();
                lstProvincias.SelectedIndex = 1;
                LlenarLocalidades();
                if (Request["Id"] == null)
                {
                    IdEntity = 0;
                    Entity = new Dyn.Database.entities.Cliente();
                }
                else
                    if (Request["Id"] != null)
                    {
                        IdEntity = Convert.ToInt32(Request["Id"]);
                        Entity = lCliente.Load(IdEntity);
                        Dyn.Database.logic.Localidad lLocalidad = new Database.logic.Localidad();
                        Dyn.Database.entities.Localidad localidad = lLocalidad.Load(Convert.ToInt32(Entity.IdLocalidad));
                        lstProvincias.SelectedValue = localidad.IdProvincia.ToString();
                        LlenarLocalidades();
                        lstLocalidades.SelectedValue = Entity.IdLocalidad.ToString();
                    }
                DataBind();
            }
        }

        public Dyn.Database.entities.Cliente CargarDatosCliente()
        {
            Entity = new Dyn.Database.entities.Cliente();
           
            // Entity.NroCliente = Convert.ToInt32(txtNroCliente.Text.Trim());

            Entity.TipoDocumento.IdTipoDocumento = Convert.ToInt32(lstTipoDoc.SelectedValue.ToString());
            Entity.NroDocumento = Convert.ToInt32(txtNroDocumento.Text.Trim());

            Entity.Nombre = txtNombre.Text.Trim();
            Entity.Apellido = txtApellido.Text.Trim();
            Entity.Alias = txtAlias.Text.Trim();

            if (txtTelefono.Text == "")
            { Entity.Telefono = null; }
            else
            { Entity.Telefono = txtTelefono.Text.Trim(); }

            if (txtCelular.Text == "")
            { Entity.Celular = null; }
            else
            { Entity.Celular = txtCelular.Text.Trim(); }
    
            Entity.Email = txtEMail.Text.Trim();

            Entity.DomicilioBarrio = txtBarrio.Text.Trim();
            Entity.DomicilioCalle = txtCalle.Text.Trim();
            if (txtNumero.Text == "")
                {   Entity.DomicilioNro = null;}
            else
                {   Entity.DomicilioNro = Convert.ToInt16(txtNumero.Text);}
            Entity.DomicilioPiso = txtPiso.Text.Trim();
            Entity.DomicilioDpto = txtDpto.Text.Trim();
            Entity.IdLocalidad = Convert.ToInt16(lstLocalidades.SelectedValue.ToString());
            Entity.DomicilioCodPostal = txtCodPostal.Text.Trim();

            return Entity;
        }

        public void LimpiarControles()
        {
            txtNumero.Text = string.Empty;
            txtAlias.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtBarrio.Text = string.Empty;
            txtCalle.Text = string.Empty;
            txtCelular.Text = string.Empty;
            txtCodPostal.Text = string.Empty;
            txtDpto.Text = string.Empty;
            txtEMail.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtNroDocumento.Text = string.Empty;
            txtPiso.Text = string.Empty;
            txtTelefono.Text = string.Empty;
        }

        public void Update()
        {
            lCliente = new Dyn.Database.logic.Cliente();
            Entity = new Dyn.Database.entities.Cliente();
            
            if (IdEntity == 0)
            {
                Entity = CargarDatosCliente();
                Dyn.Database.logic.Estado lEstado = new Dyn.Database.logic.Estado();
                int estado = lEstado.BuscarEstado("Clientes", "Alta");
                Entity.Estado.IdEstado = estado;
                Entity.FechaAlta = DateTime.Now;
                lCliente.Insert(Entity);
                ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se guardaron los datos correctamente');location.href('ListadoClientes.aspx?IdMenuCategoria=14');", true);

            }
            else
                if (IdEntity > 0)
                {
                    Entity = CargarDatosCliente();
                    Entity.NroCliente = IdEntity;
                    Dyn.Database.logic.Estado lEstado = new Dyn.Database.logic.Estado();
                    int estado = lEstado.BuscarEstado("Clientes", "Alta");
                    Entity.Estado.IdEstado = estado;
                    Entity.FechaAlta = DateTime.Now;
                    
                    lCliente.Update(Entity);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se actualizaron los datos correctamente');", true);
                }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Update();
            LimpiarControles();
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
              if (IdEntity != 0 && IdEntity != int.MinValue)
            {
                Entity = CargarDatosCliente();
                if (Entity.validarBaja())
                {
                    Entity = CargarDatosCliente();
                    Entity.NroCliente = IdEntity;
                    lCliente = new Dyn.Database.logic.Cliente();
                    Dyn.Database.logic.Estado lEstado = new Dyn.Database.logic.Estado();
                    int estado = lEstado.BuscarEstado("Clientes", "Baja");
                    Entity.Estado.IdEstado = estado;
                    Entity.FechaAlta = DateTime.Now;
                    lCliente.Delete(Entity);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se borró el Cliente correctamente');", true);
                    Response.Redirect("ListadoClientes.aspx?IdMenuCategoria=14");
                }
                else
                { 
                    // no se puede borrar, existen ventas o reservas para el cliente
                }
                
            }
              LimpiarControles();
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Home.aspx");
            // Response.Redirect("ListadoClientes.aspx?IdMenuCategoria=14");
        }

        public void LlenarProvincias()
        {
            Dyn.Database.logic.Provincia lProvincia = new Dyn.Database.logic.Provincia();
            List<Dyn.Database.entities.Provincia> listaProvincias = lProvincia.SeleccionarTodasLasProvicias();
            ListItem li;
            for (int i = 0; i < listaProvincias.Count; i++)
            {
                li = new ListItem();
                li = new ListItem(listaProvincias[i].Nombre, listaProvincias[i].IdProvincia.ToString());
                lstProvincias.Items.Add(li);
            }
        }
        public void LlenarLocalidades()
        {
            if (lstProvincias.SelectedIndex == -1)
            { }
            else
            {
                int idProvincia = Convert.ToInt16(lstProvincias.SelectedItem.Value.ToString());
                Dyn.Database.logic.Localidad lLocalidad = new Dyn.Database.logic.Localidad();
                List<Dyn.Database.entities.Localidad> listaLocalidades = lLocalidad.SeleccionarLocalidadesPorProvincia(idProvincia);
                ListItem li;
                lstLocalidades.Items.Clear();

                for (int i = 0; i < listaLocalidades.Count; i++)
                {
                    li = new ListItem();
                    li = new ListItem(listaLocalidades[i].Nombre, listaLocalidades[i].IdLocalidad.ToString());
                    lstLocalidades.Items.Add(li);
                }

            }

        }
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
        protected void lstProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarLocalidades();
        }




    }
}