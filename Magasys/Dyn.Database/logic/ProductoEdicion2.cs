﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Dyn.Database.logic
{
    public class ProductoEdicion2 : FactoryBase
    {
        public ProductoEdicion2() { }

        public Dyn.Database.entities.IngresoProducto Load(int idIngreso)
        {
            Dyn.Database.entities.IngresoProducto objIngreso = new Dyn.Database.entities.IngresoProducto();
            CreateCommand("usp_ProductoEdicion", true);
            AddCmdParameter("@idProductoEdicion", idIngreso, ParameterDirection.Input);
            AddCmdParameter("@Action", 0, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                objIngreso = new Dyn.Database.entities.IngresoProducto(GetDataReader());
            }
            return objIngreso;
        }
        public Dyn.Database.entities.ProductoEdicion CargarProductoEdicion(int idIngreso)
        {
            Dyn.Database.entities.ProductoEdicion objIngreso = new Dyn.Database.entities.ProductoEdicion();
            CreateCommand("usp_ProductoEdicion", true);
            AddCmdParameter("@idProductoEdicion", idIngreso, ParameterDirection.Input);
            AddCmdParameter("@Action", 0, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                objIngreso = new Dyn.Database.entities.ProductoEdicion(GetDataReader());
            }
            return objIngreso;
        }

        private void AddParameters(Dyn.Database.entities.ProductoEdicion objusuario)
        {
            CreateCommand("usp_ProductoEdicion", true);
            AddCmdParameter("@idProductoEdicion", objusuario.IdProductoEdicion, ParameterDirection.Input);
            AddCmdParameter("@idProducto", objusuario.IdProducto, ParameterDirection.Input);
            AddCmdParameter("@estado", objusuario.Estado, ParameterDirection.Input);
            AddCmdParameter("@cantidadDisponible", objusuario.CantidadUnidades, ParameterDirection.Input);
            AddCmdParameter("@precio", objusuario.Precio, ParameterDirection.Input);
            AddCmdParameter("@descripcion", objusuario.Descripcion, ParameterDirection.Input);
        }

        public object Insert(Dyn.Database.entities.ProductoEdicion objProdEdi)
        {
            object IdProdEdi = null;
            objProdEdi.Estado = 1;
            AddParameters(objProdEdi);
            AddCmdParameter("@Action", 2, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                IdProdEdi = GetValue(0);
            }
            return IdProdEdi;
        }
        public void Update(Dyn.Database.entities.ProductoEdicion objProdEdi)
        {
            objProdEdi.Estado = 1;
            AddParameters(objProdEdi);
            AddCmdParameter("@Action", 1, ParameterDirection.Input);
            ExecuteNonQuery();
        }

        public void Delete(int idProdEdi)
        {
            CreateCommand("usp_ProductoEdicion", true);
            AddCmdParameter("@idProductoEdicion", idProdEdi, ParameterDirection.Input);
            AddCmdParameter("@estado", 0, ParameterDirection.Input);
            AddCmdParameter("@Action", 3, ParameterDirection.Input);
            ExecuteNonQuery();
        }
        public void Devolver(Dyn.Database.entities.ProductoEdicion objusuario)
        {
            CreateCommand("usp_ProductoEdicion", true);
            AddCmdParameter("@idProductoEdicion", objusuario.IdProductoEdicion, ParameterDirection.Input);
            AddCmdParameter("@estado", 2, ParameterDirection.Input);
            AddCmdParameter("@cantidadDisponible", objusuario.CantidadUnidades, ParameterDirection.Input);
            AddCmdParameter("@Action", 3, ParameterDirection.Input);
            ExecuteNonQuery();
        }
        public List<Database.entities.ProductoEdicion> SeleccionarProductoPorProveedor(int idProveedor)
        {
            List<Dyn.Database.entities.ProductoEdicion> Collection = new List<Dyn.Database.entities.ProductoEdicion>();
            CreateCommand("usp_ProductoEdicion", true);
            AddCmdParameter("@idProveedor", idProveedor, ParameterDirection.Input);
            AddCmdParameter("@Action", 4, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                Collection.Add(new Dyn.Database.entities.ProductoEdicion(GetDataReader()));
            }
            return Collection;
        }

    
    }
}
