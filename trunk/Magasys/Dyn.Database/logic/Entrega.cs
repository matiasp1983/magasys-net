using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Dyn.Database.logic
{
    public class Entrega : FactoryBase
    {
        public Entrega() { }

        public Dyn.Database.entities.Entrega Load(int codEntrega)
        {
            Dyn.Database.entities.Entrega objEstado = new Dyn.Database.entities.Entrega();
            CreateCommand("usp_Entrega", true);
            AddCmdParameter("@codEntrega", codEntrega, ParameterDirection.Input);
            AddCmdParameter("@Action", 0, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                objEstado = new Dyn.Database.entities.Entrega(GetDataReader());
            }
            return objEstado;
        }


        private void AddParameters(Dyn.Database.entities.Entrega objEntrega)
        {
            CreateCommand("usp_Entrega", true);
            AddCmdParameter("@codEntrega", objEntrega.CodEntrega, ParameterDirection.Input);
            AddCmdParameter("@codReservaEdicion", objEntrega.ReservaEdicion.CodReservaEdicion, ParameterDirection.Input);
            AddCmdParameter("@fecha", objEntrega.Fecha, ParameterDirection.Input);
        }

        public object Insert(Dyn.Database.entities.Entrega objEntrega)
        {
            object CodEntrega = null;
            AddParameters(objEntrega);
            AddCmdParameter("@Action", 2, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                CodEntrega = GetValue(0);
            }
            return CodEntrega;
        }

        public void Update(Dyn.Database.entities.Entrega objEntrega)
        {   
            // objEstado.Estado = 1;
            AddParameters(objEntrega);
            AddCmdParameter("@Action", 1, ParameterDirection.Input);
            ExecuteNonQuery();
        }

        public void Delete(int CodEntrega)
        {
            CreateCommand("usp_Entrega", true);
            AddCmdParameter("@codEntrega", CodEntrega, ParameterDirection.Input);
            AddCmdParameter("@Action", 3, ParameterDirection.Input);
            ExecuteNonQuery();
        }

    }
}
