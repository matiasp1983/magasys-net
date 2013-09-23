using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.logic
{
    public class TipoDocumento : FactoryBase
    {
        public TipoDocumento() { }

        public List<Dyn.Database.entities.TipoDocumento> SeleccionarTodosLosTiposDocumento()
        {
            List<Dyn.Database.entities.TipoDocumento> Collection = new List<Dyn.Database.entities.TipoDocumento>();
            CreateCommand("usp_SeleccionarTodosLosTiposDocumento", true);
            ExecuteReader();
            while (Read())
            {
                Collection.Add(new Dyn.Database.entities.TipoDocumento(GetDataReader()));
            }
            return Collection;
        }
      
    }
}
