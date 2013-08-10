using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dyn.Web.Admin
{
    public partial class Proveedor : System.Web.UI.Page
    {
        private Dyn.Database.logic.Proveedor lProveedor;
        public Dyn.Database.entities.Proveedor Entity;

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
                this.Master.TituloPagina = "Edici&oacute;n Proveedor";
                lProveedor = new Dyn.Database.logic.Proveedor();
                LlenarProvincias();
                lstProvincias.SelectedIndex = 1;
                LlenarLocalidades();
                if (Request["Id"] == null)
                {
                    IdEntity = 0;
                    Entity = new Dyn.Database.entities.Proveedor();
                }
                else
                    if (Request["Id"] != null)
                    {
                        IdEntity = Convert.ToInt32(Request["Id"]);
                        Entity = lProveedor.Load(IdEntity);
                    }
                DataBind();
            }
        }

        public Dyn.Database.entities.Proveedor CargarDatosProveedor()
        {
            Entity = new Dyn.Database.entities.Proveedor();
            Entity.Cuit = txtCuit.Text.Trim();
            Entity.RazonSocial = txtRazonSocial.Text.Trim();
            Entity.Email =  txtEMail.Text.Trim();
            Entity.Detalle = txtDetalle.Text.Trim();
            Entity.Telefono = txtTelefono.Text.Trim();
            Entity.DomicilioCalle = txtCalle.Text.Trim();
            if (txtNumero.Text == "")
            {   Entity.DomicilioNro = null;}
            else
            {   Entity.DomicilioNro = Convert.ToInt16(txtNumero.Text);}
            
            Entity.DomicilioPiso = txtPiso.Text.Trim();
            Entity.DomicilioDpto= txtDpto.Text.Trim();
            Entity.IdLocalidad = lstLocalidades.SelectedIndex;
            Entity.ResponsableApellido = txtResponsableApellido.Text.Trim();
            Entity.ResponsableNombre = txtResponsableNombre.Text.Trim();
            Entity.ResponsableEmail = txtResponsableEmail.Text.Trim();
            Entity.Nombre = "";
            return Entity;
        }

        public void Update()
        {
            lProveedor = new Dyn.Database.logic.Proveedor();
            Entity = new Dyn.Database.entities.Proveedor();
            if (IdEntity == 0)
            {

                String idProveedor = txtCuit.Text;
                Entity = CargarDatosProveedor();

                if (lProveedor.existeCuit(idProveedor))
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Ya existe un proveedor con ese CUIT');location.href('/Admin/ListadoUsuario.aspx');", true);
                }
                else
                {
                    lProveedor.Insert(Entity);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se guardaron los datos correctamente');location.href('/Admin/ListadoUsuario.aspx');", true);
                }
                
            }
            else
                if (IdEntity > 0)
                {
                    Entity = CargarDatosProveedor();
                    Entity.IdProveedor = IdEntity;
                    lProveedor.Update(Entity);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se actualizaron los datos correctamente');", true);
                }
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
                    li = new ListItem(listaLocalidades[i].Nombre, listaLocalidades[i].Nombre.ToString());
                    lstLocalidades.Items.Add(li);
                }
            
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Dyn.Database.logic.Revista rev = new Dyn.Database.logic.Revista();
            if (IdEntity != 0 && IdEntity != int.MinValue)
            {
                lProveedor = new Dyn.Database.logic.Proveedor();
                if (rev.SeleccionarRevistaPorGenero(IdEntity) == 0)
                {
                    lProveedor.Delete(IdEntity);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se borró el género correctamente');document.location.href='/Admin/ListadoGenero.aspx';", true);
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('No se puede eliminar el género, porque está asociado a un producto');", true);
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Update();  
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoProveedor.aspx");
        }


        protected void lstProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarLocalidades();
        }
    }
}