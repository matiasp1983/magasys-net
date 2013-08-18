using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dyn.Database.logic;
using Dyn.Database.entities;

namespace Dyn.Web.Admin
{
    public partial class Pelicula : System.Web.UI.Page
    {
        private Dyn.Database.logic.Pelicula lPelicula;
        public Dyn.Database.entities.Pelicula Entity;

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
                this.Master.TituloPagina = "Edici&oacute;n Pel&iacute;cula";
                lPelicula = new Dyn.Database.logic.Pelicula();
                LlenarProveedor();
                LlenarGeneros();
                LLenarAnio();
                if (Request["Id"] == null)
                {
                    IdEntity = 0;
                    Entity = new Dyn.Database.entities.Pelicula();
                }
                else
                    if (Request["Id"] != null)
                    {
                        IdEntity = Convert.ToInt32(Request["Id"]);
                        Entity = lPelicula.BuscarProducto(IdEntity);
                        ddlProveedor.SelectedValue = Entity.IdProveedor.ToString();
                        ddlGenero.SelectedValue = Entity.IdGenero.ToString();
                        ddlAnio.SelectedValue = Entity.Anio.ToString();
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
            for (int i = 1970; i < DateTime.Now.Year +1; i++)
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
                lPelicula = new Dyn.Database.logic.Pelicula();
                if (pro.VerificaRelacionProducto(IdEntity) == 0)
                {
                    lPelicula.Delete(IdEntity);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se borró la película correctamente');document.location.href='/Admin/ListadoRevista.aspx?IdMenuCategoria=3';", true);
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('No se puede eliminar la película, porque está asociado a una transacción');", true);
                }
            }
        }

        public void Update()
        {
            lPelicula = new Dyn.Database.logic.Pelicula();
            Entity = new Dyn.Database.entities.Pelicula();
            if (IdEntity == 0)
            {
                Entity = CargarDatosPelicula();
                lPelicula.Insert(Entity);
                ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se guardaron los datos correctamente');location.href('/Admin/ListadoUsuario.aspx');", true);
            }
            else
                if (IdEntity > 0)
                {
                    Entity = CargarDatosPelicula();
                    Entity.IdPelicula = IdEntity;
                    lPelicula.Update(Entity);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se actualizaron los datos correctamente');", true);
                }
        }

        public Dyn.Database.entities.Pelicula CargarDatosPelicula()
        {
            Entity = new Dyn.Database.entities.Pelicula();
            Entity.Fechacreacion = DateTime.Now;
            Entity.Nombre = txtNombre.Text.Trim();
            Entity.Descripcion = txtDescripcion.Text.Trim();
            Entity.IdProveedor = int.Parse(ddlProveedor.SelectedValue);
            Entity.IdGenero = int.Parse(ddlGenero.SelectedValue);
            Entity.Precio = Convert.ToDouble(txtPrecio.Text.Trim());
            Entity.Anio = Convert.ToInt16(ddlAnio.SelectedValue);
            return Entity;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Update();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoPelicula.aspx?IdMenuCategoria=3");
        }
    }
}