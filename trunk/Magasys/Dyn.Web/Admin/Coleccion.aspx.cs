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
    public partial class Coleccion : System.Web.UI.Page
    {

        private Dyn.Database.logic.Coleccion lColeccion;
        public Dyn.Database.entities.Coleccion Entity;
        private Dyn.Database.logic.Producto lProducto;

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
            btnEliminar.Attributes.Add("onclick", "return confirm_delete('Desea eliminar el revista?');");
            if (!IsPostBack)
            {
                this.Master.TituloPagina = "Edici&oacute;n Revista";
                lColeccion = new Dyn.Database.logic.Coleccion();
                lProducto = new Dyn.Database.logic.Producto();
                LlenarGeneros();
                LlenarProveedor();
                LlenarPeriodicidad();
                if (Request["Id"] == null)
                {
                    IdEntity = 0;
                    Entity = new Dyn.Database.entities.Coleccion();
                }
                else
                    if (Request["Id"] != null)
                    {
                        IdEntity = Convert.ToInt32(Request["Id"]);
                        Entity = lColeccion.Load(IdEntity);
                        lstGenero.SelectedValue = Entity.IdGenero.ToString();
                        lstPeriodicidad.SelectedValue = Entity.IdPeriodicidad.ToString();
                        lstProveedor.SelectedValue = Entity.IdProveedor.ToString();

                        
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
                lstGenero.Items.Add(li);
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
                li = new ListItem(listaproveedor[i].RazonSocial, listaproveedor[i].IdProveedor.ToString());
                lstProveedor.Items.Add(li);
            }
        }

        public void LlenarPeriodicidad()
        {
            Dyn.Database.logic.Periodicidad lPeriodicidad = new Dyn.Database.logic.Periodicidad();
            List<Dyn.Database.entities.Periodicidad> listaperiodicidad = lPeriodicidad.SeleccionarTodasLasPeriodicidades();
            ListItem li;
            for (int i = 0; i < listaperiodicidad.Count; i++)
            {
                li = new ListItem();
                li = new ListItem(listaperiodicidad[i].Nombre, listaperiodicidad[i].IdPeriodicidad.ToString());
                lstPeriodicidad.Items.Add(li);
            }
        }
        public void Update()
        {
            lColeccion = new Dyn.Database.logic.Coleccion();
            lProducto = new Dyn.Database.logic.Producto();
            Entity = new Dyn.Database.entities.Coleccion();



            if (IdEntity == 0)
            {

                String nombre = txtNombre.Text.Trim();
                Entity = CargarDatosColeccion();

                if (lProducto.existeNombre(nombre))
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Ya existe un producto con ese nombre');location.href('/Admin/ListadoUsuario.aspx');", true);
                }
                else
                {
                    Entity.IdColeccion = Convert.ToInt16(lProducto.Insert(Entity));
                    lColeccion.Insert(Entity);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se guardaron los datos correctamente');location.href('/Admin/ListadoUsuario.aspx');", true);
                    // Response.Redirect("ListadoColeccion.aspx");
                }

            }
            else
                if (IdEntity > 0)
                {
                    Entity = CargarDatosColeccion();
                    //if (lProveedor.existeCuit(idProveedor))
                    //{
                    //    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Ya existe un proveedor con ese CUIT');location.href('/Admin/ListadoUsuario.aspx');", true);
                    //}
                    //else
                    //{
                    //    lProveedor.Insert(Entity);
                    //    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se guardaron los datos correctamente');location.href('/Admin/ListadoUsuario.aspx');", true);
                    //}
                    Entity.IdProducto = IdEntity;
                    lColeccion.Update(Entity);
                    lProducto.Update(Entity);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se actualizaron los datos correctamente');", true);
                }
        }
        public Dyn.Database.entities.Coleccion CargarDatosColeccion()
        {
            Entity = new Dyn.Database.entities.Coleccion();
            Entity.Nombre = txtNombre.Text.Trim();
            Entity.Descripcion = txtDescripcion.Text.Trim();
            Entity.IdProveedor = Convert.ToInt16(lstProveedor.SelectedValue.ToString());
            Entity.Fechacreacion = DateTime.Now;

            Entity.IdPeriodicidad = Convert.ToInt16(lstPeriodicidad.SelectedValue.ToString());
            Entity.IdGenero = Convert.ToInt16(lstGenero.SelectedValue.ToString());
            Entity.Precio = Convert.ToDouble(txtPrecio.Text.Trim());
            Entity.CantidadEntregas = Convert.ToInt16(txtCantidad.Text.Trim());

            return Entity;
            

        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Dyn.Database.logic.Revista rev = new Dyn.Database.logic.Revista();
            if (IdEntity != 0 && IdEntity != int.MinValue)
            {
                lColeccion = new Dyn.Database.logic.Coleccion();
                if (rev.SeleccionarRevistaPorGenero(IdEntity) == 0)
                {
                    lColeccion.Delete(IdEntity);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se borró la revista correctamente');document.location.href='/Admin/ListadoGenero.aspx';", true);
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('No se puede eliminar la revista, porque está asociado a una transacción');", true);
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Update();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoColeccion.aspx");
        }

    }
}