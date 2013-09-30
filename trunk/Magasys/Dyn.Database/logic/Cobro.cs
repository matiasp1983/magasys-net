using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.logic
{
    public class Cobro : FactoryBase
    {
        public Cobro() { }

        public List<Dyn.Database.entities.Cobro> BuscarCobro(int nroCliente, DateTime fechaIni, DateTime fechaFin, int idEstado)
        {
            List<Dyn.Database.entities.Cobro> Collection = new List<Dyn.Database.entities.Cobro>();
            CreateCommand("usp_Cobro", true);
            AddCmdParameter("@nroCliente", nroCliente, ParameterDirection.Input);
            AddCmdParameter("@idEstado", idEstado, ParameterDirection.Input);

            if (!fechaIni.Equals(DateTime.MaxValue))
            {
                AddCmdParameter("@fechaIni", fechaIni, ParameterDirection.Input);
            }

            if (!fechaFin.Equals(DateTime.MaxValue))
            {
                AddCmdParameter("@fechaFin", fechaFin, ParameterDirection.Input);
            }

            AddCmdParameter("@Action", 2, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                Collection.Add(new Dyn.Database.entities.Cobro(GetDataReader()));
            }
            DataSet ds = GetDataSet();
            return Collection;
        }
    }
}
