using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.logic
{
    public class ProductoEdicion : FactoryBase
    {
        public ProductoEdicion() { }

        public Dyn.Database.entities.ProductoEdicion Load(int idproducto)
        {
            Dyn.Database.entities.ProductoEdicion objprodEdic = new Dyn.Database.entities.ProductoEdicion();
            CreateCommand("usp_ProductoEdicion", true);
            AddCmdParameter("@idproducto", idproducto, ParameterDirection.Input);
            AddCmdParameter("@Action", 0, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                objprodEdic = new Dyn.Database.entities.ProductoEdicion(GetDataReader());
            }
            return objprodEdic;
        }

        public void Update(Dyn.Database.entities.ProductoEdicion objprodventa)
        {   
            //AddParameters(objprodventa);
            CreateCommand("usp_ProductoEdicion", true);
            AddCmdParameter("@idProducto", objprodventa.IdProducto, ParameterDirection.Input);
            AddCmdParameter("@cantidadDisponible", objprodventa.CantidadUnidades, ParameterDirection.Input);
            AddCmdParameter("@Action", 1, ParameterDirection.Input);
            ExecuteNonQuery();
        }

        //private void AddParameters(Dyn.Database.entities.ProductoEdicion objprodventa)
        //{
        //    CreateCommand("usp_ProductoEdicion", true);
        //    AddCmdParameter("@idProducto", objprodventa.IdProducto, ParameterDirection.Input);
        //    AddCmdParameter("@cantidadDisponible", objprodventa.CantidadUnidades, ParameterDirection.Input);
        //}
    }
}
