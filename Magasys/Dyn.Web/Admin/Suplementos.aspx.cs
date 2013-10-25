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
    public partial class Suplementos : System.Web.UI.Page
    {
        private Dyn.Database.logic.Suplemento lSuplemento;
        public Dyn.Database.entities.Suplemento Entity;
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
                this.Master.TituloPagina = "Edici&oacute;n Suplemento";
                lSuplemento = new Dyn.Database.logic.Suplemento();
                lProducto = new Dyn.Database.logic.Producto();
                LlenarGeneros();
                LlenarPeriodicidad();
                LlenarProductos();
                LlenarDiaSemana();


                txtProveedor.Enabled = false;

                if (Request["Id"] == null)
                {
                    IdEntity = 0;
                    Entity = new Dyn.Database.entities.Suplemento();
                    btnEliminar.Visible = false;
                    btnModificar.Visible = false;
                }
                else
                    if (Request["Id"] != null)
                    {
                        IdEntity = Convert.ToInt32(Request["Id"]);
                        Entity = lSuplemento.Load(IdEntity);
                        lstGenero.SelectedValue = Entity.IdGenero.ToString();
                        lstPeriodicidad.SelectedValue = Entity.IdPeriodicidad.ToString();
                        LlenarProveedor(Convert.ToInt32(Entity.IdProveedor));
                        lstDiario.SelectedValue = Entity.IdDiario.ToString();
                        btnEliminar.Visible = true;
                        txtDescripcion.Enabled = false;
                        txtNombre.Enabled = false;
                        txtPrecio.Enabled = false;
                        txtProveedor.Enabled = false;
                        lstDiaSemana.Enabled = false;
                        lstGenero.Enabled = false;
                        lstPeriodicidad.Enabled = false;
                        lstDiario.Enabled = false;
                        btnGuardar.Enabled = false;
                        btnModificar.Visible = true;
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
        public void LlenarProveedor(int idProveedor)
        {
            Dyn.Database.logic.Proveedor lProveedor = new Dyn.Database.logic.Proveedor();
            Dyn.Database.entities.Proveedor prov = lProveedor.Load(idProveedor);
            txtProveedor.Text = prov.RazonSocial;
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
        public void LlenarProductos()
        {
            Dyn.Database.logic.Producto lProducto = new Dyn.Database.logic.Producto();
            List<Dyn.Database.entities.Producto> listaProductos = lProducto.SeleccionarTodosLosProductos(0);
            ListItem li;
            for (int i = 0; i < listaProductos.Count; i++)
            {
                li = new ListItem();
                li = new ListItem(listaProductos[i].Nombre, listaProductos[i].IdProducto.ToString());
                lstDiario.Items.Add(li);
            }
        }
        public void LlenarDiaSemana()
        {
            ListItem li;
            li = new ListItem();
            li = new ListItem("Lunes     ", "0");
            lstDiaSemana.Items.Add(li);
            li = new ListItem();
            li = new ListItem("Martes    ", "1");
            lstDiaSemana.Items.Add(li);
            li = new ListItem();
            li = new ListItem("Miercoles ", "2");
            lstDiaSemana.Items.Add(li);
            li = new ListItem();
            li = new ListItem("Jueves    ", "3");
            lstDiaSemana.Items.Add(li);
            li = new ListItem();
            li = new ListItem("Viernes   ", "4");
            lstDiaSemana.Items.Add(li);
            li = new ListItem();
            li = new ListItem("Sabado    ", "5");
            lstDiaSemana.Items.Add(li);
            li = new ListItem();
            li = new ListItem("Domingo   ", "6");
            lstDiaSemana.Items.Add(li);

        }

        public void Update()
        {
            lSuplemento = new Dyn.Database.logic.Suplemento();
            lProducto = new Dyn.Database.logic.Producto();
            Entity = new Dyn.Database.entities.Suplemento();



            if (IdEntity == 0)
            {
                LlenarProveedor(Convert.ToInt32(Entity.IdProveedor));
                String nombre = String.Concat(txtNombre.Text.Trim() + " - " + lstDiario.SelectedItem.ToString());
                Entity = CargarDatosSuplemento(nombre);


                if (lProducto.existeNombre(nombre))
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Ya existe un producto con ese nombre');location.href('/Admin/ListadoUsuario.aspx');", true);
                }
                else
                {
                    Entity.IdSuplemento = Convert.ToInt16(lProducto.Insert(Entity));
                    lSuplemento.Insert(Entity);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se guardaron los datos correctamente');location.href('/Admin/ListadoUsuario.aspx');", true);
                    Response.Redirect("ListadoSuplemento.aspx?IdMenuCategoria=3");
                }

            }
            else
                if (IdEntity > 0)
                {
                    String nombre = String.Concat(txtNombre.Text.Trim() + " - " + lstDiario.SelectedItem.ToString());
                    Entity = CargarDatosSuplemento(nombre);
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
                    lSuplemento.Update(Entity);
                    lProducto.Update(Entity);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se actualizaron los datos correctamente');", true);
                }
        }
        public Dyn.Database.entities.Suplemento CargarDatosSuplemento(String nombre)
        {
            Entity = new Dyn.Database.entities.Suplemento();

            Entity.Nombre = nombre;
            Entity.Descripcion = txtDescripcion.Text.Trim();
            // Entity.IdProveedor = Convert.ToInt16(lstProveedor.SelectedValue.ToString());
            Entity.Fechacreacion = DateTime.Now;
            Entity.DiaSemana = lstDiaSemana.SelectedItem.ToString();
            Entity.IdDiario = Convert.ToInt16(lstDiario.SelectedValue.ToString());
            Entity.IdPeriodicidad = Convert.ToInt16(lstPeriodicidad.SelectedValue.ToString());
            Entity.IdGenero = Convert.ToInt16(lstGenero.SelectedValue.ToString());
            Entity.Precio = Convert.ToDouble(txtPrecio.Text.Trim());

            return Entity;


        }
        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Dyn.Database.logic.Suplemento suplemento = new Dyn.Database.logic.Suplemento();
            if (IdEntity != 0 && IdEntity != int.MinValue)
            {
                lSuplemento = new Dyn.Database.logic.Suplemento();
                if (suplemento.validarVentas(IdEntity))
                {
                    lSuplemento.Delete(IdEntity);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se borró el género correctamente');document.location.href='/Admin/ListadoUsuario.aspx';", true);
                    Response.Redirect("ListadoSuplemento.aspx?IdMenuCategoria=3");
                }
                else
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('No se puede eliminar la coleccion, porque está asociado a una venta o reserva');", true);
                }
            }
            LimpiarCampos();
        }

        public void LimpiarCampos()
        {
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
            //Response.Redirect("ListadoSuplemento.aspx?IdMenuCategoria=3");
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            txtDescripcion.Enabled = true;
            txtNombre.Enabled = true;
            txtPrecio.Enabled = true;
            txtProveedor.Enabled = true;
            lstDiaSemana.Enabled = true;
            lstGenero.Enabled = true;
            lstPeriodicidad.Enabled = true;
            lstDiario.Enabled = true;
            btnGuardar.Enabled = true;
            btnModificar.Enabled = false;
        }

    }
}