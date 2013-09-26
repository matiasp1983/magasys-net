using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.logic
{
    public class Reserva : FactoryBase
    {
        public Reserva() { }

        private void AddParameters(Dyn.Database.entities.Reserva objReserva)
        {
            CreateCommand("usp_Reserva", true);
            AddCmdParameter("@nroCliente", objReserva.NroCliente, ParameterDirection.Input);
            AddCmdParameter("@fechaInicio", objReserva.FechaInicio, ParameterDirection.Input);
            AddCmdParameter("@fechaFin", objReserva.FechaFin, ParameterDirection.Input);
            AddCmdParameter("@tipoReserva", objReserva.TipoReserva, ParameterDirection.Input);
            AddCmdParameter("@idProducto", objReserva.IdProducto, ParameterDirection.Input);
            AddCmdParameter("@cantidad", objReserva.Cantidad, ParameterDirection.Input);
            AddCmdParameter("@idEstado", objReserva.IdEstado, ParameterDirection.Input);
        }

        public object Insert(Dyn.Database.entities.Reserva objReserva)
        {
            object idReserva = null;
            AddParameters(objReserva);
            AddCmdParameter("@fechaReserva", objReserva.FechaReserva, ParameterDirection.Input);
            AddCmdParameter("@Action", 2, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                idReserva = GetValue(0);
            }
            return idReserva;
        }

        public void Update(Dyn.Database.entities.Reserva objReserva)
        {
            AddParameters(objReserva);
            AddCmdParameter("@Action", 1, ParameterDirection.Input);
            ExecuteNonQuery();
        }

    }
}
