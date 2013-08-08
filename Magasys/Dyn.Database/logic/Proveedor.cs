using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.logic
{
    public class Proveedor : FactoryBase
    {
        public Proveedor() { }

        public List<Dyn.Database.entities.Proveedor> SeleccionarTodosLosProveedores()
        {
            List<Dyn.Database.entities.Proveedor> Collection = new List<Dyn.Database.entities.Proveedor>();
            CreateCommand("usp_SeleccionarTodosLosProveedores", true);
            ExecuteReader();
            while (Read())
            {                
                Collection.Add(new Dyn.Database.entities.Proveedor(GetDataReader()));
            }
            return Collection;
        }
    }
}
