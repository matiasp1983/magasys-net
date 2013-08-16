using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.logic
{
    public class DetalleVenta : FactoryBase
    {
        public DetalleVenta() { }

        public List<Dyn.Database.entities.DetalleVenta> SeleccionarProductosVenta(int idVenta)
        {
            List<Dyn.Database.entities.DetalleVenta> Collection = new List<Dyn.Database.entities.DetalleVenta>();
            CreateCommand("usp_SeleccionarProductosVenta", true);
            AddCmdParameter("@idVenta", idVenta, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                Collection.Add(new Dyn.Database.entities.DetalleVenta(GetDataReader()));
            }
            return Collection;
        }
    }
}
