using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dyn.Web.weblogic;

namespace Dyn.Web.User
{
    public partial class MisDatos : System.Web.UI.Page
    {
        private Dyn.Database.logic.Cliente lCliente;
        public Dyn.Database.entities.Cliente Entity;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CurrentUser.RegresarHome();

                Dyn.Database.logic.Usuario lUsuario = new Dyn.Database.logic.Usuario();
                Dyn.Database.entities.Usuario eusuario = new Database.entities.Usuario();
                Dyn.Database.entities.Localidad eLocalidad = new Database.entities.Localidad();
                Dyn.Database.logic.Localidad llocalidad = new Database.logic.Localidad();
                Dyn.Database.entities.TipoDocumento eTipoDocumento = new Database.entities.TipoDocumento();
                Dyn.Database.logic.TipoDocumento lTipoDocumento = new Database.logic.TipoDocumento();
                lCliente = new Dyn.Database.logic.Cliente();
                Entity = new Database.entities.Cliente();
                
                System.Security.Principal.IIdentity user = HttpContext.Current.User.Identity;

                eusuario = lUsuario.SeleccionarUsuarioPorLogin(user.Name);

                if (eusuario != null)
                {
                    Entity = lCliente.Load((int)eusuario.Cliente.NroCliente);
                    lblNroCliente.Text = Entity.NroCliente.ToString();
                    eTipoDocumento = lTipoDocumento.BuscarTipoDocumento((int)Entity.TipoDocumento.IdTipoDocumento);
                    lblTipoDoc.Text = eTipoDocumento.Nombre;
                    lblNroDocumento.Text = Entity.NroDocumento.ToString();
                    lblNombre.Text = Entity.Nombre.ToString();
                    lblApellido.Text = Entity.Apellido.ToString();
                    lblAlias.Text = Entity.Alias.ToString();
                    lblTelefono.Text = Entity.Telefono.ToString();
                    lblCelular.Text = Entity.Celular.ToString();
                    lblEMail.Text = Entity.Email.ToString();
                    lblCalle.Text = Entity.DomicilioCalle.ToString();
                    lblNumero.Text = Entity.DomicilioNro.ToString();
                    lblPiso.Text = Entity.DomicilioPiso.ToString();
                    lblDpto.Text = Entity.DomicilioDpto.ToString();
                    lblBarrio.Text = Entity.DomicilioBarrio.ToString();
                    lblCodPostal.Text = Entity.DomicilioCodPostal.ToString();
                    eLocalidad = llocalidad.LocalidadProvincia((int)Entity.IdLocalidad);
                    lblLocalidad.Text = eLocalidad.Nombre.ToString();
                    lblProvincia.Text = eLocalidad.Provincia.Nombre.ToString();
                }
            }
        }
    }
}