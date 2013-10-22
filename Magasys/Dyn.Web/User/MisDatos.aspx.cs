using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dyn.Web.User
{
    public partial class MisDatos : System.Web.UI.Page
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
            //btnEliminar.Attributes.Add("onclick", "return confirm_delete('Desea eliminar el Proveedor?');");
            if (!IsPostBack)
            {
                // this.Master.TituloPagina = "Edici&oacute;n Cliente";
                lCliente = new Dyn.Database.logic.Cliente();
                LlenarTipoDocumento();
                LlenarProvincias();
                // labProvincias.SelectedIndex = 1;
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
                        labProvincias.Text = localidad.IdProvincia.ToString();
                        LlenarLocalidades();
                        labLocalidades.Text = Entity.IdLocalidad.ToString();
                    }
                DataBind();
            }
        }

        public Dyn.Database.entities.Cliente CargarDatosCliente()
        {
            Entity = new Dyn.Database.entities.Cliente();

            // Entity.NroCliente = Convert.ToInt32(txtNroCliente.Text.Trim());

            Entity.TipoDocumento.IdTipoDocumento = Convert.ToInt32(labTipoDoc.Text.Trim());
            Entity.NroDocumento = Convert.ToInt32(labNroDocumento.Text.Trim());

            Entity.Nombre = labNombre.Text.Trim();
            Entity.Apellido = labApellido.Text.Trim();
            Entity.Alias = labAlias.Text.Trim();

            if (labTelefono.Text == "")
            { Entity.Telefono = null; }
            else
            { Entity.Telefono = labTelefono.Text.Trim(); }

            if (labCelular.Text == "")
            { Entity.Celular = null; }
            else
            { Entity.Celular = labCelular.Text.Trim(); }

            Entity.Email = labEMail.Text.Trim();

            Entity.DomicilioBarrio = labBarrio.Text.Trim();
            Entity.DomicilioCalle = labCalle.Text.Trim();
            if (labNumero.Text == "")
            { Entity.DomicilioNro = null; }
            else
            { Entity.DomicilioNro = Convert.ToInt16(labNumero.Text); }
            Entity.DomicilioPiso = labPiso.Text.Trim();
            Entity.DomicilioDpto = labDpto.Text.Trim();
            Entity.IdLocalidad = Convert.ToInt16(labLocalidades.Text.Trim());
            Entity.DomicilioCodPostal = labCodPostal.Text.Trim();

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

        //protected void btnGuardar_Click(object sender, EventArgs e)
        //{
        //    Update();
        //}
        //protected void btnEliminar_Click(object sender, EventArgs e)
        //{
        //    if (IdEntity != 0 && IdEntity != int.MinValue)
        //    {
        //        Entity = CargarDatosCliente();
        //        if (Entity.validarBaja())
        //        {
        //            Entity = CargarDatosCliente();
        //            Entity.NroCliente = IdEntity;
        //            lCliente = new Dyn.Database.logic.Cliente();
        //            Dyn.Database.logic.Estado lEstado = new Dyn.Database.logic.Estado();
        //            int estado = lEstado.BuscarEstado("Clientes", "Baja");
        //            Entity.Estado.IdEstado = estado;
        //            Entity.FechaAlta = DateTime.Now;
        //            lCliente.Delete(Entity);
        //            ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se borró el Cliente correctamente');", true);
        //            Response.Redirect("ListadoClientes.aspx?IdMenuCategoria=14");
        //        }
        //        else
        //        {
        //            // no se puede borrar, existen ventas o reservas para el cliente
        //        }

        //    }
        //}
        //protected void btnCancelar_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("ListadoClientes.aspx?IdMenuCategoria=14");
        //}

        public void LlenarProvincias()
        {
            Dyn.Database.logic.Provincia lProvincia = new Dyn.Database.logic.Provincia();
            List<Dyn.Database.entities.Provincia> listaProvincias = lProvincia.SeleccionarTodasLasProvicias();
            ListItem li;
            for (int i = 0; i < listaProvincias.Count; i++)
            {
                li = new ListItem();
                li = new ListItem(listaProvincias[i].Nombre, listaProvincias[i].IdProvincia.ToString());
                //labProvincias.Items.Add(li);
            }
        }
        public void LlenarLocalidades()
        {
            //if (labProvincias.SelectedIndex == -1)
            //{ }
            //else
            //{
            //    int idProvincia = Convert.ToInt16(labProvincias.SelectedItem.Value.ToString());
            //    Dyn.Database.logic.Localidad lLocalidad = new Dyn.Database.logic.Localidad();
            //    List<Dyn.Database.entities.Localidad> listaLocalidades = lLocalidad.SeleccionarLocalidadesPorProvincia(idProvincia);
            //    ListItem li;
            //    labLocalidades.Items.Clear();

            //    for (int i = 0; i < listaLocalidades.Count; i++)
            //    {
            //        li = new ListItem();
            //        li = new ListItem(listaLocalidades[i].Nombre, listaLocalidades[i].IdLocalidad.ToString());
            //        labLocalidades.Items.Add(li);
            //    }

            //}

        }
        public void LlenarTipoDocumento()
        {
            //Dyn.Database.logic.TipoDocumento lTipoDoc = new Dyn.Database.logic.TipoDocumento();
            //List<Dyn.Database.entities.TipoDocumento> listaTipoDoc = lTipoDoc.SeleccionarTodosLosTiposDocumento();
            //ListItem li;
            //labTipoDoc.Items.Clear();

            //for (int i = 0; i < listaTipoDoc.Count; i++)
            //{
            //    li = new ListItem();
            //    li = new ListItem(listaTipoDoc[i].Nombre, listaTipoDoc[i].IdTipoDocumento.ToString());
            //    labTipoDoc.Items.Add(li);
            //}



        }
        protected void lstProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarLocalidades();
        }
    }
}