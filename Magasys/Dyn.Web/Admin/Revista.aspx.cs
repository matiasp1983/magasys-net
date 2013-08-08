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
            btnEliminar.Attributes.Add("onclick", "return confirm_delete('Desea eliminar el revista?');");
            if (!IsPostBack)
            {
                this.Master.TituloPagina = "Edici&oacute;n Revista";
                lRevista = new Dyn.Database.logic.Revista();
                LlenarGeneros();
                LlenarProveedor();
                LlenarPeriodicidad();
                if (Request["Id"] == null)
                {
                    IdEntity = 0;
                    Entity = new Dyn.Database.entities.Revista();
                }
                else
                    if (Request["Id"] != null)
                    {
                        IdEntity = Convert.ToInt32(Request["Id"]);
                        //Entity = lRevista.Load(IdEntity);
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
            Dyn.Database.logic.Revista rev = new Dyn.Database.logic.Revista();
            if (IdEntity != 0 && IdEntity != int.MinValue)
            {
                lRevista = new Dyn.Database.logic.Revista();
                if (rev.SeleccionarRevistaPorGenero(IdEntity) == 0)
                {
                    lRevista.Delete(IdEntity);
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
            //Update();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            //Response.Redirect("ListadoRevista.aspx");
        }
    }
}
