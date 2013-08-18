using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.logic
{
    public class Venta : FactoryBase
    {
        public Venta() { }

        public Dyn.Database.entities.Venta Load(int idVenta)
        {
            Dyn.Database.entities.Venta objVenta = new Dyn.Database.entities.Venta();
            CreateCommand("usp_Venta", true);
            AddCmdParameter("@Action", 0, ParameterDirection.Input);
            AddCmdParameter("@idVenta", idVenta, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                objVenta = new Dyn.Database.entities.Venta(GetDataReader());
            }
            return objVenta;
        }

        private void AddParameters(Dyn.Database.entities.Venta objVenta)
        {
            CreateCommand("usp_Venta", true);
            AddCmdParameter("@idVenta", objVenta.IdVenta, ParameterDirection.Input);
            AddCmdParameter("@fecha", objVenta.Fecha, ParameterDirection.Input);
            AddCmdParameter("@estado", objVenta.Estado, ParameterDirection.Input);
            AddCmdParameter("@total", objVenta.MonTotal, ParameterDirection.Input);
            AddCmdParameter("@nombreCliente", objVenta.NombreCliente, ParameterDirection.Input);
        }

        public void Update(Dyn.Database.entities.Venta objVenta)
        {
            objVenta.Estado = Dyn.Database.entities.Venta.VentaEstado.Confirmado;
            AddParameters(objVenta);
            AddCmdParameter("@Action", 1, ParameterDirection.Input);
            ExecuteNonQuery();
        }

        public object Insert(Dyn.Database.entities.Venta objVenta)
        {
            object IdVenta = null;
            objVenta.Estado = Dyn.Database.entities.Venta.VentaEstado.Confirmado;
            AddParameters(objVenta);
            AddCmdParameter("@Action", 2, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                IdVenta = GetValue(0);
            }
            return IdVenta;
        }

        public void Delete(int idVenta)
        {
            CreateCommand("usp_Venta", true);
            AddCmdParameter("@idVenta", idVenta, ParameterDirection.Input);
            AddCmdParameter("@estado", 0, ParameterDirection.Input);
            AddCmdParameter("@Action", 3, ParameterDirection.Input);
            ExecuteNonQuery();
        }

        public int BuscarUltimoIdVenta()
        {
            CreateCommand("usp_Venta", true);
            AddCmdParameter("@Action", 4, ParameterDirection.Input);
            DataSet ds = GetDataSet();
            int i = 0;
            i = (int)GetValueCmdParameter("@maxIdVenta");
            return i;
        }
    }
}
