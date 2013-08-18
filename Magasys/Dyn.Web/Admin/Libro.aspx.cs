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
        private Dyn.Database.logic.Producto lProducto;
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
                this.Master.TituloPagina = "Edici&oacute;n Revista";
                lLibro = new Dyn.Database.logic.Libro();
                LlenarProveedor();
                LlenarGeneros();
                if (Request["Id"] == null)
                {
                    IdEntity = 0;
                    Entity = new Dyn.Database.entities.Libro();
                }
                else
                    if (Request["Id"] != null)
                    {
                        IdEntity = Convert.ToInt32(Request["Id"]);
                        Entity = lLibro.BuscarProducto(IdEntity);
                        ddlProveedor.SelectedValue = Entity.IdProveedor.ToString();
                        ddlGenero.SelectedValue = Entity.IdGenero.ToString();
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

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Dyn.Database.logic.Producto pro = new Dyn.Database.logic.Producto();
            if (IdEntity != 0 && IdEntity != int.MinValue)
            {
                lLibro = new Dyn.Database.logic.Libro();
                if (pro.VerificaRelacionProducto(IdEntity) == 0)
                {
                    lLibro.Delete(IdEntity);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se borró el libro correctamente');document.location.href='/Admin/ListadoLibro.aspx?IdMenuCategoria=3';", true);
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('No se puede eliminar el libro, porque está asociado a una transacción');", true);
                }
            }
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
            Entity.Anio = Convert.ToInt16(txtAnio.Text.Trim());
            return Entity;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Update();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoLibro.aspx?IdMenuCategoria=10");
        }
    }
}