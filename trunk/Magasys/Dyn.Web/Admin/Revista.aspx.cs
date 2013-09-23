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
    public partial class Revista : System.Web.UI.Page
    {
        private Dyn.Database.logic.Revista lRevista;
        //private Dyn.Database.logic.Producto lProducto;
        public Dyn.Database.entities.Revista Entity;

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
                lRevista = new Dyn.Database.logic.Revista();
                LlenarProveedor();
                LlenarPeriodicidad();
                LlenarGeneros();
                if (Request["Id"] == null)
                {
                    IdEntity = 0;
                    Entity = new Dyn.Database.entities.Revista();
                }
                else
                    if (Request["Id"] != null)
                    {
                        IdEntity = Convert.ToInt32(Request["Id"]);
                        Entity = lRevista.BuscarProducto(IdEntity);
                        lstProveedor.SelectedValue = Entity.IdProveedor.ToString();
                        lstPeriodicidad.SelectedValue = Entity.IdPeriodicidad.ToString();
                        lstGenero.SelectedValue = Entity.IdGenero.ToString();
                        lstDiaSemana.SelectedValue = Entity.DiaSemana.ToString().Trim();
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
                li = new ListItem(listaproveedor[i].Nombre, listaproveedor[i].IdProveedor.ToString());
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

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Dyn.Database.logic.Producto pro = new Dyn.Database.logic.Producto();
            if (IdEntity != 0 && IdEntity != int.MinValue)
            {
                lRevista = new Dyn.Database.logic.Revista();
                if (pro.VerificaRelacionProducto(IdEntity) == 0)
                {
                    lRevista.Delete(IdEntity);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se borró la revista correctamente');document.location.href='/Admin/ListadoRevista.aspx?IdMenuCategoria=3';", true);
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('No se puede eliminar la revista, porque está asociado a una transacción');", true);
                }
            }
        }

        public void Update()
        {
            lRevista = new Dyn.Database.logic.Revista();
            Entity = new Dyn.Database.entities.Revista();
            if (IdEntity == 0)
            {
                Entity = CargarDatosRevista();
                lRevista.Insert(Entity);
                ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se guardaron los datos correctamente');location.href('/Admin/ListadoUsuario.aspx');", true);
            }
            else
                if (IdEntity > 0)
                {
                    Entity = CargarDatosRevista();
                    Entity.IdRevista = IdEntity;
                    lRevista.Update(Entity);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se actualizaron los datos correctamente');", true);
                }
        }

        public Dyn.Database.entities.Revista CargarDatosRevista()
        {
            Entity = new Dyn.Database.entities.Revista();
            Entity.Fechacreacion = DateTime.Now;
            Entity.Nombre = txtNombre.Text.Trim();
            Entity.Descripcion = txtDescripcion.Text.Trim();
            Entity.IdProveedor = int.Parse(lstProveedor.SelectedValue);
            Entity.IdGenero = int.Parse(lstGenero.SelectedValue);
            Entity.IdPeriodicidad = int.Parse(lstPeriodicidad.SelectedValue);
            Entity.Precio = Convert.ToDouble(txtPrecio.Text.Trim());
            Entity.DiaSemana = lstDiaSemana.SelectedValue.ToString();
            return Entity;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Update();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoRevista.aspx?IdMenuCategoria=3");
        }
    }
}
