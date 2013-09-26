using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.logic
{
    public class ReservaEdicion : FactoryBase
    {
        public ReservaEdicion() { }

        private void AddParameters(Dyn.Database.entities.ReservaEdicion objReservaEdic)
        {
            CreateCommand("usp_ReservaEdicion", true);
            AddCmdParameter("@idProductoEdicion", objReservaEdic.IdProductoEdicion, ParameterDirection.Input);
            AddCmdParameter("@nroCliente", objReservaEdic.NroCliente, ParameterDirection.Input);
            AddCmdParameter("@fechaInicio", objReservaEdic.FechaInicio, ParameterDirection.Input);
            AddCmdParameter("@fechaFin", objReservaEdic.FechaFin, ParameterDirection.Input);
            AddCmdParameter("@tipoReserva", objReservaEdic.TipoReserva, ParameterDirection.Input);
            AddCmdParameter("@cantidad", objReservaEdic.Cantidad, ParameterDirection.Input);
            AddCmdParameter("@idEstado", objReservaEdic.IdEstado, ParameterDirection.Input);
        }

        public object Insert(Dyn.Database.entities.ReservaEdicion objReservaEdic)
        {
            object idReservaEdicion = null;
            AddParameters(objReservaEdic);
            AddCmdParameter("@fechaReservaEdicion", objReservaEdic.FechaReservaEdicion, ParameterDirection.Input);
            AddCmdParameter("@Action", 2, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                idReservaEdicion = GetValue(0);
            }
            return idReservaEdicion;
        }

        public void Update(Dyn.Database.entities.ReservaEdicion objReservaEdic)
        {
            AddParameters(objReservaEdic);
            AddCmdParameter("@Action", 1, ParameterDirection.Input);
            ExecuteNonQuery();
        }
    }
}
