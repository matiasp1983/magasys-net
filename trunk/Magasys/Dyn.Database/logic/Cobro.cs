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

        public object InsertCobro(Dyn.Database.entities.Cobro objCobro)
        {
            object codCobro = null;
            Dyn.Database.logic.Estado lEstado = new Dyn.Database.logic.Estado();
            objCobro.IdEstado = Convert.ToInt16(lEstado.BuscarEstado("Cobros", "Cobrada"));
            CreateCommand("usp_Cobro", true);
            AddCmdParameter("@fechaCobro", DateTime.Now, ParameterDirection.Input);
            AddCmdParameter("@nroCliente", objCobro.NroCliente, ParameterDirection.Input);
            AddCmdParameter("@montoTotal", objCobro.MontoTotal, ParameterDirection.Input);
            AddCmdParameter("@idEstado", objCobro.IdEstado, ParameterDirection.Input);
            AddCmdParameter("@Action", 1, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                codCobro = GetValue(0);
            }
            return codCobro;
        }

        public object InsertDetalleCobro(Dyn.Database.entities.DetalleCobro objCobroDetalle)
        {
            object codDetalleCobro = null;
            CreateCommand("usp_Cobro", true);
            AddCmdParameter("@codCobro", objCobroDetalle.CodCobro, ParameterDirection.Input);
            AddCmdParameter("@codVenta", objCobroDetalle.CodVenta, ParameterDirection.Input);
            AddCmdParameter("@subtotal", objCobroDetalle.Subtotal, ParameterDirection.Input);
            AddCmdParameter("@Action", 3, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                codDetalleCobro = GetValue(0);
            }
            return codDetalleCobro;
        }
    }
}
