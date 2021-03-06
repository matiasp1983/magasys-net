﻿using System;
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
                    btnEliminar.Visible = false;
                    btnModificar.Visible = false;
                }
                else
                    if (Request["Id"] != null)
                    {
                        IdEntity = Convert.ToInt32(Request["Id"]);
                        Entity = lProveedor.Load(IdEntity);
                        lstLocalidades.SelectedValue = Entity.IdLocalidad.ToString();
                        txtCalle.Enabled = false;
                        txtDpto.Enabled = false;
                        txtEMail.Enabled = false;
                        txtNumero.Enabled = false;
                        txtPiso.Enabled = false;
                        txtTelefono.Enabled = false;
                        txtCuit.Enabled = false;
                        txtDetalle.Enabled = false;
                        txtRazonSocial.Enabled = false;
                        txtResponsableApellido.Enabled = false;
                        txtResponsableEmail.Enabled = false;
                        txtResponsableNombre.Enabled = false;
                        lstLocalidades.Enabled = false;
                        lstProvincias.Enabled = false;
                        btnEliminar.Visible = true;
                        btnModificar.Visible = true;
                        btnGuardar.Enabled = false;
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
            Entity.DomicilioDpto = txtDpto.Text.Trim();
            Entity.IdLocalidad = Convert.ToInt16(lstLocalidades.SelectedValue.ToString());
            Entity.ResponsableApellido = txtResponsableApellido.Text.Trim();
            Entity.ResponsableNombre = txtResponsableNombre.Text.Trim();
            Entity.ResponsableEmail = txtResponsableEmail.Text.Trim();
            Entity.Nombre = txtRazonSocial.Text.Trim();
            return Entity;
            
        }

        public void LimpiarCampos()
        {
            txtCalle.Text = string.Empty;
            txtCuit.Text = string.Empty;
            txtDetalle.Text = string.Empty;
            txtDpto.Text = string.Empty;
            txtEMail.Text = string.Empty;
            txtNumero.Text = string.Empty;
            txtPiso.Text = string.Empty;
            txtRazonSocial.Text = string.Empty;
            txtResponsableApellido.Text = string.Empty;
            txtResponsableEmail.Text = string.Empty;
            txtResponsableNombre.Text = string.Empty;
            txtTelefono.Text = string.Empty;
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
                    //String idProveedor = txtCuit.Text;
                    Entity = CargarDatosProveedor();
                    //if (lProveedor.existeCuit(idProveedor))
                    //{
                    //    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Ya existe un proveedor con ese CUIT');location.href('/Admin/ListadoUsuario.aspx');", true);
                    //}
                    //else
                    //{
                    //    lProveedor.Insert(Entity);
                    //    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se guardaron los datos correctamente');location.href('/Admin/ListadoUsuario.aspx');", true);
                    //}
                    Entity.IdProveedor = IdEntity;
                    lProveedor.Update(Entity);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se actualizaron los datos correctamente');", true);
                    Response.Redirect("ListadoProveedor.aspx?IdMenuCategoria=25");
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
                    li = new ListItem(listaLocalidades[i].Nombre, listaLocalidades[i].IdLocalidad.ToString());
                    lstLocalidades.Items.Add(li);
                }
            
            }

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Dyn.Database.logic.Genero gen = new Dyn.Database.logic.Genero();
            if (IdEntity != 0 && IdEntity != int.MinValue)
            {
                lProveedor = new Dyn.Database.logic.Proveedor();
                if (gen.VerificaRelacionGenero(IdEntity) == 0)
                {
                    lProveedor.Delete(IdEntity);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se borró el proveedor correctamente');document.location.href='/Admin/ListadoProveedor.aspx?IdMenuCategoria=25';", true);
                    Response.Redirect("ListadoProveedor.aspx?IdMenuCategoria=25");
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('No se puede eliminar el proveedor, porque está asociado a un producto');", true);
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Update();
            LimpiarCampos();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeAdmin.aspx");
            //Response.Redirect("ListadoProveedor.aspx?IdMenuCategoria=25");
        }


        protected void lstProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarLocalidades();
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            txtCalle.Enabled = true;
            txtDpto.Enabled = true;
            txtEMail.Enabled = true;
            txtNumero.Enabled = true;
            txtPiso.Enabled = true;
            txtTelefono.Enabled = true;
            txtCuit.Enabled = true;
            txtDetalle.Enabled = true;
            txtRazonSocial.Enabled = true;
            txtResponsableApellido.Enabled = true;
            txtResponsableEmail.Enabled = true;
            txtResponsableNombre.Enabled = true;
            lstLocalidades.Enabled = true;
            lstProvincias.Enabled = true;
            btnModificar.Enabled = false;
            btnGuardar.Enabled = true;
        }

        protected void txtDetalle_TextChanged(object sender, EventArgs e)
        {

        }
    }
}