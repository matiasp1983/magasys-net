using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.logic
{
    public class Reserva : FactoryBase
    {
        public Reserva() { }

        public Dyn.Database.entities.Reserva Load_Reserva(int codReserva)
        {
            Dyn.Database.entities.Reserva objReserva = new Dyn.Database.entities.Reserva();
            CreateCommand("usp_Reserva", true);
            AddCmdParameter("@codReserva", codReserva, ParameterDirection.Input);
            AddCmdParameter("@Action", 0, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                objReserva = new Dyn.Database.entities.Reserva(GetDataReader());
            }
            return objReserva;
        }

        public Dyn.Database.entities.Reserva Load(int codReserva)
        {
            Dyn.Database.entities.Reserva objIngreso = new Dyn.Database.entities.Reserva();
            CreateCommand("usp_SeleccionarReservasPorProducto", true);
            AddCmdParameter("@codReserva", codReserva, ParameterDirection.Input);
            AddCmdParameter("@Action", 1, ParameterDirection.Input);
            // Cdo este listo el estado se deberia poner el estado que va...
            //AddCmdParameter("@idEstado", 3, ParameterDirection.Input);
            Dyn.Database.logic.Estado lEstado = new Dyn.Database.logic.Estado();
            AddCmdParameter("@idEstado", lEstado.BuscarEstado("Reservas","Confirmado"), ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                objIngreso = new Dyn.Database.entities.Reserva(GetDataReader());
            }
            return objIngreso;
        }

        public object Insert(Dyn.Database.entities.Reserva objReserva)
        {
            object idReserva = null;
            AddParameters(objReserva);
            AddCmdParameter("@fechaReserva", objReserva.FechaReserva, ParameterDirection.Input);
            AddCmdParameter("@nroCliente", objReserva.NroCliente, ParameterDirection.Input);
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
            AddCmdParameter("@codReserva", objReserva.CodReserva, ParameterDirection.Input);
            AddCmdParameter("@Action", 1, ParameterDirection.Input);
            ExecuteNonQuery();
        }

        private void AddParameters(Dyn.Database.entities.Reserva objReserva)
        {
            CreateCommand("usp_Reserva", true);
            AddCmdParameter("@fechaInicio", objReserva.FechaInicio, ParameterDirection.Input);
            //if (objReserva.FechaFin != DateTime.MaxValue)
            //{
            //    AddCmdParameter("@fechaFin", objReserva.FechaFin, ParameterDirection.Input);
            //}
            //else
            //{
            //    AddCmdParameter("@fechaFin", "NULL", ParameterDirection.Input);
            //}
            AddCmdParameter("@fechaFin", objReserva.FechaFin, ParameterDirection.Input);
            AddCmdParameter("@tipoReserva", objReserva.TipoReserva, ParameterDirection.Input);
            AddCmdParameter("@idProducto", objReserva.IdProducto, ParameterDirection.Input);
            AddCmdParameter("@cantidad", objReserva.Cantidad, ParameterDirection.Input);
            AddCmdParameter("@idEstado", objReserva.IdEstado, ParameterDirection.Input);
        }

        public void Delete(int codReserva, int idEstado)
        {
            CreateCommand("usp_Reserva", true);
            AddCmdParameter("@codReserva", codReserva, ParameterDirection.Input);
            AddCmdParameter("@idEstado", idEstado, ParameterDirection.Input);
            AddCmdParameter("@Action", 3, ParameterDirection.Input);
            ExecuteNonQuery();
        }

        public List<Dyn.Database.entities.Reserva> BuscarReservasPorProductos(List<Dyn.Database.entities.Producto> listaProductos)
        {
            List<Dyn.Database.entities.Reserva> listaReservas = new List<entities.Reserva>();
            Dyn.Database.logic.Producto lProducto = new Dyn.Database.logic.Producto();
            for (int i = 0; i < listaProductos.Count; i++)
            {
                CreateCommand("usp_SeleccionarReservasPorProducto", true);
                AddCmdParameter("@idProducto", listaProductos[i].IdProducto, ParameterDirection.Input);
                AddCmdParameter("@Action", 0, ParameterDirection.Input);
                // Cdo este listo el estado se deberia poner el estado que va...
                Dyn.Database.logic.Estado lEstado = new Dyn.Database.logic.Estado();
                AddCmdParameter("@idEstado", lEstado.BuscarEstado("Reservas", "Confirmado"), ParameterDirection.Input);
                ExecuteReader();
                while (Read())
                {
                    listaReservas.Add(new entities.Reserva(GetDataReader()));

                }

            }
            for (int i = 0; i < listaReservas.Count; i++)
            {
                listaReservas[i].CargarPropiedades();
            }

            return listaReservas;
        }

        public List<Dyn.Database.entities.Reserva> BuscarReservas(DateTime fecReserva, string tipoReserva, string alias, string nombre, string apellido, int idEstado)
        {
            List<Dyn.Database.entities.Reserva> Collection = new List<Dyn.Database.entities.Reserva>();
            CreateCommand("usp_Reserva", true);

            if (!fecReserva.Equals(DateTime.MaxValue))
            {
                AddCmdParameter("@fechaReserva", fecReserva, ParameterDirection.Input);
            }
            if (tipoReserva != string.Empty)
            {
                AddCmdParameter("@tipoReserva", tipoReserva, ParameterDirection.Input);
            }
            AddCmdParameter("@alias", alias, ParameterDirection.Input);
            AddCmdParameter("@nombreCliente", nombre, ParameterDirection.Input);
            AddCmdParameter("@apellidoCliente", apellido, ParameterDirection.Input);
            AddCmdParameter("@idEstado", idEstado, ParameterDirection.Input);
            AddCmdParameter("@Action", 0, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                Collection.Add(new Dyn.Database.entities.Reserva(GetDataReader()));
            }
            for (int i = 0; i < Collection.Count; i++)
            {
                Collection[i].CargarPropiedades();
            }
            DataSet ds = GetDataSet();
            return Collection;
        }
    }
}
