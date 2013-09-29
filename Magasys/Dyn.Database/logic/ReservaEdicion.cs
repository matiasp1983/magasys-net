using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.logic
{
    public class ReservaEdicion : FactoryBase
    {
        public ReservaEdicion() { }

        public Dyn.Database.entities.ReservaEdicion Load(int codReservaEdicion)
        {
            Dyn.Database.entities.ReservaEdicion objReservaEdicion = new Dyn.Database.entities.ReservaEdicion();
            CreateCommand("usp_ReservaEdicion", true);
            AddCmdParameter("@codReservaEdicion", codReservaEdicion, ParameterDirection.Input);
            AddCmdParameter("@Action", 0, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                objReservaEdicion = new Dyn.Database.entities.ReservaEdicion(GetDataReader());
            }
            return objReservaEdicion;
        }
        private void AddParameters(Dyn.Database.entities.ReservaEdicion objReservaEdic)
        {
            CreateCommand("usp_ReservaEdicion", true);
            AddCmdParameter("@codReservaEdicion", objReservaEdic.CodReservaEdicion, ParameterDirection.Input);
            AddCmdParameter("@idProductoEdicion", objReservaEdic.IdProductoEdicion, ParameterDirection.Input);
            AddCmdParameter("@nroCliente", objReservaEdic.NroCliente, ParameterDirection.Input);
            AddCmdParameter("@codReserva", objReservaEdic.CodReserva, ParameterDirection.Input);
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
        public List<Dyn.Database.entities.ReservaEdicion> BuscarReservasPorCliente(Int32 nroCliente)
        {
            List<Dyn.Database.entities.ReservaEdicion> listaReservas = new List<entities.ReservaEdicion>();
            Dyn.Database.logic.Producto lProducto = new Dyn.Database.logic.Producto();
            CreateCommand("usp_SeleccionarReservasEdicionPorCliente", true);
            AddCmdParameter("@nroCliente", nroCliente, ParameterDirection.Input);
            AddCmdParameter("@Action", 0, ParameterDirection.Input);
            // Cdo este listo el estado se deberia poner el estado que va...
            Dyn.Database.logic.Estado lEstado = new Dyn.Database.logic.Estado();
            AddCmdParameter("@idEstado", lEstado.BuscarEstado("ReservasEdicion", "Confirmado"), ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                listaReservas.Add(new entities.ReservaEdicion(GetDataReader()));

            }

            for (int i = 0; i < listaReservas.Count; i++)
            {
                CreateCommand("usp_SeleccionarReservasEdicionPorCliente", true);
                listaReservas[i].CargarPropiedades();
            }

            return listaReservas;
        }
        public void Entregar(Int32 codReservaEdicion)
        {
            CreateCommand("usp_ReservaEdicion", true);
            Dyn.Database.logic.Estado lEstado = new Dyn.Database.logic.Estado();
            AddCmdParameter("@idEstado", lEstado.BuscarEstado("ReservasEdicion", "Confirmado"), ParameterDirection.Input);
        }
    }
}
