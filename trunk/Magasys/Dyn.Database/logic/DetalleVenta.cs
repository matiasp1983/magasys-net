using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.logic
{
    public class DetalleVenta : FactoryBase
    {
        public DetalleVenta() { }

        public List<Dyn.Database.entities.DetalleVenta> SeleccionarProductosVenta(int idVenta)
        {
            List<Dyn.Database.entities.DetalleVenta> Collection = new List<Dyn.Database.entities.DetalleVenta>();
            CreateCommand("usp_SeleccionarProductosVenta", true);
            AddCmdParameter("@idVenta", idVenta, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                Collection.Add(new Dyn.Database.entities.DetalleVenta(GetDataReader()));
            }
            return Collection;
        }

        private void AddParameters(Dyn.Database.entities.DetalleVenta objDetalleVenta)
        {
            CreateCommand("usp_DetalleVenta", true);
            AddCmdParameter("@idVenta", objDetalleVenta.IdVenta, ParameterDirection.Input);
            AddCmdParameter("@idProducto", objDetalleVenta.IdProducto, ParameterDirection.Input);
            AddCmdParameter("@idProductoEdicion", objDetalleVenta.IdEdicion, ParameterDirection.Input);
            AddCmdParameter("@precioUnidad", objDetalleVenta.PrecioUnidad, ParameterDirection.Input);
            AddCmdParameter("@cantidad", objDetalleVenta.Cantidad, ParameterDirection.Input);
            AddCmdParameter("@subTotal", objDetalleVenta.SubTotal, ParameterDirection.Input);
        }

        public void Update(Dyn.Database.entities.DetalleVenta objDetalleVenta)
        {
            AddParameters(objDetalleVenta);
            AddCmdParameter("@idDetalle", objDetalleVenta.IdDetalleVenta, ParameterDirection.Input);
            AddCmdParameter("@Action", 1, ParameterDirection.Input);
            ExecuteNonQuery();
        }

        public object Insert(Dyn.Database.entities.DetalleVenta objDetalleVenta)
        {
            object IdDetVenta = null;
            AddParameters(objDetalleVenta);
            AddCmdParameter("@Action", 2, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                IdDetVenta = GetValue(0);
            }
            return IdDetVenta;
        }

        public void Delete(int idDetalleVenta, int idVenta)
        {
            CreateCommand("usp_DetalleVenta", true);
            AddCmdParameter("@idDetalle", idDetalleVenta, ParameterDirection.Input);
            AddCmdParameter("@idVenta", idVenta, ParameterDirection.Input);
            AddCmdParameter("@Action", 3, ParameterDirection.Input);
            ExecuteNonQuery();
        }
    }
}
