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
            CreateCommand("usp_Devolucion", true);
            AddCmdParameter("@idDevolucion", objusuario.IdDevolucion, ParameterDirection.Input);
            AddCmdParameter("@fecha", objusuario.Fecha, ParameterDirection.Input);
            AddCmdParameter("@estado", objusuario.Estado, ParameterDirection.Input);
            AddCmdParameter("@idProveedor", objusuario.IdProveedor, ParameterDirection.Input);
            AddCmdParameter("@descripcion", objusuario.Descripcion, ParameterDirection.Input);
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

        public void Delete(int idDevolucion)
        {
            CreateCommand("usp_Devolucion", true);
            AddCmdParameter("@idDevolucion", idDevolucion, ParameterDirection.Input);
            AddCmdParameter("@estado", 0, ParameterDirection.Input);
            AddCmdParameter("@Action", 3, ParameterDirection.Input);
            ExecuteNonQuery();
        }

    }
}
