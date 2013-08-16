using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Dyn.Database.logic
{
    public class Ingreso : FactoryBase
    {
        public Ingreso() { }

        public Dyn.Database.entities.IngresoProducto Load(int idIngreso)
        {
            Dyn.Database.entities.IngresoProducto objIngreso = new Dyn.Database.entities.IngresoProducto();
            CreateCommand("usp_Ingreso", true);
            AddCmdParameter("@idIngresoProductos", idIngreso, ParameterDirection.Input);
            AddCmdParameter("@Action", 0, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                objIngreso = new Dyn.Database.entities.IngresoProducto(GetDataReader());
            }
            return objIngreso;
        }

        //public List<Dyn.Database.entities.IngresoProducto> SeleccionarDetallesPorIngreso(int idIngreso)
        //{
        //    List<Dyn.Database.entities.DetalleIngresoProducto> Collection = new List<Dyn.Database.entities.DetalleIngresoProducto>();
        //    CreateCommand("usp_Ingreso", true);
        //    AddCmdParameter("@Action", 4, ParameterDirection.Input);
        //    AddCmdParameter("@idIngresoProducto", idIngreso, ParameterDirection.Input);
        //    ExecuteReader();
        //    while (Read())
        //    {
        //        Collection.Add(new Dyn.Database.entities.DetalleIngresoProducto(GetDataReader()));
        //    }
        //    return Collection;
        //}

        private void AddParameters(Dyn.Database.entities.IngresoProducto objusuario)
        {
            CreateCommand("usp_Ingreso", true);
            AddCmdParameter("@idIngresoProducto", objusuario.IdIngresoProducto, ParameterDirection.Input);
            AddCmdParameter("@fecha", objusuario.Fecha, ParameterDirection.Input);
            AddCmdParameter("@estado", objusuario.Estado, ParameterDirection.Input);
            AddCmdParameter("@idProveedor", objusuario.IdProveedor, ParameterDirection.Input);
        }

        public object Insert(Dyn.Database.entities.IngresoProducto objIngreso)
        {
            Database.logic.DetalleIngreso lDetalle = new Database.logic.DetalleIngreso();
            object IdIngreso = null;
            objIngreso.Estado = 1;
            AddParameters(objIngreso);
            AddCmdParameter("@Action", 2, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                IdIngreso = GetValue(0);
            }
            List<Database.entities.DetalleIngresoProducto> listaDetalles = new List<Database.entities.DetalleIngresoProducto>();
            listaDetalles = objIngreso.ObtenerDetalles();
            for (int i = 0; i < listaDetalles.Count; i++)
            {
                listaDetalles[i].IdIngresoProductos = Convert.ToInt32(IdIngreso);
                lDetalle.Insert(listaDetalles[i]);

            }


            return IdIngreso;
        }
        public void Update(Dyn.Database.entities.IngresoProducto objIngreso)
        {
            objIngreso.Estado = 1;
            AddParameters(objIngreso);
            AddCmdParameter("@Action", 1, ParameterDirection.Input);
            ExecuteNonQuery();
        }

        public void Delete(int idIngreso)
        {
            CreateCommand("usp_Ingreso", true);
            AddCmdParameter("@idDetalle", idIngreso, ParameterDirection.Input);
            AddCmdParameter("@estado", 0, ParameterDirection.Input);
            AddCmdParameter("@Action", 3, ParameterDirection.Input);
            ExecuteNonQuery();
        }

    }
}
