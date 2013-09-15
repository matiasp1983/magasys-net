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
                lstProvincias.SelectedIndex = 0;
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
            //Entity.Cuit = txtCuit.Text.Trim();
            //Entity.RazonSocial = txtRazonSocial.Text.Trim();
            //Entity.Email =  txtEMail.Text.Trim();
            //Entity.Detalle = txtDetalle.Text.Trim();
            //Entity.Telefono = txtTelefono.Text.Trim();
            //Entity.DomicilioCalle = txtCalle.Text.Trim();
            //if (txtNumero.Text == "")
            //{   Entity.DomicilioNro = null;}
            //else
            //{   Entity.DomicilioNro = Convert.ToInt16(txtNumero.Text);}
            
            //Entity.DomicilioPiso = txtPiso.Text.Trim();
            //Entity.DomicilioDpto = txtDpto.Text.Trim();
            //Entity.IdLocalidad = Convert.ToInt16(lstLocalidades.SelectedValue.ToString());
            //Entity.ResponsableApellido = txtResponsableApellido.Text.Trim();
            //Entity.ResponsableNombre = txtResponsableNombre.Text.Trim();
            //Entity.ResponsableEmail = txtResponsableEmail.Text.Trim();
            //Entity.Nombre = txtRazonSocial.Text.Trim();
            return Entity;
        }
        public void Update()
        {
            lCliente = new Dyn.Database.logic.Cliente();
            Entity = new Dyn.Database.entities.Cliente();



            if (IdEntity == 0)
            {

                // String idProveedor = txtCuit.Text;
                Entity = CargarDatosCliente();

                //if (lProveedor.existeCuit(idCliente))
                //{
                //    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Ya existe un proveedor con ese CUIT');location.href('/Admin/ListadoUsuario.aspx');", true);
                //}
                //else
                //{
                //    lProveedor.Insert(Entity);
                //    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se guardaron los datos correctamente');location.href('/Admin/ListadoUsuario.aspx');", true);
                //}

            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Update();
        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Dyn.Database.logic.Genero gen = new Dyn.Database.logic.Genero();
            if (IdEntity != 0 && IdEntity != int.MinValue)
            {
                lCliente = new Dyn.Database.logic.Cliente();
                if (gen.VerificaRelacionGenero(IdEntity) == 0)
                {
                    lCliente.Delete(IdEntity);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se borró el género correctamente');document.location.href='/Admin/ListadoProveedor.aspx';", true);
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('No se puede eliminar el género, porque está asociado a un producto');", true);
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