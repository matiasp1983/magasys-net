using System;
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

        private void AddParameters(Dyn.Database.entities.Producto objproducto)
        {
            CreateCommand("usp_Producto", true);
            AddCmdParameter("@idProducto", objproducto.IdProducto, ParameterDirection.Input);
            AddCmdParameter("@fechaCreacion", objproducto.Fechacreacion, ParameterDirection.Input);
            AddCmdParameter("@nombre", objproducto.Nombre, ParameterDirection.Input);
            AddCmdParameter("@descripcion", objproducto.Descripcion, ParameterDirection.Input);
            AddCmdParameter("@estado", objproducto.Estado, ParameterDirection.Input);
            AddCmdParameter("@idProveedor", objproducto.IdProveedor, ParameterDirection.Input);

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
        public bool existeNombre(String nombre)
        {
            object IdProducto = null;
            CreateCommand("usp_Producto", true);
            AddCmdParameter("@nombre", nombre, ParameterDirection.Input);
            AddCmdParameter("@estado", 1, ParameterDirection.Input);
            AddCmdParameter("@Action", 4, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                IdProducto = GetValue(0);
            }
            if (IdProducto == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public DataSet SeleccionarProductoPorNombrePaginado(string nombre, int paginaactual, ref int numeropaginas, int accion)
        {
            CreateCommand("usp_SeleccionarProductoPorNombrePaginado", true);
            AddCmdParameter("@nombre", nombre, ParameterDirection.Input);
            AddCmdParameter("@CurrentPage", paginaactual, ParameterDirection.Input);
            AddCmdParameter("@PageSize", 100, ParameterDirection.Input);
            AddCmdParameter("@TotalRecords", ParameterDirection.Output);
            AddCmdParameter("@Action", accion, ParameterDirection.Input);
            DataSet ds = GetDataSet();
            numeropaginas = (int)GetValueCmdParameter("@TotalRecords");
            return ds;
        }
        public DataSet SeleccionarProductoPorNombreProveedorPaginado(string nombre, string idProveedor, int paginaactual, ref int numeropaginas, int accion)
        {
            CreateCommand("usp_SeleccionarProductoPorNombreProveedorPaginado", true);
            AddCmdParameter("@nombre", nombre, ParameterDirection.Input);
            AddCmdParameter("@idProveedor", idProveedor, ParameterDirection.Input);
            AddCmdParameter("@CurrentPage", paginaactual, ParameterDirection.Input);
            AddCmdParameter("@PageSize", 100, ParameterDirection.Input);
            AddCmdParameter("@TotalRecords", ParameterDirection.Output);
            AddCmdParameter("@Action", accion, ParameterDirection.Input);
            DataSet ds = GetDataSet();
            numeropaginas = (int)GetValueCmdParameter("@TotalRecords");
            return ds;
        }
        public List<Dyn.Database.entities.Producto> SeleccionarTodosLosProductos(int accion)
        {
            List<Dyn.Database.entities.Producto> Collection = new List<Dyn.Database.entities.Producto>();
            CreateCommand("usp_SeleccionarTodasLosProductos", true);
            AddCmdParameter("@Action", accion, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                Collection.Add(new Dyn.Database.entities.Producto(GetDataReader()));
            }
            return Collection;
        }

        public int VerificaRelacionProducto(int idProducto)
        {
            CreateCommand("usp_ExisteRelacionProducto", true);
            AddCmdParameter("@idProducto", idProducto, ParameterDirection.Input);
            AddCmdParameter("@idProductoOut", ParameterDirection.Output);
            //ExecuteReader();
            DataSet ds = GetDataSet();
            int i = 0;
            i = (int)GetValueCmdParameter("@idProductoOut");
            return i;
        }
    }


}
