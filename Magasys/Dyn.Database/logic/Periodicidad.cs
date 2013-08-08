using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.logic
{
    public class Periodicidad : FactoryBase
    {
        public Periodicidad() { }

        public List<Dyn.Database.entities.Periodicidad> SeleccionarTodasLasPeriodicidades()
        {
            List<Dyn.Database.entities.Periodicidad> Collection = new List<Dyn.Database.entities.Periodicidad>();
            CreateCommand("usp_SeleccionarTodasLasPeriodicidades", true);
            ExecuteReader();
            while (Read())
            {
                Collection.Add(new Dyn.Database.entities.Periodicidad(GetDataReader()));
            }
            return Collection;
        }
    }
}
