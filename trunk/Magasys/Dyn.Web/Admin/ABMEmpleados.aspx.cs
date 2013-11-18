using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dyn.Web.Admin
{
    public partial class AMBEmpleados : System.Web.UI.Page
    {
        public Dyn.Database.entities.Empleado Entity;
        public Dyn.Database.logic.Empleado lEmpleado;

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

        }
    }
}