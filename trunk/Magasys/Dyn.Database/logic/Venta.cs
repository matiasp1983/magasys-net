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
            AddCmdParameter("@fecha", objVenta.Fecha, ParameterDirection.Input);
            AddCmdParameter("@idEstado", objVenta.IdEstado, ParameterDirection.Input);
            AddCmdParameter("@total", objVenta.MonTotal, ParameterDirection.Input);
            AddCmdParameter("@formaDePago", objVenta.FormaPago, ParameterDirection.Input);
            AddCmdParameter("@nroCliente", objVenta.NroCliente, ParameterDirection.Input);
        }

        public object Insert(Dyn.Database.entities.Venta objVenta)
        {
            object IdVenta = null;
            AddParameters(objVenta);
            AddCmdParameter("@Action", 1, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                IdVenta = GetValue(0);
            }
            return IdVenta;
        }

        public int BuscarUltimoIdVenta()
        {
            CreateCommand("usp_Venta", true);
            AddCmdParameter("@Action", 2, ParameterDirection.Input);
            int maxIdVenta;
            return maxIdVenta = (int)ExecuteScalar();
        }

        public DataSet SeleccionarVentasPorNombrePaginadoAdmin(DateTime fechainicial, DateTime fechafinal, int paginaactual, ref int numeropaginas)
        {
            CreateCommand("usp_SeleccionarVentasPorNombrePaginado", true);
            AddCmdParameter("@fechaIni", fechainicial, ParameterDirection.Input);
            AddCmdParameter("@fechaFin", fechafinal, ParameterDirection.Input);
            AddCmdParameter("@CurrentPage", paginaactual, ParameterDirection.Input);
            AddCmdParameter("@PageSize", 100, ParameterDirection.Input);
            AddCmdParameter("@TotalRecords", ParameterDirection.Output);
            DataSet ds = GetDataSet();
            numeropaginas = (int)GetValueCmdParameter("@TotalRecords");
            return ds;
        }

        public List<Dyn.Database.entities.Venta> BuscarVentasPorClienteCobro(int nroCliente, DateTime fechaInicio, DateTime fechaFin)
        {
            List<Dyn.Database.entities.Venta> Collection = new List<Dyn.Database.entities.Venta>();
            CreateCommand("usp_Venta", true);
            AddCmdParameter("@nroCliente", nroCliente, ParameterDirection.Input);
            AddCmdParameter("@fechaIni", fechaInicio, ParameterDirection.Input);
            AddCmdParameter("@fechaFin", fechaFin, ParameterDirection.Input);
            AddCmdParameter("@Action", 3, ParameterDirection.Input);

            ExecuteReader();
            while (Read())
            {
                Collection.Add(new Dyn.Database.entities.Venta(GetDataReader()));
            }
            DataSet ds = GetDataSet();
            return Collection;
        }

        public void cambiarEstadoEntregadoPagado(int idVenta)
        {
            Dyn.Database.logic.Estado lEstado = new Dyn.Database.logic.Estado();
            int estado = Convert.ToInt16(lEstado.BuscarEstado("Ventas", "Entregado-Pagado"));

            CreateCommand("usp_Venta", true);
            AddCmdParameter("@idVenta", idVenta, ParameterDirection.Input);
            AddCmdParameter("@idEstado", estado, ParameterDirection.Input);
            AddCmdParameter("@Action", 4, ParameterDirection.Input);
            ExecuteNonQuery();
        }
    }
}
