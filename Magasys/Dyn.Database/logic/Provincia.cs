using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.logic
{
    public class Provincia : FactoryBase
    {
        public Provincia() { }

        public Dyn.Database.entities.Provincia Load(int idProvincia)
        {
            Dyn.Database.entities.Provincia objProvincia = new Dyn.Database.entities.Provincia();
            CreateCommand("usp_Provincia", true);
            AddCmdParameter("@idProvincia", idProvincia, ParameterDirection.Input);
            AddCmdParameter("@Action", 0, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                objProvincia = new Dyn.Database.entities.Provincia(GetDataReader());
            }
            return objProvincia;
        }
        public List<Dyn.Database.entities.Provincia> SeleccionarTodasLasProvicias()
        {
            List<Dyn.Database.entities.Provincia> Collection = new List<Dyn.Database.entities.Provincia>();
            CreateCommand("usp_Provincia", true);
            AddCmdParameter("@Action", 0, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                Collection.Add(new Dyn.Database.entities.Provincia(GetDataReader()));
            }
            return Collection;
        }

    }
}
