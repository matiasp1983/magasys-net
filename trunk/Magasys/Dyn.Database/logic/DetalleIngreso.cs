using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.logic
{
    public class DetalleIngreso : FactoryBase
    {
        public DetalleIngreso() { }

        public Dyn.Database.entities.DetalleIngresoProducto Load(int idDetalleIngreso)
        {
            Dyn.Database.entities.DetalleIngresoProducto objDetalle = new Dyn.Database.entities.DetalleIngresoProducto();
            CreateCommand("usp_DetalleIngreso", true);
            AddCmdParameter("@idDetalleIngresoProductos", idDetalleIngreso, ParameterDirection.Input);
            AddCmdParameter("@Action", 0, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                objDetalle = new Dyn.Database.entities.DetalleIngresoProducto(GetDataReader());
            }
            return objDetalle;
        }

        public List<Dyn.Database.entities.DetalleIngresoProducto> SeleccionarDetallesPorIngreso(Int32? idIngreso)
        {
            List<Dyn.Database.entities.DetalleIngresoProducto> Collection = new List<Dyn.Database.entities.DetalleIngresoProducto>();
            CreateCommand("usp_DetalleIngreso", true);
            AddCmdParameter("@Action", 4, ParameterDirection.Input);
            AddCmdParameter("@idIngresoProducto", idIngreso, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                Collection.Add(new Dyn.Database.entities.DetalleIngresoProducto(GetDataReader()));
            }
            return Collection;
        }

        private void AddParameters(Dyn.Database.entities.DetalleIngresoProducto objusuario)
        {
            CreateCommand("usp_DetalleIngreso", true);
            AddCmdParameter("@idDetalleIngresoProductos", objusuario.IdDetalleIngresoProducto, ParameterDirection.Input);
            AddCmdParameter("@idIngresoProducto", objusuario.IdIngresoProductos, ParameterDirection.Input);
            AddCmdParameter("@cantidadUnidades", objusuario.CantidadUnidades, ParameterDirection.Input);
            AddCmdParameter("@fechaDevolucion", objusuario.FechaDevolucion, ParameterDirection.Input);
            AddCmdParameter("@estado", objusuario.Estado, ParameterDirection.Input);
            AddCmdParameter("@idProducto", objusuario.Producto.IdProducto, ParameterDirection.Input);
            AddCmdParameter("@idProductoEdicion", objusuario.IdProductoEdicion, ParameterDirection.Input);
        }

        public object Insert(Dyn.Database.entities.DetalleIngresoProducto objDetalle)
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
        public void Update(Dyn.Database.entities.DetalleIngresoProducto objDetalle)
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
