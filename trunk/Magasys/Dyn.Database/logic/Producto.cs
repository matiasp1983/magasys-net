using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.logic
{
    public class Producto : FactoryBase
    {
        public Producto() { }

        public int SeleccionarReservaPorProducto(int idproducto)
        {
            List<Dyn.Database.entities.Producto> Collection = new List<Dyn.Database.entities.Producto>();
            CreateCommand("usp_SeleccionarReservaPorProducto", true);
            AddCmdParameter("@idproducto", idproducto, ParameterDirection.Input);
            ExecuteReader();
            int i = 0;
            if (Read())
            {
                i++;
            }
            return i;
        }

    }
}
