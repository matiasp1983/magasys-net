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
    public partial class Diario : System.Web.UI.Page
    {
        private Dyn.Database.logic.Diario lDiario;
        public Dyn.Database.entities.Diario Entity;
        public List<Dyn.Database.entities.DiarioPorDia> listaDias;
        private Dyn.Database.logic.Producto lProducto;
        private Dyn.Database.logic.DiarioPorDia lDiarioPorDia;

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
                this.Master.TituloPagina = "Edici&oacute;n Diario";
                lDiario = new Dyn.Database.logic.Diario();
                lProducto = new Dyn.Database.logic.Producto();
                lDiarioPorDia = new Dyn.Database.logic.DiarioPorDia();
                LlenarProveedor();
                if (Request["Id"] == null)
                {
                    IdEntity = 0;
                    Entity = new Dyn.Database.entities.Diario();

                }
                else
                    if (Request["Id"] != null)
                    {
                        IdEntity = Convert.ToInt32(Request["Id"]);
                        Entity = lDiario.Load(IdEntity);
                        LlenarDiarioPorDia();
                        lstProveedor.SelectedValue = Entity.IdProveedor.ToString();


                    }
                DataBind();
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

        public void LlenarDiarioPorDia()
        {
            Dyn.Database.logic.DiarioPorDia lDiarioPorDia = new Dyn.Database.logic.DiarioPorDia();
            List<Dyn.Database.entities.DiarioPorDia> listaDias = lDiarioPorDia.SeleccionarTodosLosDias(Entity);
            for (int i = 0; i < listaDias.Count; i++)
            {
                if (listaDias[i].DiaSemana == "Lunes     ")
                {
                    txtLunes.Text = listaDias[i].Precio.ToString();
                }
                else
                {
                    if (listaDias[i].DiaSemana == "Martes    ")
                    {
                    txtMartes.Text = listaDias[i].Precio.ToString();
                    }
                    else
                    {
                        if (listaDias[i].DiaSemana == "Miercoles ")
                        {
                        txtMiercoles.Text = listaDias[i].Precio.ToString();
                        }
                        else
                        {
                            if (listaDias[i].DiaSemana == "Jueves    ")
                            {
                            txtJueves.Text = listaDias[i].Precio.ToString();
                            }
                            else
                            {
                                if (listaDias[i].DiaSemana == "Viernes   ")
                                {
                                txtViernes.Text = listaDias[i].Precio.ToString();
                                }
                                else
                                {
                                    if (listaDias[i].DiaSemana == "Sabado    ")
                                    {
                                    txtSabado.Text = listaDias[i].Precio.ToString();
                                    }
                                    else
                                    {
                                        if (listaDias[i].DiaSemana == "Domingo   ")
                                        {
                                        txtDomingo.Text = listaDias[i].Precio.ToString();
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }
        }

        public void Update()
        {
            lDiario = new Dyn.Database.logic.Diario();
            lProducto = new Dyn.Database.logic.Producto();
            lDiarioPorDia = new Dyn.Database.logic.DiarioPorDia();
            Entity = new Dyn.Database.entities.Diario();



            if (IdEntity == 0)
            {

                String nombre = txtNombre.Text.Trim();
                Entity = CargarDatosDiario();
                listaDias = CargarListaDias(Entity);

                if (lProducto.existeNombre(nombre))
                {
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Ya existe un producto con ese nombre');location.href('/Admin/ListadoUsuario.aspx');", true);
                }
                else
                {
                    Entity.IdDiario = Convert.ToInt16(lProducto.Insert(Entity));
                    lDiario.Insert(Entity);

                    Dyn.Database.entities.DiarioPorDia dia;
                    if (listaDias != null)
                    {
                        for (int i = 0; i < listaDias.Count; i++)
                        {
                            dia = new Dyn.Database.entities.DiarioPorDia();
                            dia.IdDiario = Entity.IdDiario;
                            dia.DiaSemana = listaDias[i].DiaSemana;
                            dia.Precio = listaDias[i].Precio;
                            lDiarioPorDia.Insert(dia);
                        }
                    }

                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se guardaron los datos correctamente');location.href('/Admin/ListadoUsuario.aspx');", true);
                    Response.Redirect("ListadoDiario.aspx?IdMenuCategoria=3");
                }

            }
            else
                if (IdEntity > 0)
                {
                    Entity.IdProducto = IdEntity;
                    Entity = CargarDatosDiario();                   
                    listaDias = CargarListaDias(Entity);



                    lDiario.Update(Entity);
                    lProducto.Update(Entity);

                    if (listaDias != null)
                    {
                        for (int i = 0; i < listaDias.Count; i++)
                        {
                            lDiarioPorDia.Update(listaDias[i]);
                        }
                    }

                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se actualizaron los datos correctamente');", true);
                }
        }
        public Dyn.Database.entities.Diario CargarDatosDiario()
        {
            Entity = new Dyn.Database.entities.Diario();
            Entity.Nombre = txtNombre.Text.Trim();
            Entity.Descripcion = txtDescripcion.Text.Trim();
            Entity.IdProveedor = Convert.ToInt16(lstProveedor.SelectedValue.ToString());
            Entity.Fechacreacion = DateTime.Now;

            return Entity;
        

        }

        public List<Dyn.Database.entities.DiarioPorDia> CargarListaDias(Dyn.Database.entities.Diario objDiario)
        {   
            Double precio;
            Dyn.Database.entities.DiarioPorDia dia;
            List<Dyn.Database.entities.DiarioPorDia> Collection = new List<Dyn.Database.entities.DiarioPorDia>();
            if (txtLunes.Text != "")
            {
                precio = Convert.ToDouble(txtLunes.Text);
                dia = new Dyn.Database.entities.DiarioPorDia(Entity.IdDiario,"Lunes",precio);
                Collection.Add(dia);
            }
            if (txtMartes.Text != "")
            {
                precio = Convert.ToDouble(txtMartes.Text);
                dia = new Dyn.Database.entities.DiarioPorDia(Entity.IdDiario,"Martes",precio);
                Collection.Add(dia);
            }
            if (txtMiercoles.Text != "")
            {
                precio = Convert.ToDouble(txtMiercoles.Text);
                dia = new Dyn.Database.entities.DiarioPorDia(Entity.IdDiario, "Miercoles", precio);
                Collection.Add(dia);
            }
            if (txtJueves.Text != "")
            {
                precio = Convert.ToDouble(txtJueves.Text);
                dia = new Dyn.Database.entities.DiarioPorDia(Entity.IdDiario, "Jueves", precio);
                Collection.Add(dia);
            }
            if (txtViernes.Text != "")
            {
                precio = Convert.ToDouble(txtViernes.Text);
                dia = new Dyn.Database.entities.DiarioPorDia(Entity.IdDiario, "Viernes", precio);
                Collection.Add(dia);
            }
            if (txtSabado.Text != "")
            {
                precio = Convert.ToDouble(txtSabado.Text);
                dia = new Dyn.Database.entities.DiarioPorDia(Entity.IdDiario, "Sabado", precio);
                Collection.Add(dia);
            }
            if (txtDomingo.Text != "")
            {
                precio = Convert.ToDouble(txtDomingo.Text);
                dia = new Dyn.Database.entities.DiarioPorDia(Entity.IdDiario, "Domingo", precio);
                Collection.Add(dia);
            }
            if (Collection.Count == 0)
            {
                return null;
            }
            else
            {
                return Collection;
            }
            
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            Dyn.Database.logic.Diario diario = new Dyn.Database.logic.Diario();
            if (IdEntity != 0 && IdEntity != int.MinValue)
            {
                lDiario = new Dyn.Database.logic.Diario();
                if (diario.validarVentas(IdEntity))
                {
                    lDiario.Delete(IdEntity);
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "script", "alert('Se borró el género correctamente');document.location.href='/Admin/ListadoUsuario.aspx';", true);
                    Response.Redirect("ListadoDiario.aspx?IdMenuCategoria=3");
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
            txtLunes.Text = string.Empty;
            txtMartes.Text = string.Empty;
            txtMiercoles.Text = string.Empty;
            txtJueves.Text = string.Empty;
            txtViernes.Text = string.Empty;
            txtSabado.Text = string.Empty;
            txtDomingo.Text = string.Empty;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Update();
            LimpiarCampos();
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListadoDiario.aspx?IdMenuCategoria=3");
        }

    }
}