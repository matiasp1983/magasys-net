using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.logic
{
    public class Localidad : FactoryBase
    {

        public Dyn.Database.entities.Localidad Load(int idLocalidad)
        {
            Dyn.Database.entities.Localidad objLocalidad = new Dyn.Database.entities.Localidad();
            CreateCommand("usp_Localidad", true);
            AddCmdParameter("@idLocalidad", idLocalidad, ParameterDirection.Input);
            AddCmdParameter("@Action", 1, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                objLocalidad = new Dyn.Database.entities.Localidad(GetDataReader());
            }
            return objLocalidad;
        }

        public List<Dyn.Database.entities.Localidad> SeleccionarLocalidadesPorProvincia (int idProvincia)
        {
            List<Dyn.Database.entities.Localidad> Collection = new List<Dyn.Database.entities.Localidad>();
            CreateCommand("usp_Localidad", true);
            AddCmdParameter("@idProvincia", idProvincia, ParameterDirection.Input);
            AddCmdParameter("@Action", 0, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                Collection.Add(new Dyn.Database.entities.Localidad(GetDataReader()));
            }
            return Collection;
        }

        public Dyn.Database.entities.Localidad LocalidadProvincia(int idLocalidad)
        {
            Dyn.Database.entities.Localidad objLocalidad = new Dyn.Database.entities.Localidad();
            CreateCommand("usp_Localidad", true);
            AddCmdParameter("@idLocalidad", idLocalidad, ParameterDirection.Input);
            AddCmdParameter("@Action", 2, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                objLocalidad = new Dyn.Database.entities.Localidad(GetDataReader());
            }
            return objLocalidad;
        }
    }
}
