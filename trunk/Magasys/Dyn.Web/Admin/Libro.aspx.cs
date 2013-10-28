﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dyn.Database.logic;
using Dyn.Database.entities;

namespace Dyn.Web.Admin
{
    public partial class Libro : System.Web.UI.Page
    {
        private Dyn.Database.logic.Libro lLibro;
        public Dyn.Database.entities.Libro Entity;

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
            if (!IsPostBack)
            {
                this.Master.TituloPagina = "Edici&oacute;n Libro";
                lLibro = new Dyn.Database.logic.Libro();
                LlenarProveedor();
                LlenarGeneros();
                LLenarAnio();
                if (Request["Id"] == null)
                {
                    IdEntity = 0;
                    Entity = new Dyn.Database.entities.Libro();
                    btnEliminar.Visible = false;
                    btnModificar.Visible = false;
                }
                else
                    if (Request["Id"] != null)
                    {
                        IdEntity = Convert.ToInt32(Request["Id"]);
                        Entity = lLibro.BuscarProducto(IdEntity);
                        ddlProveedor.SelectedValue = Entity.IdProveedor.ToString();
                        ddlGenero.SelectedValue = Entity.IdGenero.ToString();
                        ddlAnio.SelectedValue = Entity.Anio.ToString();
                        btnEliminar.Visible = true;
                        txtDescripcion.Enabled = false;
                        txtNombre.Enabled = false;
                        txtAutor.Enabled = false;
                        txtPrecio.Enabled = false;
                        btnGuardar.Enabled = false;
                        btnModificar.Visible = true;
                        ddlAnio.Enabled = false;
                        ddlGenero.Enabled = false;
                        ddlProveedor.Enabled = false;
                    }
                DataBind();
            }
        }

        public void LlenarGeneros()
        {
            Dyn.Database.logic.Genero lGenero = new Dyn.Database.logic.Genero();
            List<Dyn.Database.entities.Genero> listageneros = lGenero.SeleccionarTodosLosGeneros();
            ListItem li;
            for (int i = 0; i < listageneros.Count; i++)
            {
                li = new ListItem();
                li = new ListItem(listageneros[i].Nombre, listageneros[i].IdGenero.ToString());
                ddlGenero.Items.Add(li);
            }
        }

        public void LlenarProveedor()
        {
            Dyn.Database.logic.Proveedor lProveedor = new Dyn.Database.logic.Proveedor();
            List<Dyn.Database.entities.Proveedor> listaproveedor = lProveedor.SeleccionarTodosLosProveedores();
            ListItem li;
            for (int i = 0; i < listaproveedor.Count; i++)
            {
                li = new ListItem();
                li = new ListItem(listaproveedor[i].Nombre, listaproveedor[i].IdProveedor.ToString());
                ddlProveedor.Items.Add(li);
            }
        }

        public void LLenarAnio()
        {
            ListItem li;
            li = new ListItem();
            li = new ListItem("Seleccione...", "0");
            for (int i = 1970; i < DateTime.Now.Year + 1; i++)
            {
                ddlAnio.Items.Add(i.ToString());
            }
            ddlAnio.SelectedValue = DateTime.Now.Year.ToString();
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Dyn.Database.logic.Producto pro = new Dyn.Database.logic.Producto();
            if (IdEntity != 0 && IdEntity != int.MinValue)
            {
                lLibro = new Dyn.Database.logic.Libro();
                if (pro.VerificaRelacionProducto(IdEntity) == 0)
                {
                    lLibro.Delete(IdEntity);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se borró el libro correctamente');document.location.href='/Admin/ListadoLibro.aspx?IdMenuCategoria=10';", true);
                    Response.Redirect("ListadoLibro.aspx?IdMenuCategoria=10");
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('No se puede eliminar el libro, porque está asociado a una transacción');", true);
                }
            }
            LimpiarCampos();
        }

        public void Update()
        {
            lLibro = new Dyn.Database.logic.Libro();
            Entity = new Dyn.Database.entities.Libro();
            if (IdEntity == 0)
            {
                Entity = CargarDatosLibro();
                lLibro.Insert(Entity);
                ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se guardaron los datos correctamente');location.href('/Admin/ListadoUsuario.aspx');", true);
            }
            else
                if (IdEntity > 0)
                {
                    Entity = CargarDatosLibro();
                    Entity.IdLibro = IdEntity;
                    lLibro.Update(Entity);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se actualizaron los datos correctamente');", true);
                    Response.Redirect("ListadoLibro.aspx?IdMenuCategoria=10");
                }
        }

        public Dyn.Database.entities.Libro CargarDatosLibro()
        {
            Entity = new Dyn.Database.entities.Libro();
            Entity.Fechacreacion = DateTime.Now;
            Entity.Nombre = txtNombre.Text.Trim();
            Entity.Descripcion = txtDescripcion.Text.Trim();
            Entity.IdProveedor = int.Parse(ddlProveedor.SelectedValue);
            Entity.IdGenero = int.Parse(ddlGenero.SelectedValue);
            Entity.Precio = Convert.ToDouble(txtPrecio.Text.Trim());
            Entity.Autor = Convert.ToString(txtAutor.Text.Trim());
            Entity.Anio = Convert.ToInt16(ddlAnio.SelectedValue);
            return Entity;
        }

        public void LimpiarCampos()
        {
            txtAutor.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtPrecio.Text = string.Empty;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Update();
            LimpiarCampos();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeAdmin.aspx");
            //Response.Redirect("ListadoLibro.aspx?IdMenuCategoria=10");
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            txtDescripcion.Enabled = true;
            txtNombre.Enabled = true;
            txtAutor.Enabled = true;
            txtPrecio.Enabled = true;
            btnGuardar.Enabled = true;
            ddlAnio.Enabled = true;
            ddlGenero.Enabled = true;
            ddlProveedor.Enabled = true;
            btnModificar.Enabled = false;
        }
    }
}