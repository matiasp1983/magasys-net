﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace Dyn.Web.Admin
{
    public partial class ListadoProveedor : System.Web.UI.Page
    {

        private Dyn.Database.logic.Proveedor lColeccion;
        private int numeropaginas;


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.Master.TituloPagina = "Proveedor";
            }
        }
    }
}