using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Dyn.Web.controls
{
	public partial class MenuAdmin : System.Web.UI.UserControl
	{
        private Dyn.Database.logic.MenuCategoria lCategoria;
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                lCategoria = new Dyn.Database.logic.MenuCategoria();
                repMenuAdmin.DataSource = lCategoria.SeleccionarCategoriasPadre(1);
                repMenuAdmin.DataBind();
            }
		}
	}
}