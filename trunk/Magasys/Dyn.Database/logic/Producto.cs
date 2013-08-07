﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.logic
{
    public class Producto : FactoryBase
    {
        public Producto() { }

        public int SeleccionarReservaPorProducto(int idproducto)
        {
            List<Dyn.Database.entities.Producto> Collection = new List<Dyn.Database.entities.Producto>();
            CreateCommand("usp_SeleccionarReservaPorProducto", true);
            AddCmdParameter("@idproducto", idproducto, ParameterDirection.Input);
            ExecuteReader();
            int i = 0;
            if (Read())
            {
                i++;
            }
            return i;
        }

        public Dyn.Database.entities.Producto Load(int idProducto)
        {
            Dyn.Database.entities.Producto objProducto = new Dyn.Database.entities.Producto();
            CreateCommand("usp_Producto", true);
            AddCmdParameter("@idProducto", idProducto, ParameterDirection.Input);
            AddCmdParameter("@Action", 0, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                objProducto = new Dyn.Database.entities.Producto(GetDataReader());
            }
            return objProducto;
        }

        //public DataSet SeleccionarGenerosPorNombrePaginadoAdmin(string nombre, int paginaactual, ref int numeropaginas)
        //{
        //    CreateCommand("usp_SeleccionarGenerosPorNombrePaginado", true);
        //    AddCmdParameter("@nombre", nombre, ParameterDirection.Input);
        //    AddCmdParameter("@CurrentPage", paginaactual, ParameterDirection.Input);
        //    AddCmdParameter("@PageSize", 100, ParameterDirection.Input);
        //    AddCmdParameter("@TotalRecords", ParameterDirection.Output);
        //    DataSet ds = GetDataSet();
        //    numeropaginas = (int)GetValueCmdParameter("@TotalRecords");
        //    return ds;
        //}

        private void AddParameters(Dyn.Database.entities.Producto objusuario)
        {
            CreateCommand("usp_Producto", true);
            AddCmdParameter("@idProducto", objusuario.IdProducto, ParameterDirection.Input);
            AddCmdParameter("@fechaCreacion", objusuario.Fechacreacion , ParameterDirection.Input);
            AddCmdParameter("@nombre", objusuario.Nombre, ParameterDirection.Input);
            AddCmdParameter("@estado", objusuario.Estado, ParameterDirection.Input);
            AddCmdParameter("@idProveedor", objusuario.IdProveedor, ParameterDirection.Input);

        }

        public object Insert(Dyn.Database.entities.Producto objProducto)
        {
            object IdProducto = null;
            objProducto.Estado = 1;
            AddParameters(objProducto);
            AddCmdParameter("@Action", 2, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                IdProducto = GetValue(0);
            }
            return IdProducto;
        }

        public void Update(Dyn.Database.entities.Producto objProducto)
        {
            objProducto.Estado = 1;
            AddParameters(objProducto);
            AddCmdParameter("@Action", 1, ParameterDirection.Input);
            ExecuteNonQuery();
        }

        public void Delete(int idProducto)
        {
            CreateCommand("usp_Producto", true);
            AddCmdParameter("@idProducto", idProducto, ParameterDirection.Input);
            AddCmdParameter("@estado", 0, ParameterDirection.Input);
            AddCmdParameter("@Action", 3, ParameterDirection.Input);
            ExecuteNonQuery();
        }

    }

    
}
