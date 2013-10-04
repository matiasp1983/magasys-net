using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Dyn.Database.logic
{
    public class Reparto : FactoryBase 
    {
        public Reparto() { }

        public void Insert(List<Dyn.Database.entities.ReservaEdicion> listaReservas)
        {
            for (int i = 0; i < listaReservas.Count; i++)
            {
                CreateCommand("usp_listadoUltimoReparto", true);
                AddCmdParameter("@codReservaEdicion", listaReservas[i].CodReservaEdicion, ParameterDirection.Input);
                AddCmdParameter("@entregado", 0, ParameterDirection.Input);
                AddCmdParameter("@fecha", DateTime.Now, ParameterDirection.Input);
                AddCmdParameter("@Action", 1, ParameterDirection.Input);
                ExecuteNonQuery();
            }
        }

        public void Delete()
        {
            CreateCommand("usp_listadoUltimoReparto", true);
            AddCmdParameter("@Action", 2, ParameterDirection.Input);
            ExecuteNonQuery();
        }

        public List<Dyn.Database.entities.ReservaEdicion> BuscarUltimoReparto()
        {
            List<Dyn.Database.entities.ReservaEdicion> Collection = new List<entities.ReservaEdicion>();
            Dyn.Database.entities.ReservaEdicion reserva = new entities.ReservaEdicion();
            Dyn.Database.logic.ReservaEdicion lReserva = new Dyn.Database.logic.ReservaEdicion();
            CreateCommand("usp_listadoUltimoReparto", true);
            AddCmdParameter("@Action", 0, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                IDataRecord obj = GetDataReader();
                Int32 codReservaEdicion = Convert.ToInt32(obj["codReservaEdicion"]);
                reserva = lReserva.Load(codReservaEdicion);
                reserva.CargarPropiedades();
                Collection.Add(reserva);
            }
            return Collection;

        }
    }
}
