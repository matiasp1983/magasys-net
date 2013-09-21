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
                //this.Master.TituloPagina = "Edici&oacute;n Proveedor";
                lCliente = new Dyn.Database.logic.Cliente();
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
        public void Update()
        {
            lCliente = new Dyn.Database.logic.Cliente();
            Entity = new Dyn.Database.entities.Cliente();

            if (IdEntity == 0)
            {
                Entity = CargarDatosCliente();
                Dyn.Database.logic.Estado lEstado = new Dyn.Database.logic.Estado();
                int estado = lEstado.BuscarEstado("Clientes","Alta");
                Entity.Estado.IdEstado = estado;
                Entity.FechaAlta = DateTime.Now;
                lCliente.Insert(Entity);
                ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se guardaron los datos correctamente');location.href('/Admin/ListadoUsuario.aspx');", true);

            }
            else
                if (IdEntity > 0)
                {
                    Entity = CargarDatosCliente();
                    Entity.NroCliente = IdEntity;
                    lCliente.Update(Entity);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se actualizaron los datos correctamente');", true);
                }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Update();
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
              if (IdEntity != 0 && IdEntity != int.MinValue)
            {
                if (Entity.validarBaja())
                {
                    lCliente = new Dyn.Database.logic.Cliente();
                    lCliente.Delete(IdEntity);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se borró el género correctamente');document.location.href='/Admin/ListadoCliente.aspx';", true);
                }
                else
                { 
                    // no se puede borrar, existen ventas o reservas para el cliente
                }
                
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoCliente.aspx");
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
        protected void lstProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarLocalidades();
        }




    }
}