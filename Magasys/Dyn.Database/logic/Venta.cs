using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.logic
{
    public class Venta : FactoryBase
    {
        public Venta() { }

        public Dyn.Database.entities.Venta Load(int idVenta)
        {
            Dyn.Database.entities.Venta objVenta = new Dyn.Database.entities.Venta();
            CreateCommand("usp_Venta", true);
            AddCmdParameter("@Action", 0, ParameterDirection.Input);
            AddCmdParameter("@idVenta", idVenta, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                objVenta = new Dyn.Database.entities.Venta(GetDataReader());
            }
            return objVenta;
        }



    }
}
