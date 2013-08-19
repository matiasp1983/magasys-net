using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.logic
{
    public class DetalleDevolucion : FactoryBase 
    {
        public DetalleDevolucion() { }

        public Dyn.Database.entities.DetalleDevolucion Load(int idDetalleDevolucion)
        {
            Dyn.Database.entities.DetalleDevolucion objDetalle = new Dyn.Database.entities.DetalleDevolucion();
            CreateCommand("usp_DetalleDevolucion", true);
            AddCmdParameter("@idDetalleDevolucion", idDetalleDevolucion, ParameterDirection.Input);
            AddCmdParameter("@Action", 0, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                objDetalle = new Dyn.Database.entities.DetalleDevolucion(GetDataReader());
            }
            return objDetalle;
        }

        public List<Dyn.Database.entities.DetalleDevolucion> SeleccionarDetallesPorDevolucion(Int32? idDevolucion)
        {
            List<Dyn.Database.entities.DetalleDevolucion> Collection = new List<Dyn.Database.entities.DetalleDevolucion>();
            CreateCommand("usp_DetalleDevolucion", true);
            AddCmdParameter("@Action", 4, ParameterDirection.Input);
            AddCmdParameter("@idDevolucion", idDevolucion, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                Collection.Add(new Dyn.Database.entities.DetalleDevolucion(GetDataReader()));
            }
            return Collection;
        }

        private void AddParameters(Dyn.Database.entities.DetalleDevolucion objusuario)
        {
            CreateCommand("usp_DetalleDevolucion", true);
            AddCmdParameter("@idDetalleDevolucion", objusuario.IdDetalleDevolucion, ParameterDirection.Input);
            AddCmdParameter("@idDevolucion", objusuario.IdDevolucion, ParameterDirection.Input);
            AddCmdParameter("@idDetalleIngresoProductos", objusuario.IdDetalleIngresoProductos, ParameterDirection.Input);
            AddCmdParameter("@estado", objusuario.Estado, ParameterDirection.Input);
            AddCmdParameter("@cantidad", objusuario.Cantidad, ParameterDirection.Input);
            AddCmdParameter("@idProducto", objusuario.Producto.IdProducto, ParameterDirection.Input);
            AddCmdParameter("@idProductoEdicion", objusuario.ProductoEdicion.IdProductoEdicion, ParameterDirection.Input);
        }

        public object Insert(Dyn.Database.entities.DetalleDevolucion objDetalle)
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
        public void Update(Dyn.Database.entities.DetalleDevolucion objDetalle)
        {
            objDetalle.Estado = 1;
            AddParameters(objDetalle);
            AddCmdParameter("@Action", 1, ParameterDirection.Input);
            ExecuteNonQuery();
        }

        public void Delete(int idDetalle)
        {
            CreateCommand("usp_DetalleDevolucion", true);
            AddCmdParameter("@idDetalleDevolucion", idDetalle, ParameterDirection.Input);
            AddCmdParameter("@estado", 0, ParameterDirection.Input);
            AddCmdParameter("@Action", 3, ParameterDirection.Input);
            ExecuteNonQuery();
        }
    }
}
