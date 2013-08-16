using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.logic
{
    public class Devolucion : FactoryBase
    {
        public Devolucion() { }

        public Dyn.Database.entities.Devolucion Load(int idDevolucion)
        {
            Dyn.Database.entities.Devolucion objDevolucion = new Dyn.Database.entities.Devolucion();
            CreateCommand("usp_Devolucion", true);
            AddCmdParameter("@idDevolucion", idDevolucion, ParameterDirection.Input);
            AddCmdParameter("@Action", 0, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                objDevolucion = new Dyn.Database.entities.Devolucion(GetDataReader());
            }
            return objDevolucion;
        }

        private void AddParameters(Dyn.Database.entities.Devolucion objusuario)
        {
            Database.logic.ProductoEdicion2 lProdEdi = new Database.logic.ProductoEdicion2();
            int idProdEdi = Convert.ToInt32(lProdEdi.Insert(objusuario.ProductoEdicion));
            CreateCommand("usp_DetalleIngreso", true);
            AddCmdParameter("@idDetalleIngresoProductos", objusuario.IdDetalleIngresoProducto, ParameterDirection.Input);
            AddCmdParameter("@idIngresoProductos", objusuario.IdIngresoProductos, ParameterDirection.Input);
            AddCmdParameter("@cantidadUnidades", objusuario.CantidadUnidades, ParameterDirection.Input);
            AddCmdParameter("@fechaDevolucion", objusuario.FechaDevolucion, ParameterDirection.Input);
            AddCmdParameter("@estado", objusuario.Estado, ParameterDirection.Input);
            AddCmdParameter("@idProducto", objusuario.Producto.IdProducto, ParameterDirection.Input);
            AddCmdParameter("@idProductoEdicion", idProdEdi, ParameterDirection.Input);
        }

        public object Insert(Dyn.Database.entities.Devolucion objDetalle)
        {

            object IdDetalle = null;
            objDetalle.Estado = 1;
            AddParameters(objDetalle);
            AddCmdParameter("@Action", 2, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                IdDetalle = GetValue(0);
            }
            return IdDetalle;
        }
        public void Update(Dyn.Database.entities.Devolucion objDetalle)
        {
            objDetalle.Estado = 1;
            AddParameters(objDetalle);
            AddCmdParameter("@Action", 1, ParameterDirection.Input);
            ExecuteNonQuery();
        }

        public void Delete(int idDetalle)
        {
            CreateCommand("usp_DetalleIngreso", true);
            AddCmdParameter("@idDetalle", idDetalle, ParameterDirection.Input);
            AddCmdParameter("@estado", 0, ParameterDirection.Input);
            AddCmdParameter("@Action", 3, ParameterDirection.Input);
            ExecuteNonQuery();
        }

    }
}
