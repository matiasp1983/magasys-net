using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Dyn.Database.logic
{
    public class Estado : FactoryBase
    {

        public Estado() { }

        public Dyn.Database.entities.Estado Load(int idEstado)
        {
            Dyn.Database.entities.Estado objEstado = new Dyn.Database.entities.Estado();
            CreateCommand("usp_Estado", true);
            AddCmdParameter("@idEstado", idEstado, ParameterDirection.Input);
            AddCmdParameter("@Action", 0, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                objEstado = new Dyn.Database.entities.Estado(GetDataReader());
            }
            return objEstado;
        }


        private void AddParameters(Dyn.Database.entities.Estado objEstado)
        {
            CreateCommand("usp_Estado", true);
            AddCmdParameter("@idEstado", objEstado.IdEstado, ParameterDirection.Input);
            AddCmdParameter("@ambito", objEstado.Ambito, ParameterDirection.Input);
            AddCmdParameter("@nombre", objEstado.Nombre, ParameterDirection.Input);            
            AddCmdParameter("@descripcion", objEstado.Descripcion, ParameterDirection.Input);
        }

        public object Insert(Dyn.Database.entities.Estado objEstado)
        {
            object IdEstado = null;
            // objEstado.Estado = 1;
            AddParameters(objEstado);
            AddCmdParameter("@Action", 2, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                IdEstado = GetValue(0);
            }
            return IdEstado;
        }

        public void Update(Dyn.Database.entities.Estado objEstado)
        {
            // objEstado.Estado = 1;
            AddParameters(objEstado);
            AddCmdParameter("@Action", 1, ParameterDirection.Input);
            ExecuteNonQuery();
        }

        public void Delete(int idEstado)
        {
            CreateCommand("usp_Estado", true);
            AddCmdParameter("@idEstado", idEstado, ParameterDirection.Input);
            AddCmdParameter("@estado", 0, ParameterDirection.Input);
            AddCmdParameter("@Action", 3, ParameterDirection.Input);
            ExecuteNonQuery();
        }
        public int BuscarEstado(String ambito, String nombre)
        {
            object IdEstado = null;
            CreateCommand("usp_Estado", true);
            AddCmdParameter("@nombre", nombre, ParameterDirection.Input);
            AddCmdParameter("@ambito", ambito, ParameterDirection.Input);
            AddCmdParameter("@Action", 4, ParameterDirection.Input);
            ExecuteReader();
            while (Read())
            {
                IdEstado = GetValue(0);
            }
            return Convert.ToInt32(IdEstado);
            
        }
    }
}
