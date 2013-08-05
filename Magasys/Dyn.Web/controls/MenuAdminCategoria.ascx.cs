using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dyn.Web.controls
{
    public partial class MenuAdminCategoria : System.Web.UI.UserControl
    {
        private Dyn.Database.logic.MenuCategoria lCategoria;

        public int IdMenuCategoria
        {
            get
            {
                return int.Parse(Request["IdMenuCategoria"]);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            lCategoria = new Dyn.Database.logic.MenuCategoria();
            repMenuAdminCategoria.DataSource = lCategoria.SeleccionarCategoriasPadre(1);
            repMenuAdminCategoria.DataBind();
        }

        protected void repMenuAdminCategoria_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                int idcategoria = Convert.ToInt32(((Label)e.Item.FindControl("lblIdCategoria")).Text);
                int idcategoriapadre = idcategoria;
                Repeater repSubCategoria = (Repeater)e.Item.FindControl("repSubCategoria");
                Dyn.Database.logic.MenuCategoria lcategoria = new Dyn.Database.logic.MenuCategoria();
                Dyn.Database.entities.MenuCategoria ecategoria = new Dyn.Database.entities.MenuCategoria();
                ecategoria = lcategoria.Load(IdMenuCategoria);
                if (ecategoria.RelacionadaIdMenuCategoria != null)
                {
                    idcategoriapadre = (int)ecategoria.IdMenuCategoria;
                }
                if (idcategoriapadre == IdMenuCategoria)
                {
                    repSubCategoria.Visible = true;
                    lCategoria = new Dyn.Database.logic.MenuCategoria();
                    repSubCategoria.DataSource = lCategoria.SeleccionarSubCategoriaDeCategoria(idcategoria, 1);
                    repSubCategoria.DataBind();
                }
                else
                {
                    repSubCategoria.Visible = false;
                }
            }
        }
    }
}